using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flyable : GameMonoBehaviour
{
    [SerializeField] protected float moveSpeed = 1f;
    [SerializeField] protected Vector3 direction = Vector3.up;

    void Update()
    {
        this.Fly();
    }

    protected virtual void Fly()
    {
        transform.parent.Translate(this.direction * this.moveSpeed * Time.deltaTime);
    }
}
