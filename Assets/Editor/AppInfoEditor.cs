/*************************************************************************
 *  Copyright (C) 2024 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  AppInfoEditor.cs
 *  Description  :  Default.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0.0
 *  Date         :  2024/7/29
 *  Description  :  Initial development version.
 *************************************************************************/

using System;
using System.IO;
using Newtonsoft.Json;
using UnityEditor;
using UnityEngine;

namespace MGS.App.Editors
{
    public class AppInfoEditor
    {
        [MenuItem("Tool/App/Generate Config")]
        static void GenerateConfig()
        {
            var dir = $"{Application.streamingAssetsPath}/Config";
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }
            var appInfo = new AppInfo()
            {
                appName = PlayerSettings.productName,
                version = PlayerSettings.bundleVersion,
                lastUpdated = DateTime.Now.ToShortDateString(),
                developer = PlayerSettings.companyName,
                contact = "mogoson@outlook.com",
                copyright = $"Copyright (C) {DateTime.Now.Year} {PlayerSettings.companyName}. All rights reserved.",
            };
            GenerateAppInfo(appInfo);
            GenerateAgreement(appInfo);
            AssetDatabase.Refresh();
        }

        static void GenerateAppInfo(AppInfo info)
        {
            var json = JsonConvert.SerializeObject(info);
            var file = $"{Application.streamingAssetsPath}/Config/AppInfo";
            File.WriteAllText(file, json);
        }

        static void GenerateAgreement(AppInfo info)
        {
            var temp = $"{Application.dataPath}/Editor/User Agreement";
            var content = File.ReadAllText(temp);
            content = content.Replace("{App Name}", info.appName);
            content = content.Replace("{Last Updated}", DateTime.Now.ToShortDateString());
            content = content.Replace("{Developer}", info.developer);
            content = content.Replace("{Contact}", info.contact);
            var file = $"{Application.streamingAssetsPath}/Config/User Agreement";
            File.WriteAllText(file, content);
        }
    }
}