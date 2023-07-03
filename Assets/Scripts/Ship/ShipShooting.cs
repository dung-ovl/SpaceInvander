
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
    [SerializeField] protected float damage = 1f;
    [SerializeField] protected List<Transform> shipShootPoints;
    [SerializeField] string bulletName = "no-name";

    public List<ShipPointLevelInfo> bulletNames = new List<ShipPointLevelInfo>();

    protected override void ResetValue()
    {
        base.ResetValue();
        this.SetupShootSpeed();
        this.SetupDamage();
    }

    protected virtual void SetupDamage()
    {
        this.damage = shipController.ShipProfile.mainDamage;
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
        numberLaser = 0;
    }

    private void Update()
    {
        this.Shooting();
    }

    private void FixedUpdate()
    {
        this.LoadCurrentShootPoints();
    }

    protected virtual void LoadCurrentShootPoints()
    {
        Transform currentShootPointObj = this.shipController.ShipModel.ShipShootPoint.CurrentShipMainShootPointObj();
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

    protected virtual int CalculateShootPointIndex()
    {
        int index = this.ShipController.ShipLevel.LevelCurrent - 1;
        if (index < 0)
        {
            index = 0;
        }
        else if (index >= bulletNames.Count)
        {
            index = bulletNames.Count - 1;
        }
        return index;
    }

    protected virtual void ShootingWithShootPoint()
    {
        if (!this.isShooting) return;
        shootTimer += Time.deltaTime;
        if (shootTimer < shootDelay) return;
        shootTimer = 0;
        int count = 0;
        int index = CalculateShootPointIndex();
        List<ShipPointInfo> shipPointInfo = bulletNames[index].Levels;
        foreach (Transform shootPoint in shipShootPoints)
        {
            Vector3 spawnPos = shootPoint.position;
            Quaternion rotation = Quaternion.Euler(shootPoint.rotation.eulerAngles.x, shootPoint.rotation.eulerAngles.y, shipPointInfo[count].Rot);
            string bulletName = shipPointInfo[count].Name;

            Transform newBullet = BulletSpawner.Instance.Spawn(bulletName, spawnPos, rotation);
            if (newBullet == null) return;
            newBullet.gameObject.SetActive(true);

            DamageSender damageSender = newBullet.GetComponent<DamageSender>();
            if (damageSender != null)
            {
                damageSender.SetDamage(this.damage);
            }
            if (bulletName != BulletSpawner.Instance.BulletThree)
            {
                BulletController bulletController = newBullet.GetComponent<BulletController>();
                bulletController.SetShooter(transform.parent);
                Debug.Log("Shoot");
            }
            else
            {
                BulletLaser bulletLaser = newBullet.GetComponent<BulletLaser>();
                bulletLaser.laserName = "laser" + numberLaser;
                bulletLaser.IsLaser = true;
                bulletLaser.Position = shootPoint;
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


/*    protected virtual void OnShootingAnimation()
    {
        if (!this.isShooting)
        {
            shipController.ShipModel.WeaponAnimator.SetBool("isShooting", false);
            return;
        }
        shipController.ShipModel.WeaponAnimator.SetBool("isShooting", true);
    }*/

    public virtual void SetupShootSpeed(int speedPercentAdd = 0)
    {
        this.shootDelay =  CalculateAttackSpeed(speedPercentAdd);
        this.shootTimer = shootDelay;
    }

    public virtual float CalculateAttackSpeed(int speedPercentAdd)
    {
        return shipController.ShipProfile.mainAttackSpeed * (100f / (100 + speedPercentAdd));
    }
}
