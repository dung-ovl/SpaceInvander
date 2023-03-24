using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static UnityEngine.Rendering.VirtualTexturing.Debugging;

public class ShipMovement : ShipAbstract
{

    [SerializeField] protected Vector3 targetPosition;

    [SerializeField] protected bool isMoving;


    private void FixedUpdate()
    {
        this.GetTargetPosition();
        this.Moving();
        this.OnMovingAnimation();
    }

    protected virtual void GetTargetPosition()
    {
        this.targetPosition = InputManager.Instance.MouseWorldPos;
        this.targetPosition.z = 0;
    }

    protected virtual void Moving()
    {
        if (transform.parent.position != this.targetPosition)
        {
            transform.parent.position = this.targetPosition;
            this.isMoving = true;
            return;
        }
        this.isMoving = false;

    }

    protected virtual void OnMovingAnimation()
    {
        if (this.isMoving)
        {
            shipController.EngineAnimator.SetBool("isMoving", true);
            return;
        }
        shipController.EngineAnimator.SetBool("isMoving", false);
    }
/*    protected virtual void CheckMoving()
    {
        this.isMoving = InputManager.Instance.OnMoving;
    }*/
}


