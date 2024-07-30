/*************************************************************************
 *  Copyright (C) 2024 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  MainUI.cs
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
    public class MainUI : UIRefreshable<UserData>
    {
        public MainPageUI mainPageUI;
        public MePageUI mePageUI;
        public Button btnMe;

        private void Awake()
        {
            btnMe.onClick.AddListener(() => mePageUI.SetActive(!mePageUI.gameObject.activeSelf));
        }

        protected override void OnRefresh(UserData option)
        {
            mainPageUI.Refresh(option);
            mePageUI.Refresh(option);
        }
    }
}