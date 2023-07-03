using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnSelectShipLeft : BaseButton
{
    protected override void OnClick()
    {
        ShipSelection.Instance.PreviousShip();
    }
}
