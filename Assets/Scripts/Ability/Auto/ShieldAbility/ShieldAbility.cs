using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
[RequireComponent(typeof(Rigidbody))]
public class ShieldAbility : SustentiveAbility
{
    [SerializeField] protected SphereCollider _collider;
    [SerializeField] protected Rigidbody _rigibody;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadTrigger();
        this.LoadRigibody();
    }

    protected override void ResetValue()
    {
        base.ResetValue();
        this.SetupTimeExist();
    }

    protected override void SetupTimeExist()
    {
        this.bonusTimeExists = this.abilityController.ShipController.ShipProfile.shieldTimeUp;
        base.SetupTimeExist();
    }

    protected virtual void LoadTrigger()
    {
        if (this._collider != null) return;
        this._collider = transform.GetComponent<SphereCollider>();
        this._collider.isTrigger = true;
        this._collider.radius = 0.3f;
        Debug.LogWarning(transform.name + ": LoadTrigger", gameObject);
    }

    protected virtual void LoadRigibody()
    {
        if (this._rigibody != null) return;
        this._rigibody = transform.GetComponent<Rigidbody>();
        this._rigibody.useGravity = false;
        this._rigibody.isKinematic = true;
        Debug.LogWarning(transform.name + ": LoadTrigger", gameObject);
    }

    protected virtual void OnTriggerEnter(Collider collider)
    {
        Debug.Log("Thang nay ne" + collider.transform.name);
        return;
    }
}
