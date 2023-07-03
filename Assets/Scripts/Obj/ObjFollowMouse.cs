using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ObjFollowMouse : ObjMovement
{

    protected override void GetTargetPosition()
    {
        this.targetPosition = InputManager.Instance.MouseWorldPos;
        this.targetPosition.z = 0;
    }

    /*    protected virtual void CheckMoving()
   {
       this.isMoving = InputManager.Instance.OnMoving;
   }*/
}


