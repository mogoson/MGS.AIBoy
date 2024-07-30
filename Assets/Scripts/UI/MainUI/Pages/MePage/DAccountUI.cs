/*************************************************************************
 *  Copyright (C) 2024 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  DAccountUI.cs
 *  Description  :  Default.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0.0
 *  Date         :  2024/7/29
 *  Description  :  Initial development version.
 *************************************************************************/

using MGS.UI.Widget;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace MGS.App
{
    public class DAccountUI : UIRespondable<UserData>
    {
        public InputField iptUser;
        public InputField iptPassword;
        public UIPointerListener listener;

        private void Awake()
        {
            listener.OnPointerClickEvent += Listener_OnPointerClickEvent;
        }

        private void Listener_OnPointerClickEvent(PointerEventData data)
        {
            OnRefresh(new UserData());
            if (iptPassword.contentType == InputField.ContentType.Password)
            {
                iptPassword.contentType = InputField.ContentType.Standard;
            }
            else if (iptPassword.contentType == InputField.ContentType.Standard)
            {
                iptPassword.contentType = InputField.ContentType.Password;
            }
            OnRefresh(Option);
        }

        protected override void OnRefresh(UserData option)
        {
            iptUser.text = option.userName;
            iptPassword.text = option.appKey;
        }
    }
}