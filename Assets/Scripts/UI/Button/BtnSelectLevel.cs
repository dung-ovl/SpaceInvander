using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnSelectLevel : BaseButton
{
    protected override void OnClick()
    {
        MenuManager.Instance.SwitchCanvas(Menu.LEVEL_SELECT);
    }
}
