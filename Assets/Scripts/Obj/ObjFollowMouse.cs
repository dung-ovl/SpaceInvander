using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ObjFollowMouse : ObjMovement
{

    private float deltaX, deltaY;


    protected override void GetTargetPosition()
    {
        if (Input.touchCount > 0)
        {
            Debug.Log("touchCount: " + Input.touchCount);
            Touch touch = Input.GetTouch(0);
            Vector2 touchPos = Camera.main.ScreenToWorldPoint(touch.position);
            

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    this.isMoving = true;
                    deltaX = touchPos.x - transform.position.x;
                    deltaY = touchPos.y - transform.position.y;
                    break;
                case TouchPhase.Moved:
                    targetPosition = new Vector3(touchPos.x - deltaX, touchPos.y - deltaY);
                    break;
                case TouchPhase.Ended:
                    this.isMoving = false;
                    break;
            }

        }
        this.targetPosition.z = 0;
    }

    /*    protected virtual void CheckMoving()
   {
       this.isMoving = InputManager.Instance.OnMoving;
   }*/
}


