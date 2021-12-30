using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FighterShipController : GenericShipController
{
    public static float SECOND = 1000f;

    public Ship Ship;
    public IBaseShipStats ShipStats;
    public float ShipCurrentHP = 0f;

    private float elapsedTimeSinceShot = 1000f;
    private float elapsedTimeSinceRam = 1500f;

    private float shotInterval = Mathf.Infinity;
    private float ramInterval = Mathf.Infinity;

    public GameObject enemyTarget;

    private bool isFighting = false;

    [SerializeField]
    private GameObject projectilePrefab;

    [SerializeField]
    public TeamTag TeamTag = TeamTag.PLAYER;
    void Start()
    {
        var projectileReceiver = GetComponentInChildren<ProjectileReceiver>();
        projectileReceiver.OnProjectileReceived += HandleProjectileReceived;

        gameObject.layer = LayerMask.NameToLayer(TeamTag == TeamTag.PLAYER ? "PlayerShip" : "EnemyShip");
    }

    public void StartFight(GameObject enemyTarget, TeamTag teamTag)
    {
        TeamTag = teamTag;

        Ship = BuildShipModel();
        ShipStats = Ship.GetShipStats();
        ShipCurrentHP = ShipStats.HP;

        shotInterval = ShipStats.ShotAS > 0 ? SECOND / ShipStats.ShotAS : Mathf.Infinity;
        ramInterval = ShipStats.RamAS > 0 ? SECOND / ShipStats.RamAS : Mathf.Infinity;

        isFighting = true;
        this.enemyTarget = enemyTarget;
    }

    public void HandleProjectileReceived(Projectile projectile)
    {
        ShipCurrentHP -= 10f;
    }

    private void Update()
    {
        if (isFighting)
        {
            elapsedTimeSinceShot += Time.deltaTime;
            elapsedTimeSinceRam += Time.deltaTime;

            if (elapsedTimeSinceShot >= shotInterval)
            {
                elapsedTimeSinceShot = 0f;
                EmitProjectile(Instantiate(projectilePrefab, transform.position, Quaternion.identity, transform));
            }
            if (elapsedTimeSinceRam >= ramInterval)
            {
                elapsedTimeSinceRam = 0f;
                EmitProjectile(Instantiate(projectilePrefab, transform.position, Quaternion.identity, transform));
            }
        }
    }

    public void EmitProjectile(GameObject projectileGO)
    {
        projectileGO.GetComponent<Projectile>()?.LaunchSelfAt(enemyTarget.transform.position);
        projectileGO.layer = LayerMask.NameToLayer(TeamTag == TeamTag.PLAYER ? "PlayerProjectile" : "EnemyProjectile");
    }

    public override GameObject ShipPartToGameObject(ShipPart part, Vector3 position)
    {
        var instance = part.ToGameObject(gameObject);
        instance.transform.localPosition = position;

        return instance;
    }
}
