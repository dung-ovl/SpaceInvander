using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : GameMonoBehaviour
{
    [SerializeField] protected ShipMovement shipMovement;

    [SerializeField] protected Animator engineAnimator;
    public Animator EngineAnimator => engineAnimator;

    [SerializeField] protected Animator weaponAnimator;
    public Animator WeaponAnimator => weaponAnimator;

    [SerializeField] protected ShipDamageReceiver shipDamageReceiver;
    public ShipDamageReceiver ShipDamageReceiver => shipDamageReceiver;

    [SerializeField] protected AbilityController abilityController;
    public AbilityController AbilityController => abilityController;


    [SerializeField] protected ShipProfileSO shipProfile;
    public ShipProfileSO ShipProfile => shipProfile;


    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadShipMovement();
        this.LoadEngineAnimator();
        this.LoadWeaponAnimator();
        this.LoadShipDamageReceiver();
        this.LoadAbility();
        this.LoadShipProfile();
    }

    private void LoadShipProfile()
    {
        if (this.shipProfile != null) return;
        string resPath = "Ship/" + transform.name;
        this.shipProfile = Resources.Load<ShipProfileSO>(resPath);
        Debug.Log(transform.name + ": LoadShipProfile", gameObject);
    }

    private void LoadAbility()
    {
        if (this.abilityController != null) return;
        this.abilityController = GetComponentInChildren<AbilityController>();
        Debug.Log(transform.name + ": LoadAbilityController", gameObject);
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

}
