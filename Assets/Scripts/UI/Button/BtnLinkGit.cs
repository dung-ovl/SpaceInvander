using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnLinkGit : BaseButton
{
    protected override void OnClick()
    {
        Application.OpenURL("https://github.com/dung-ovl/SpaceInvanderUT2D");
    }
}
