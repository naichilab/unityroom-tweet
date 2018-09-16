using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

namespace naichilab.Scripts.Internal
{
    public static class GyazoUploader
    {
        private const string GyazoUploadUrl = "https://upload.gyazo.com/api/upload";
        private static GyazoSetting _setting;

        static GyazoUploader()
        {
            if (_setting == null)
            {
                _setting = Resources.Load<GyazoSetting>("GyazoSetting");
                if (_setting == null)
                {
                    Debug.LogError("Resources/GyazoSettingが見つかりませんでした。");
                }

                if (string.IsNullOrEmpty(_setting.GyazoAccessToken))
                {
                    Debug.LogError("Resources/GyazoSettingにAccessTokenが設定されていません。");
                }
            }
        }

        public static IEnumerator CaptureScreenshotAndUpload(
            string title = null
            , string desc = null
            , Action<GyazoResponse, string> callback = null)
        {
            yield return new WaitForEndOfFrame();
            var tex = ScreenCapture.CaptureScreenshotAsTexture();
            byte[] jpgBytes = tex.EncodeToJPG();

            var form = new WWWForm();
            form.AddField("access_token", _setting.GyazoAccessToken);
            form.AddBinaryData("imagedata", jpgBytes, "screenshot.jpg", System.Net.Mime.MediaTypeNames.Image.Jpeg);
            if (!string.IsNullOrEmpty(title)) form.AddField("title", title);
            if (!string.IsNullOrEmpty(desc)) form.AddField("desc", desc);

            string error;
            GyazoResponse res = null;
            using (var request = UnityWebRequest.Post(GyazoUploadUrl, form))
            {
                yield return request.SendWebRequest();
                error = request.error;
                if (request.responseCode == 200)
                {
                    res = JsonUtility.FromJson<GyazoResponse>(request.downloadHandler.text);
                }
            }

            if (callback != null)
            {
                callback(res, error);
            }
        }
    }
}