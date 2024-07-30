/*************************************************************************
 *  Copyright (C) 2024 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  OptionsUI.cs
 *  Description  :  Default.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0.0
 *  Date         :  2024/7/29
 *  Description  :  Initial development version.
 *************************************************************************/

using System;
using MGS.UI.Widget;
using UnityEngine.UI;

namespace MGS.App
{
    public class OptionsUI : UIRefreshable<UserData>
    {
        public event Action<UserData> OnAccountDirtyEvent;
        public event Action<SettingsData> OnSettingsDirtyEvent;
        public event Action<UserData> OnLogOutEvent;

        public Button btnAccount;
        public Button btnSettins;
        public Button btnAgreement;
        public Button btnAbout;
        public Button logOut;
        public DetailsUI detailsUI;

        private void Awake()
        {
            btnAccount.onClick.AddListener(() => detailsUI.SetActive(typeof(DAccountUI)));
            btnSettins.onClick.AddListener(() => detailsUI.SetActive(typeof(DSettingsUI)));
            btnAgreement.onClick.AddListener(() => detailsUI.SetActive(typeof(DAgreementUI)));
            btnAbout.onClick.AddListener(() => detailsUI.SetActive(typeof(DAboutUI)));
            logOut.onClick.AddListener(() => OnLogOutEvent?.Invoke(Option));

            detailsUI.OnAccountDirtyEvent += data => OnAccountDirtyEvent?.Invoke(data);
            detailsUI.OnSettingsDirtyEvent += data => OnSettingsDirtyEvent?.Invoke(data);
        }

        protected override void OnRefresh(UserData option)
        {
            detailsUI.Refresh(option);
        }

        public void Refresh(SettingsData data)
        {
            detailsUI.Refresh(data);
        }

        public void Refresh(string agreement, string about)
        {
            detailsUI.Refresh(agreement, about);
        }
    }
}