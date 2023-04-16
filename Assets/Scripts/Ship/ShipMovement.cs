using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static UnityEngine.Rendering.VirtualTexturing.Debugging;

public class ShipMovement : ObjFollowMouse
{
    [SerializeField] protected ShipController shipController;
    public ShipController ShipController => shipController;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadShipController();
    }

    protected virtual void LoadShipController()
    {
        if (shipController != null) return;
        shipController = transform.parent.GetComponent<ShipController>();
        Debug.Log(transform.name + ": LoadShipController", gameObject);
    }

    protected virtual void OnMovingAnimation()
    {
        if (this.isMoving)
        {
            shipController.ShipModel.EngineAnimator.SetBool("isMoving", true);
            return;
        }
        shipController.ShipModel.EngineAnimator.SetBool("isMoving", false);
    }

    /*    protected virtual void CheckMoving()
   {
       this.isMoving = InputManager.Instance.OnMoving;
   }*/
}


