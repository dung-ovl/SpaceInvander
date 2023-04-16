using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static UnityEngine.Rendering.VirtualTexturing.Debugging;

public abstract class ObjMovement : GameMonoBehaviour
{

    [SerializeField] protected Vector3 targetPosition;

    [SerializeField] protected bool isMoving;

    private void Update()
    {
        this.GetTargetPosition();
        this.CheckOnMovingAndMoving();
    }

    protected abstract void GetTargetPosition();

    protected virtual void Moving()
    {
        transform.parent.position = this.targetPosition;
    }

    protected virtual void CheckOnMovingAndMoving()
    {
        if (transform.parent.position != this.targetPosition)
        {
            this.Moving();
            this.isMoving = true;
            return;
        }
        this.isMoving = false;
    }
/*    protected virtual void CheckMoving()
    {
        this.isMoving = InputManager.Instance.OnMoving;
    }*/
}


