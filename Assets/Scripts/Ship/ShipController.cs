using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : GameMonoBehaviour
{
    [SerializeField] protected ShipMovement shipMovement;

    [SerializeField] protected Animator engineAnimator;

    public Animator EngineAnimator => engineAnimator;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadShipMovement();
        this.LoadAnimator();
    }

    protected virtual void LoadShipMovement()
    {
        if (this.shipMovement != null) return;
        this.shipMovement = GetComponentInChildren<ShipMovement>();
        Debug.Log(transform.name + ": LoadShipMovement", gameObject);
    }

    protected virtual void LoadAnimator()
    {
        if (this.engineAnimator != null) return;
        Transform engine = transform.Find("Model/Engine");
        this.engineAnimator = engine.GetComponent<Animator>();
        Debug.Log(transform.name + ": LoadAnimator", gameObject);
    }
}
