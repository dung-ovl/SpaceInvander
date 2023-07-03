using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnSelectShip : BaseButton
{
    protected override void OnClick()
    {
        ShipSelection.Instance.SelectShip();
    }

}
