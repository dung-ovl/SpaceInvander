using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SustentiveAbility : Ability
{
    [SerializeField] protected Transform model;
    public Transform Model { get => model; }

    [SerializeField] protected ActiveSustentiveAbility activeSusAbility;

    public ActiveSustentiveAbility ActiveSustentiveAbility { get => activeSusAbility; }

    [SerializeField] protected float timeExists;
    public float TimeExists { get { return timeExists; } set { timeExists = value; } }

    [SerializeField] protected float baseTimeExists = 5f;
    public float BaseTimeExists { get { return baseTimeExists; }}

    [SerializeField] protected float bonusTimeExists;
    public float BonusTimeExists { get { return bonusTimeExists; } set { bonusTimeExists = value; } }

    [SerializeField] protected float timeRemains = 0;
    public float TimeRemains { get { return timeRemains; } set { timeRemains = value; } }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadModel();
        this.LoadSustentiveAbility();
    }

    protected virtual void LoadModel()
    {
        if (this.model != null) return;
        this.model = transform.Find("Model");
        Debug.Log(transform.name + ": LoadModel", gameObject);
    }

    protected virtual void LoadSustentiveAbility()
    {
        if (this.activeSusAbility != null) return;
        this.activeSusAbility = transform.GetComponentInChildren<ActiveSustentiveAbility>();
        Debug.Log(transform.name + ": LoadSustentiveAbility", gameObject);
    }
    public override void Active()
    {
        this.activeSusAbility.Activating();
    }

    protected virtual void SetupTimeExist()
    {
        this.timeExists = this.baseTimeExists + this.bonusTimeExists;
    }
}