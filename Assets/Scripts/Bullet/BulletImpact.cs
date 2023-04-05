using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(SphereCollider))]
public class BulletImpact : BulletAbstract
{
    [SerializeField] protected Collider sphereCollider;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadCollider();
    }

    protected virtual void LoadCollider()
    {
        if (this.sphereCollider != null) return;
        this.sphereCollider = transform.GetComponent<SphereCollider>();
        this.sphereCollider.isTrigger = true;
        
        Debug.Log(transform.name + ": LoadCollider", gameObject);
    }

    protected virtual void OnTriggerEnter(Collider other)
    {
        if (other.transform.parent == this.bulletController.Shooter) return;
        //if (other.GetComponent<>)
        this.bulletController.BulletDamageSender.Send(other.transform);
        Vector3 hitPos = other.transform.position;
        Quaternion hitRot = other.transform.rotation;
        //this.CreateImpactFX(hitPos, hitRot);
    }

    protected virtual void CreateImpactFX(Vector3 hitPos, Quaternion hitRot)
    {
        string fxImpactName = GetImpactFXName();
        Transform newFxImpact = FXSpawner.Instance.Spawn(fxImpactName, hitPos, hitRot);
        if (newFxImpact == null) return;
        newFxImpact.gameObject.SetActive(true);
    }

    protected virtual string GetImpactFXName()
    {
        return FXSpawner.Instance.Impact1;
    }

    protected virtual void Bounce(Collider collider)
    {

    }    
}
