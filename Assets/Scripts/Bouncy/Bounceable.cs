using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class Bounceable : GameMonoBehaviour
{
    [SerializeField] protected CircleCollider2D circleCollider2;
    public CircleCollider2D CircleCollider2 { get => circleCollider2; set => circleCollider2 = value; }

    public Vector3 startPos = new Vector3();
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadCircleCollider();
    }

    protected virtual void LoadCircleCollider()
    {
        if (this.circleCollider2 != null) return;
        this.circleCollider2 = GetComponent<CircleCollider2D>();
        this.circleCollider2.radius = 0.1f;
        Debug.Log(transform.name + ": LoadCircleCollider", gameObject);
    }

    protected virtual void OnTriggerEnter2D(Collider2D collider2D)
    {
        Left left = collider2D.GetComponent<Left>();
        Right right = collider2D.GetComponent<Right>();
        if (left != null)
        {
            Vector3 vecStart = transform.parent.position - startPos;
            Vector3 res = Vector3.Reflect(vecStart, Vector3.right);
            res = -res;
            res.Normalize();
            float rot_z = Mathf.Atan2(res.y, res.x) * Mathf.Rad2Deg;
            Debug.Log("Left " + rot_z);
            if (res.x > 0)
            {
                transform.parent.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);
            }
            else
            {
                transform.parent.rotation = Quaternion.Euler(0f, 0f, rot_z + 90);
            }
            startPos = transform.parent.position;
        }
        else if (right != null)
        {
            Vector3 vecStart = transform.parent.position - startPos;
            Vector3 res = Vector3.Reflect(vecStart, Vector3.left);
            Debug.Log(res.x + " " + res.y);
            float rot_z = Mathf.Atan(res.y / res.x) * Mathf.Rad2Deg;
            Debug.Log("Right " + rot_z);
            if (res.x > 0)
            {
                transform.parent.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);
            }
            else
            {
                transform.parent.rotation = Quaternion.Euler(0f, 0f, rot_z + 90);
            }
            startPos = transform.parent.position;
        }
    }
}
