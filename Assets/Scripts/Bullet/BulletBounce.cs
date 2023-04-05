using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBounce : GameMonoBehaviour
{
    [SerializeField] protected Rigidbody2D rigidbody2D;

    protected Vector2 last;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadRB();
    }

    protected virtual void LoadRB()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        Debug.Log("Load OK");
    }

    protected virtual void Update()
    {
        last = rigidbody2D.velocity;
    }

    protected virtual void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("OK ");
        var speed = last.magnitude;
        var dir = Vector3.Reflect(last.normalized, collision.contacts[0].normal);
        rigidbody2D.velocity = dir * Mathf.Max(speed, 0f);
    }
}
