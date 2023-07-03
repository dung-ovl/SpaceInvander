using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelectMenuManager : MenuController
{
    protected override void LoadMenuType()
    {
        this.menuType = Menu.LEVEL_SELECT;
    }

}
