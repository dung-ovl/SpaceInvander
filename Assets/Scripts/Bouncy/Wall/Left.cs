using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Left : GameMonoBehaviour
{
    [Header("LeftWall")]
    [SerializeField] protected BoxCollider box;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadWall();
    }

    protected virtual void LoadWall()
    {
        box = GetComponent<BoxCollider>();
    }
}
