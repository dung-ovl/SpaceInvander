using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipSelectMenuManager : MenuController
{
    protected override void LoadMenuType()
    {
        this.menuType = Menu.SHIP_SELECTION;
    }

    public void OnShipSelected(int shipIndex)
    {
        /*GameManager.Instance.SetShipIndex(shipIndex);
        GameManager.Instance.StartGame();*/
    }
    public void OnBackButtonPressed()
    {
        MenuManager.Instance.SwitchCanvas(Menu.MAIN_MENU);
    }
}
