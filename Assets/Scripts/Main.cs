/*************************************************************************
 *  Copyright (C) 2024 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  Main.cs
 *  Description  :  Null.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0.0
 *  Date         :  2024/7/29
 *  Description  :  Initial development version.
 *************************************************************************/

using UnityEngine;

namespace MGS.App
{
    public class Main : MonoBehaviour
    {
        LoginCpnt loginCpnt;
        MainCpnt mainCpnt;

        private void Awake()
        {
            DontDestroyOnLoad(gameObject);
        }

        private void Start()
        {
            loginCpnt = new LoginCpnt();
            loginCpnt.onLogined += OnLogined;

            mainCpnt = new MainCpnt();
            mainCpnt.OnLogOutEvent += OnLogOut;

            loginCpnt.LogIn();
        }

        private void OnLogined(UserData data)
        {
            mainCpnt.LogIn(data);
        }

        private void OnLogOut(UserData data)
        {
            loginCpnt.LogOut();
            loginCpnt.LogIn(data);
        }
    }
}