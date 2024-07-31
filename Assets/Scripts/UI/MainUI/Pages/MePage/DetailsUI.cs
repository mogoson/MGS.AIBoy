/*************************************************************************
 *  Copyright (C) 2024 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  DetailsUI.cs
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
    public class DetailsUI : UIRefreshable<UserData>
    {
        public event Action<UserData> OnAccountDirtyEvent;
        public event Action<SettingsData> OnSettingsDirtyEvent;

        public DAccountUI accountUI;
        public DSettingsUI settingsUI;
        public DAgreementUI agreementUI;
        public DAboutUI aboutUI;
        public Button btnBack;
        public Text txtTittle;

        protected virtual void Awake()
        {
            accountUI.OnDirtyEvent += data => OnAccountDirtyEvent?.Invoke(data);
            settingsUI.OnDirtyEvent += data => OnSettingsDirtyEvent?.Invoke(data);
            btnBack.onClick.AddListener(() => SetActive(false));
        }

        protected override void OnRefresh(UserData data)
        {
            accountUI.Refresh(data);
        }

        public void SetActive(string optName)
        {
            txtTittle.text = optName;
            accountUI.SetActive(accountUI.name == optName);
            settingsUI.SetActive(settingsUI.name == optName);
            agreementUI.SetActive(agreementUI.name == optName);
            aboutUI.SetActive(aboutUI.name == optName);
            SetActive();
        }

        public void Refresh(SettingsData data)
        {
            settingsUI.Refresh(data);
        }

        public void Refresh(string agreement, string about)
        {
            agreementUI.Refresh(agreement);
            aboutUI.Refresh(about);
        }
    }
}