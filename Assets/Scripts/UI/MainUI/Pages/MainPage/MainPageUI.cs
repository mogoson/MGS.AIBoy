/*************************************************************************
 *  Copyright (C) 2024 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  MainPageUI.cs
 *  Description  :  Default.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0.0
 *  Date         :  2024/7/29
 *  Description  :  Initial development version.
 *************************************************************************/

using MGS.QianWen.UI;
using MGS.UI.Widget;

namespace MGS.App
{
    public class MainPageUI : UIRefreshable<UserData>
    {
        public TextDialogWnd dialogWnd;

        protected override void OnRefresh(UserData option)
        {

        }
    }
}