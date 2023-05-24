
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ShipShooting : ShipAbstract
{
    [Header("ShipShooting")]
    [SerializeField] protected bool isShooting = true;
    public int numberLaser;
    [SerializeField] protected float shootDelay = 0.2f; //attackspeed
    [SerializeField] protected float shootTimer = 0f;
    [SerializeField] protected List<Transform> shipShootPoints;
    [SerializeField] string bulletName = "no-name";

    public List<ShipPointInfo> bulletNames = new List<ShipPointInfo>();

    protected override void ResetValue()
    {
        base.ResetValue();
        this.SetupShootSpeed();
    }

    protected override void Start()
    {
        base.Start();
        this.LoadCurrentShootPoints();
        this.LoadBulletName();
    }

    protected virtual void LoadBulletName()
    {
        this.bulletNames = ShipController.ShipProfile.mainBulletList;
        foreach (var bullet in this.bulletNames)
        {
            if (bullet.Name == "Laser")
                numberLaser++;
        }
    }

    private void Update()
    {
        this.Shooting();
        this.OnShootingAnimation();
    }

    private void FixedUpdate()
    {
        this.LoadCurrentShootPoints();
    }

    private void LoadCurrentShootPoints()
    {
        Transform currentShootPointObj = this.shipController.ShipModel.ShipShootPoint.CurrentShipShootPointObj();
        this.shipShootPoints.Clear();
        foreach (Transform shootPoint in currentShootPointObj)
        {
            this.shipShootPoints.Add(shootPoint);
        }
    }

    protected virtual void Shooting()
    {
        if (this.shipShootPoints.Count <= 0)
        {
            this.ShootingWithNoShootPoint();
            return;
        }
        this.ShootingWithShootPoint();
    }

    protected virtual void ShootingWithShootPoint()
    {
        if (!this.isShooting) return;
        shootTimer += Time.deltaTime;
        if (shootTimer < shootDelay) return;
        shootTimer = 0;
        int count = 0;
        foreach (Transform shootPoint in shipShootPoints)
        {
            Vector3 spawnPos = shootPoint.position;
            Quaternion rotation = Quaternion.Euler(shootPoint.rotation.eulerAngles.x, shootPoint.rotation.eulerAngles.y, this.bulletNames[count].Rot);
            string bulletName = this.bulletNames[count].Name;
            if (bulletName != BulletSpawner.Instance.BulletThree)
            {
                Transform newBullet = BulletSpawner.Instance.Spawn(bulletName, spawnPos, rotation);
                if (newBullet == null) return;
                newBullet.gameObject.SetActive(true);
                BulletController bulletController = newBullet.GetComponent<BulletController>();
                bulletController.SetShooter(transform.parent);
                Debug.Log("Shoot");
            }
            else
            {
                if (numberLaser < 1) return;
                Transform newBullet = BulletSpawner.Instance.Spawn(bulletName, spawnPos, rotation);
                if (newBullet == null) return;
                newBullet.gameObject.SetActive(true);
                BulletLaser bulletLaser = newBullet.GetComponent<BulletLaser>();
                bulletLaser.laserName = "laser" + numberLaser;
                bulletLaser.IsLaser = true;
                bulletLaser.Position = shootPoint;
                numberLaser--;
            }
            count++;
        }
    }

    protected virtual void ShootingWithNoShootPoint()
    {
        if (!this.isShooting) return;
        shootTimer += Time.deltaTime;
        if (shootTimer < shootDelay) return;
        shootTimer = 0;
        Vector3 spawnPos = transform.position;
        Quaternion rotation = transform.parent.rotation;
        Transform newBullet = BulletSpawner.Instance.Spawn(this.bulletName, spawnPos, rotation);
        if (newBullet == null) return;
        newBullet.gameObject.SetActive(true);
        Debug.Log("Shoot");
    }


    protected virtual void OnShootingAnimation()
    {
        if (!this.isShooting)
        {
            shipController.ShipModel.WeaponAnimator.SetBool("isShooting", false);
            return;
        }
        shipController.ShipModel.WeaponAnimator.SetBool("isShooting", true);
    }

    public virtual void SetupShootSpeed(int speedPercentAdd = 0)
    {
        this.shootDelay = shipController.ShipProfile.attackSpeed * (100f / (100 + speedPercentAdd));
        this.shootTimer = shootDelay;
    }
}
