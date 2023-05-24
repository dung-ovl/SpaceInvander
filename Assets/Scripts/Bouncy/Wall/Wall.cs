using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Collider))]
public class Wall : GameMonoBehaviour
{
    [Header("LeftWall")]
    [SerializeField] protected BoxCollider boxCollider;
    [SerializeField] protected float offsetPos = 0.1f;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadCollider();
    }

    protected void SetPosition(float x, float y)
    {
        this.transform.position = new Vector3(x, y, 0);
    }

    protected virtual void LoadCollider()
    {
        this.boxCollider = GetComponent<BoxCollider>();
    }
}
