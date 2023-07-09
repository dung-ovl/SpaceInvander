using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnMainMenu : BaseButton
{
    protected override void OnClick()
    {
        MenuManager.Instance.SwitchCanvas(Menu.MAIN_MENU);
    }
}
