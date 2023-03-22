using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DespawnByDistance : Despawn
{
    [SerializeField] protected float disLimit = 70f;
    [SerializeField] protected float distance = 0f;

    protected override bool CanDespawn()
    {
        this.distance = Vector3.Distance(transform.position, GameCtrl.Instance.MainCamera.transform.position);
        if (this.distance > this.disLimit) return true;
        return false;   
    }
}
