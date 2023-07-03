using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuManager : MenuController
{
    protected override void LoadMenuType()
    {
        this.menuType = Menu.MAIN_MENU;
    }
}
