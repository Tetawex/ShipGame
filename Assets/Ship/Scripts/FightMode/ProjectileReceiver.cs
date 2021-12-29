using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileReceiver : MonoBehaviour
{
    public Action<Projectile> OnProjectileReceived;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ReceiveProjectile(Projectile projectile)
    {
        OnProjectileReceived(projectile);
    }
}
