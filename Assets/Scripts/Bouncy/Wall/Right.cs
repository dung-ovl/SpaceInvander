using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class Right : GameMonoBehaviour
{
    [Header("LeftWall")]
    [SerializeField] protected BoxCollider2D box;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadWall();
    }

    protected virtual void LoadWall()
    {
        box = GetComponent<BoxCollider2D>();
    }
}
