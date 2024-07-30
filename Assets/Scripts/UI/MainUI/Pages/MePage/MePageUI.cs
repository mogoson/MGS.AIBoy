/*************************************************************************
 *  Copyright (C) 2024 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  MePageUI.cs
 *  Description  :  Null.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0.0
 *  Date         :  2024/7/24
 *  Description  :  Initial development version.
 *************************************************************************/

using System;
using MGS.UI.Widget;
using UnityEngine.UI;

namespace MGS.App
{
    public class MePageUI : UIRefreshable<UserData>
    {
        public event Action<UserData> OnAccountDirtyEvent;
        public event Action<SettingsData> OnSettingsDirtyEvent;
        public event Action<UserData> OnLogOutEvent;

        public Text txtAppName;
        public OptionsUI optionsUI;

        protected void Awake()
        {
            optionsUI.OnAccountDirtyEvent += data => OnAccountDirtyEvent?.Invoke(data);
            optionsUI.OnSettingsDirtyEvent += data => OnSettingsDirtyEvent?.Invoke(data);
            optionsUI.OnLogOutEvent += data => OnLogOutEvent?.Invoke(data);
        }

        protected override void OnRefresh(UserData data)
        {
            optionsUI.Refresh(data);
        }

        public void Refresh(AppInfo appInfo)
        {
            txtAppName.text = appInfo.appName;
        }

        public void Refresh(SettingsData data)
        {
            optionsUI.Refresh(data);
        }

        public void Refresh(string agreement, string about)
        {
            optionsUI.Refresh(agreement, about);
        }
    }
}