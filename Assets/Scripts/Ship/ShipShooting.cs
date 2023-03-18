using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipShooting : ShipAbstract
{
    [SerializeField] protected bool isShooting = true;
    [SerializeField] protected float shootDelay = 0.2f;
    [SerializeField] protected float shootTimer = 0f;

    private void Update()
    {
        this.CheckShooting();
    }

    private void FixedUpdate()
    {
        this.Shooting();
    }


    protected virtual void Shooting()
    {
        if (!isShooting)
        {
            shipController.WeaponAnimator.SetBool("isShooting", false);
            return;
        }
        shipController.WeaponAnimator.SetBool("isShooting", true);
        shootTimer += Time.fixedDeltaTime;
        if (shootTimer < shootDelay) return;
        shootTimer = 0;

        Vector3 spawnPos = transform.position;
        Quaternion rotation = transform.parent.rotation;

        string bulletName;
        for (int i = -2; i <= 2; i++)
        {
            Vector3 spawn = spawnPos + Vector3.right * i / 20 + Vector3.up * -Mathf.Abs(i) /10 ;
            Quaternion rot = Quaternion.AngleAxis(-i * 5, Vector3.forward);
            if (i % 2 == 0)
            {
                bulletName = Spawner.Instance.BulletOne;
            }
            else
            {
                bulletName = Spawner.Instance.BulletTwo;
            }
            Transform newBullet = Spawner.Instance.Spawn(bulletName, spawn, rot);
            if (newBullet == null) return;
            newBullet.gameObject.SetActive(true);
            Debug.Log("Shoot");
        }   
    }

    protected virtual void CheckShooting()
    {
        
    }
}
