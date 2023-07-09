using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyShootingBullet2 : EnemyShootingBullet
{
    protected float angleStep = 10;
    protected List<float> angle;

    [SerializeField] private float amount = 1;
    protected override void Start()
    {
        base.Start();
        angle = new List<float>();
        for (int i = 0; i < amount; i++)
        {
            angle.Add((360 / amount) * i);
        }
    }
    protected override void Shooting()
    {
        shootTimer += Time.deltaTime;
        if (shootTimer < shootDelay) return;
        shootTimer = 0f;

        for (int i = 0; i < amount; i++)
        {
            float rot = CalculateRot(angle[i]);

            this.ShootingWithDirection(transform.parent.position, transform.parent.rotation * Quaternion.Euler(0, 0, rot));
            Debug.Log(angle[i]);
            angle[i] += angleStep;
            
        }
            
    }


}
