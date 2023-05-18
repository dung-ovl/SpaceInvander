using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossUIHealthBar : UIHealthBar
{
    private static BossUIHealthBar instance;

    public static BossUIHealthBar Instance => instance;

    protected override void Awake()
    {
        base.Awake();
        BossUIHealthBar.instance = this;
    }
}
