/*************************************************************************
 *  Copyright (C) 2024 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  Config.cs
 *  Description  :  Null.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0.0
 *  Date         :  2024/7/24
 *  Description  :  Initial development version.
 *************************************************************************/

using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.Networking;

namespace MGS.App
{
    public sealed class Config
    {
        public static AppInfo LoadAppInfo()
        {
            var file = $"{Application.streamingAssetsPath}/Config/AppInfo";
            return Load<AppInfo>(file);
        }

        public static string LoadAgreement()
        {
            var file = $"{Application.streamingAssetsPath}/Config/User Agreement";
            return Load(file);
        }

        public static T Load<T>(string file)
        {
            var content = Load(file);
            return JsonConvert.DeserializeObject<T>(content);
        }

        public static string Load(string file)
        {
            using (var request = UnityWebRequest.Get(file))
            {
                var operate = request.SendWebRequest();
                while (!operate.isDone) { }
                return request.downloadHandler.text;
            }
        }
    }
}