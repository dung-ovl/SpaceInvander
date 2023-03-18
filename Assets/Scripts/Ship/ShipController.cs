using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : GameMonoBehaviour
{
    [SerializeField] protected ShipMovement shipMovement;

    [SerializeField] protected Animator engineAnimator;

    [SerializeField] protected Animator weaponAnimator;

    public Animator WeaponAnimator => weaponAnimator;


    public Animator EngineAnimator => engineAnimator;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadShipMovement();
        this.LoadEngineAnimator();
        this.LoadWeaponAnimator();
    }

    protected virtual void LoadShipMovement()
    {
        if (this.shipMovement != null) return;
        this.shipMovement = GetComponentInChildren<ShipMovement>();
        Debug.Log(transform.name + ": LoadShipMovement", gameObject);
    }

    protected virtual void LoadEngineAnimator()
    {
        if (this.engineAnimator != null) return;
        Transform engine = transform.Find("Model/Engine");
        this.engineAnimator = engine.GetComponent<Animator>();
        Debug.Log(transform.name + ": LoadEngineAnimator", gameObject);
    }

    protected virtual void LoadWeaponAnimator()
    {
        if (this.weaponAnimator != null) return;
        Transform weapon = transform.Find("Model/Weapon");
        this.weaponAnimator = weapon.GetComponent<Animator>();
        Debug.Log(transform.name + ": LoadWeaponAnimator", gameObject);
    }
}
