/*************************************************************************
 *  Copyright (C) 2024 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  DSettingsUI.cs
 *  Description  :  Null.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0.0
 *  Date         :  2024/7/24
 *  Description  :  Initial development version.
 *************************************************************************/

using MGS.UI.Widget;
using UnityEngine;

namespace MGS.App
{
    public class SettingsData
    {

    }

    public class DSettingsUI : UIRespondable<SettingsData>
    {
        protected override void OnRefresh(SettingsData data)
        {
            //TODO...
            Debug.LogWarning("DSettingsUI.OnRefresh is not implemented.");
        }
    }
}