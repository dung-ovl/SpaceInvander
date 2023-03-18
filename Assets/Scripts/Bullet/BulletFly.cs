using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFly : Flyable
{
    protected override void ResetValue()
    {
        base.ResetValue();
        this.moveSpeed = 2f;
    }
}
