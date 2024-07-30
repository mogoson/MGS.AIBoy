/*************************************************************************
 *  Copyright (C) 2024 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  LoginUI.cs
 *  Description  :  Null.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0.0
 *  Date         :  2024/7/21
 *  Description  :  Initial development version.
 *************************************************************************/

using System;
using MGS.UI.Widget;
using UnityEngine;
using UnityEngine.UI;

namespace MGS.App
{
    public class LoginUI : UIRespondable<UserData>
    {
        public Text txtAppName;
        public InputField iptUser;
        public InputField iptPassword;
        public Button btnKeyHelp;
        public Toggle togAccept;
        public Button btnAgreement;
        public Button btnConfirm;
        public Text txtCopyright;
        public GameObject loading;

        [Space]
        public GameObject agreement;
        public Text txtAgreement;
        public Button btnBack;
        public Button btnAccept;

        public event Action OnKeyHelpEvent;

        protected virtual void Awake()
        {
            iptUser.onValueChanged.AddListener(text => { Option.userName = text; CheckInteractable(); });
            iptPassword.onValueChanged.AddListener(text => { Option.appKey = text; CheckInteractable(); });
            btnKeyHelp.onClick.AddListener(() => OnKeyHelpEvent?.Invoke());

            togAccept.onValueChanged.AddListener(accept => CheckInteractable());
            btnAgreement.onClick.AddListener(() => agreement.gameObject.SetActive(true));
            btnConfirm.onClick.AddListener(OnDirty);

            btnBack.onClick.AddListener(() => agreement.gameObject.SetActive(false));
            btnAccept.onClick.AddListener(() => { togAccept.isOn = true; agreement.gameObject.SetActive(false); });
        }

        protected void CheckInteractable()
        {
            btnConfirm.interactable = Option.CheckValid() && togAccept.isOn;
        }

        protected override void OnRefresh(UserData data)
        {
            iptUser.text = data.userName;
            iptPassword.text = data.appKey;
            CheckInteractable();
        }

        public void RefreshAppInfo(AppInfo appInfo)
        {
            txtAppName.text = appInfo.appName;
            txtCopyright.text = appInfo.copyright;
        }

        public void RefreshAgreement(string agreement)
        {
            txtAgreement.text = agreement;
        }

        public void ToggleLoading(bool isActive)
        {
            loading.SetActive(isActive);
        }
    }
}