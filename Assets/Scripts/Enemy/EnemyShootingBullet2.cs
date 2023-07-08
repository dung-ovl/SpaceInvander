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
    protected override void Shooting()
    {
        shootTimer += Time.deltaTime;
        if (shootTimer < shootDelay) return;
        shootTimer = 0f;

        float rot = CalculateRot(startAngle);

        this.ShootingWithDirection(transform.parent.position, transform.parent.rotation * Quaternion.Euler(0, 0, rot));

        startAngle += angleStep;
    }


}
