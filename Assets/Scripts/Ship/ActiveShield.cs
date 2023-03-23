using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveShield : ShieldAbstract
{
    [SerializeField] protected float lifeTime = 5f;
    [SerializeField] protected bool isShield = false;
    protected virtual void FixedUpdate()
    {
        this.Shielding();
    }

    protected virtual void Shielding()
    {
        if (lifeTime <= 0)
        {
            DisableShield();
        }
        lifeTime -= Time.fixedDeltaTime;
    }

    public void Shield()
    {
       if (!isShield && lifeTime > 0)
       {
            this.ShieldCtrl.Model.gameObject.SetActive(true);
            isShield = true;
       }
    }

    public void DisableShield()
    {
        this.ShieldCtrl.Model.gameObject.SetActive(false);
        isShield = false;
    }

    public void SetLifeTime(float time)
    {
        lifeTime = time;
    }
}
