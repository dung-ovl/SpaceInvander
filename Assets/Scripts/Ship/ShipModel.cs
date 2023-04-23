using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class ShipModel : ShipAbstract
{
    [Header("ShipModel")]
    [SerializeField] protected Animator engineAnimator;
    public Animator EngineAnimator => engineAnimator;

    [SerializeField] protected Animator weaponAnimator;
    public Animator WeaponAnimator => weaponAnimator;

    [SerializeField] protected ShipShootPoint shipShootPoint;
    public ShipShootPoint ShipShootPoint => shipShootPoint;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadEngineAnimator();
        this.LoadWeaponAnimator();
        this.LoadShipShootPoint();
    }

    private void LoadShipShootPoint()
    {
        if (this.shipShootPoint != null) return;
        this.shipShootPoint = transform.GetComponent<ShipShootPoint>();
        Debug.Log(transform.name + ": LoadShipShootPoint", gameObject);
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
