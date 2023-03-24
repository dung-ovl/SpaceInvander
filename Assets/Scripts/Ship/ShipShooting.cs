using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipShooting : ShipAbstract
{
    [Header("ShipShooting")]
    [SerializeField] protected bool isShooting = true;
    [SerializeField] protected float shootDelay = 0.2f; //attackspeed
    [SerializeField] protected float shootTimer = 0f;

    protected override void ResetValue()
    {
        base.ResetValue();
        this.SetupShootSpeed();
    }

    private void Update()
    {
        
    }

    private void FixedUpdate()
    {
        this.Shooting();
        this.OnShootingAnimation();
    }


    protected virtual void Shooting()
    {
        if (!this.isShooting) return;
        shootTimer += Time.fixedDeltaTime;
        if (shootTimer < shootDelay) return;
        shootTimer = 0;
        Vector3 spawnPos = transform.position;
        Quaternion rotation = transform.parent.rotation;
        string bulletName = "";
        for (int i = -2; i <= 2; i++)
        {
            Vector3 spawn = spawnPos + Vector3.right * i / 30 + Vector3.up * -Mathf.Abs(i) / 30 ;
            Quaternion rot = Quaternion.AngleAxis(-i * 5, Vector3.forward);
            bulletName = BulletSpawner.Instance.BulletOne;
            Transform newBullet = BulletSpawner.Instance.Spawn(bulletName, spawn, rot);
            if (newBullet == null) return;
            newBullet.gameObject.SetActive(true);
            Debug.Log("Shoot");
        }
    }

    protected virtual void OnShootingAnimation()
    {
        if (!this.isShooting)
        {
            shipController.WeaponAnimator.SetBool("isShooting", false);
            return;
        }
        shipController.WeaponAnimator.SetBool("isShooting", true);
    }

    protected virtual void SetupShootSpeed(int speedPercentAdd = 0)
    {
        this.shootDelay = shipController.ShipProfile.attackSpeed * (100f/(100 + speedPercentAdd));
        this.shootTimer = shootDelay;
    }
}
