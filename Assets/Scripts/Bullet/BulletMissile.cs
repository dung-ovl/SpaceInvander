using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMissile : GameMonoBehaviour
{
    public Transform target;
    public float time;
    bool iss = true;
    public float rotSpeed = 3f;
    public bool isTarget = false;

    [SerializeField] protected Transform spawnMis;
    public Transform spawnMissile => spawnMis;

    protected override void Start()
    {
        base.Start();
    }

    protected override void OnEnable()
    {
        base.OnEnable();
        time = 0;
        rotSpeed = 7f;
        isTarget = false;

        Invoke("SetIsTarget", 1);
    }

    protected virtual void FixedUpdate()
    {
        try
        {
            target = GameObject.FindGameObjectWithTag("EnemyTarget").transform;
        }
        catch 
        {
            return;
        }
        {
            LookAtTarget();
        }
    }

    protected virtual void LookAtTarget()
    {
        if (isTarget)
        {
            Vector3 diff = this.target.position - transform.parent.position;
            diff.Normalize();
            float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;

            float timeSpeed = this.rotSpeed * Time.fixedDeltaTime;
            Quaternion targetEuler = Quaternion.Euler(0f, 0f, rot_z - 90);
            Quaternion currentEuler = Quaternion.Lerp(transform.parent.rotation, targetEuler, timeSpeed);
            transform.parent.rotation = currentEuler;
        }
    }

    protected virtual void SetIsTarget()
    {
        isTarget = true;
    }
}
