using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDamageSender : DamageSender
{
    [SerializeField] protected BulletController bulletController;
    public BulletController BulletController { get { return bulletController; } }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadBulletController();
    }

    protected virtual void LoadBulletController()
    {
        if (bulletController != null) return;
        bulletController = transform.parent.GetComponent<BulletController>();
        Debug.Log(transform.name + ": LoadBulletController", gameObject);
    }

    public override void Send(Transform transform)
    {
        base.Send(transform);

        this.DestroyBullet();
    }

    protected virtual void DestroyBullet()
    {
        this.bulletController.BulletDespawn.DespawnObject();
    }
}
