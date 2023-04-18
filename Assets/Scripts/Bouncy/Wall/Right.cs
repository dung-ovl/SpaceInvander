using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class Right : GameMonoBehaviour
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
