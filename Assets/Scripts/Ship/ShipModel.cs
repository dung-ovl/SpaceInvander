using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipModel : ShipAbstract
{
    [SerializeField] protected Animator engineAnimator;
    public Animator EngineAnimator => engineAnimator;

    [SerializeField] protected Animator weaponAnimator;
    public Animator WeaponAnimator => weaponAnimator;
    [SerializeField] protected List<Transform> shipShootPoints;
    [SerializeField] protected List<Transform> weaponShootPoints;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadEngineAnimator();
        this.LoadWeaponAnimator();
        this.LoadShipShootPoints();
        this.LoadWeaponShootPoints();
    }

    protected virtual void LoadWeaponShootPoints()
    {
        if (this.weaponShootPoints.Count > 0) return;
        Transform currentWeapon = transform.Find("Weapon");
        foreach (Transform shootPonts in currentWeapon)
        {
            this.weaponShootPoints.Add(shootPonts);
        }
    }

    protected virtual void LoadShipShootPoints()
    {
        if (this.shipShootPoints.Count > 0) return;
        Transform currentShip = transform.Find("Ship");
        foreach (Transform shootPonts in currentShip)
        {
            this.shipShootPoints.Add(shootPonts);
        }
    }

    protected virtual void LoadEngineAnimator()
    {
        if (this.engineAnimator != null) return;
        Transform engine = transform.Find("Engine");
        this.engineAnimator = engine.GetComponentInChildren<Animator>();
        Debug.Log(transform.name + ": LoadEngineAnimator", gameObject);
    }

    protected virtual void LoadWeaponAnimator()
    {
        if (this.weaponAnimator != null) return;
        Transform weapon = transform.Find("Weapon");
        this.weaponAnimator = weapon.GetComponentInChildren<Animator>();
        Debug.Log(transform.name + ": LoadWeaponAnimator", gameObject);
    }
}
