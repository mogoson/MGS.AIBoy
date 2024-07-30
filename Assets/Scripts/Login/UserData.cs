/*************************************************************************
 *  Copyright (C) 2024 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  UserData.cs
 *  Description  :  Null.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0.0
 *  Date         :  2024/7/22
 *  Description  :  Initial development version.
 *************************************************************************/

using System;

namespace MGS.App
{
    [Serializable]
    public class UserData
    {
        public string userName;
        public string appKey;
        public bool isSignIn;

        public bool CheckValid()
        {
            return !(string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(appKey));
        }
    }
}