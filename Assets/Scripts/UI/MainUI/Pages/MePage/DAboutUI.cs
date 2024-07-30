/*************************************************************************
 *  Copyright (C) 2024 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  DAboutUI.cs
 *  Description  :  Null.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0.0
 *  Date         :  2024/7/24
 *  Description  :  Initial development version.
 *************************************************************************/

using MGS.UI.Widget;
using UnityEngine.UI;

namespace MGS.App
{
    public class DAboutUI : UIRefreshable<string>
    {
        public Text text;

        protected override void OnRefresh(string data)
        {
            text.text = data;
        }
    }
}