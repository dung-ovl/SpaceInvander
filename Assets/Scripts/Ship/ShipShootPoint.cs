using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipShootPoint : ShipAbstract
{
    [SerializeField] protected List<Transform> shipShootPointsEachLevel;
    public List<Transform> ShipShootPoints => shipShootPointsEachLevel;

    [SerializeField] protected List<Transform> weaponShootPoints;
    public List<Transform> WeaponShootPoints => weaponShootPoints;

    [SerializeField] protected int currentIndex = 0;

    protected override void Start()
    {
        base.Start();
    }

    private void FixedUpdate()
    {
        
    }

    protected virtual void SetCurrentIndex(int index)
    {
        this.currentIndex = index;
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadShipShootPointObjs();
        this.LoadWeaponShootPointObjs();
    }

    protected virtual void LoadShipShootPointObjs()
    {
        if (this.shipShootPointsEachLevel.Count > 0) return;
        Transform currentShip = transform.Find("Ship");
        foreach (Transform shootPonts in currentShip)
        {
            this.shipShootPointsEachLevel.Add(shootPonts);
        }
    }

    protected virtual void LoadWeaponShootPointObjs()
    {
        if (this.weaponShootPoints.Count > 0) return;
        Transform currentWeapon = transform.Find("Weapon");
        foreach (Transform shootPonts in currentWeapon)
        {
            this.weaponShootPoints.Add(shootPonts);
        }
    }
    protected virtual void HideShipShootPointObjs()
    {
        foreach (Transform shootPoint in shipShootPointsEachLevel)
        {
            shootPoint.gameObject.SetActive(false);
        }
    }

    public virtual void ShipShootPointObjActive(int index)
    {
        this.HideShipShootPointObjs();
        if (index >= this.shipShootPointsEachLevel.Count) index = this.shipShootPointsEachLevel.Count - 1;
        if (index < 0) index = 0;
        this.currentIndex = index;
        this.CurrentShipShootPointObj().gameObject.SetActive(true);
    }



    public virtual Transform CurrentShipShootPointObj()
    {
        return shipShootPointsEachLevel[this.currentIndex];
    }
}
