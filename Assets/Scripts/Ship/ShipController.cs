using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : GameMonoBehaviour
{
    [SerializeField] protected ShipMovement shipMovement;

    [SerializeField] protected Animator engineAnimator;

    [SerializeField] protected Animator weaponAnimator;

    [SerializeField] protected ShipDamageReceiver shipDamageReceiver;

    [SerializeField] protected AbilityController ability;
    public AbilityController Ability => ability;

    public ShipDamageReceiver ShipDamageReceiver => shipDamageReceiver;



    public Animator WeaponAnimator => weaponAnimator;


    public Animator EngineAnimator => engineAnimator;

    [SerializeField] protected ShieldCtrl shield;
    public ShieldCtrl Shield => shield;


    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadShipMovement();
        this.LoadEngineAnimator();
        this.LoadWeaponAnimator();
        this.LoadShipDamageReceiver();
        this.LoadAbility();
    }

    private void LoadAbility()
    {
        if (this.ability != null) return;
        this.ability = GetComponentInChildren<AbilityController>();
        Debug.Log(transform.name + ": LoadAbility", gameObject);
    }

    protected virtual void LoadShipDamageReceiver()
    {
        if (this.shipDamageReceiver != null) return;
        this.shipDamageReceiver = GetComponentInChildren<ShipDamageReceiver>();
        Debug.Log(transform.name + ": LoadShipDamageReceiver", gameObject);
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

    protected virtual void LoadShield()
    {
        if (this.shield != null) return;
        this.shield = transform.GetComponentInChildren<ShieldCtrl>();
        Debug.Log(transform.name + ": LoadShield", gameObject);
    }
}
