using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldAbility : Ability
{
    [SerializeField] protected Transform model;
    public Transform Model { get => model; }

    [SerializeField] protected ActiveShield activeShield;

    public ActiveShield ActiveShield { get => activeShield; }

    [SerializeField] protected float timeExists = 5f;
    public float TimeExists { get { return timeExists; } set { timeExists = value; } }

    [SerializeField] protected float timeRemains = 0;
    public float TimeRemains { get { return timeRemains; } set { timeRemains = value; } }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadModel();
        this.LoadActiveShield();
    }

    protected virtual void LoadModel()
    {
        if (this.model != null) return;
        this.model = transform.Find("Model");
        Debug.Log(transform.name + ": LoadModel", gameObject);
    }

    protected virtual void LoadActiveShield()
    {
        if (this.activeShield != null) return;
        this.activeShield = transform.GetComponentInChildren<ActiveShield>();
        Debug.Log(transform.name + ": LoadActiveShield", gameObject);
    }
    public override void Active()
    {
        this.activeShield.SetTimeExists(5f);
        this.activeShield.Shield();
    }
}
