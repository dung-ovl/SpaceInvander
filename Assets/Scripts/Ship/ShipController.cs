using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : GameMonoBehaviour
{
    [SerializeField] protected ShipMovement shipMovement;

    [SerializeField] protected ShipDamageReceiver shipDamageReceiver;
    public ShipDamageReceiver ShipDamageReceiver => shipDamageReceiver;

    [SerializeField] protected AbilityController abilityController;
    public AbilityController AbilityController => abilityController;

    [SerializeField] protected ShipProfileSO shipProfile;
    public ShipProfileSO ShipProfile => shipProfile;

    [SerializeField] protected ShipModel shipModel;
    public ShipModel ShipModel => shipModel;


    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadShipMovement();
        this.LoadShipDamageReceiver();
        this.LoadAbility();
        this.LoadShipProfile();
        this.LoadShipModel();
    }

    protected virtual void LoadShipModel()
    {
        if (this.shipModel != null) return;
        this.shipModel = GetComponentInChildren<ShipModel>();
        Debug.Log(transform.name + ": LoadShipProfile", gameObject);
    }

    protected virtual void LoadShipProfile()
    {
        if (this.shipProfile != null) return;
        string resPath = "Ship/" + transform.name;
        this.shipProfile = Resources.Load<ShipProfileSO>(resPath);
        Debug.Log(transform.name + ": LoadShipProfile", gameObject);
    }

    protected virtual void LoadAbility()
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



}
