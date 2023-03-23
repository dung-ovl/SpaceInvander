using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldCtrl : GameMonoBehaviour
{
    [SerializeField] protected Transform model;
    public Transform Model { get => model; }

    [SerializeField] protected ActiveShield activeShield;

    public ActiveShield ActiveShield { get => activeShield; }

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
}
