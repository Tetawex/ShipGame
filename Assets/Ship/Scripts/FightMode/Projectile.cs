using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TeamTag
{
    PLAYER, ENEMY
}

public class Projectile : MonoBehaviour
{
    public TeamTag TeamTag;
    public float Speed = 1f;

    public Rigidbody2D rigidbody2D;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void LaunchSelfAt(Vector3 target)
    {
        rigidbody2D.velocity = (target - transform.position).normalized * Speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.collider.gameObject.GetComponent<ProjectileReceiver>()?.ReceiveProjectile(this);
        Destroy(gameObject);
    }
}
