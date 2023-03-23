using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldAbstract : GameMonoBehaviour
{
    [SerializeField] protected ShieldCtrl shipCtrl;
    public ShieldCtrl ShieldCtrl { get { return shipCtrl; } }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadShieldCtrl();
    }

    protected virtual void LoadShieldCtrl()
    {
        if (shipCtrl != null) return;
        shipCtrl = transform.parent.GetComponent<ShieldCtrl>();
        Debug.Log(transform.name + ": LoadShipController", gameObject);
    }
}
