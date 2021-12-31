using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FighterShipController : GenericShipController
{
    public static float SECOND = 1;

    public Ship Ship;
    public IBaseShipStats ShipStats;
    public float ShipCurrentHP = 0f;

    private float elapsedTimeSinceShot = 0f;
    private float elapsedTimeSinceRam = 0f;

    private float shotInterval = Mathf.Infinity;
    private float ramInterval = Mathf.Infinity;

    public GameObject enemyTarget;

    private bool isFighting = false;

    [SerializeField]
    private GameObject projectilePrefab;
    [SerializeField]
    private ShipStatsDisplayController shipStatsDisplayController;
    [SerializeField]
    private GameObject statDisplay;

    private Animator parentAnimator;

    private ProjectileReceiver projectileReceiver;

    private ShipAudioPlayer shipAudioPlayer;

    public Action OnDidReceiveFatalDamage;

    [SerializeField]
    public TeamTag TeamTag = TeamTag.PLAYER;
    void Start()
    {
        projectileReceiver = GetComponentInChildren<ProjectileReceiver>();
        projectileReceiver.OnProjectileReceived += HandleProjectileReceived;

        gameObject.layer = LayerMask.NameToLayer(TeamTag == TeamTag.PLAYER ? "PlayerShip" : "EnemyShip");
        projectileReceiver.gameObject.layer = gameObject.layer;

        parentAnimator = GetComponentInParent<Animator>();
        shipAudioPlayer = GetComponent<ShipAudioPlayer>();
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

        shipStatsDisplayController.DisplayShipStats(ShipStats);
    }

    public void StopFight()
    {
        isFighting = false;
    }

    public void HandleProjectileReceived(Projectile projectile)
    {
        ReceiveDamage(projectile.Damage);
    }

    public void HandleRamAttackReceived(float damage)
    {
        ReceiveDamage(damage);
        shipAudioPlayer.PlayRam();
    }

    public void ReceiveDamage(float damage)
    {
        ShipCurrentHP -= damage;
        shipStatsDisplayController.DisplayHP(ShipCurrentHP);

        if (ShipCurrentHP <= 0 && !isFighting)
        {
            Debug.Log("Boom");
            shipAudioPlayer.PlayDeath();

            OnDidReceiveFatalDamage();
        }
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
                EmitProjectile(Instantiate(projectilePrefab,
                    projectileReceiver.transform.position + new Vector3(0f, UnityEngine.Random.Range(-0.3f, 0.3f), 0f),
                    Quaternion.identity));
            }
            if (elapsedTimeSinceRam >= ramInterval)
            {
                parentAnimator.SetTrigger("Ram");
                elapsedTimeSinceRam = 0f;
                //EmitProjectile(Instantiate(projectilePrefab, transform.position, Quaternion.identity, transform));
            }
        }
    }

    public void EmitProjectile(GameObject projectileGO)
    {
        shipAudioPlayer.PlayShot();

        var proj = projectileGO.GetComponent<Projectile>();
        proj.Damage = ShipStats.ShotAD;
        proj.LaunchSelfAt(enemyTarget.transform.position);

        projectileGO.layer = LayerMask.NameToLayer(TeamTag == TeamTag.PLAYER ? "PlayerProjectile" : "EnemyProjectile");
    }

    public override GameObject ShipPartToGameObject(ShipPart part, Vector3 position)
    {
        var instance = part.ToGameObject(gameObject);
        instance.transform.localPosition = position;

        return instance;
    }

    public void OnRamAnimationEnd()
    {
        Debug.Log(enemyTarget);
        enemyTarget?.GetComponentInChildren<FighterShipController>()?.HandleRamAttackReceived(ShipStats.RamAD);
    }
}
