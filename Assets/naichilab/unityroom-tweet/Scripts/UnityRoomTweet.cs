using System.Runtime.InteropServices;
using naichilab.Scripts.Internal;
using UnityEngine;

namespace naichilab
{
    public static class UnityRoomTweet
    {
        [DllImport("__Internal")]
        private static extern void OpenWindow(string url);

        private static YieldInstruction _currentCoroutine = null;

        public static void Tweet(string gameId, string text, params string[] hashTags)
        {
            var tweetData = new TweetData(gameId, text, hashTags);
            Tweet(tweetData);
        }


        public static void TweetWithImage(string gameId, string text, params string[] hashTags)
        {
            if (_currentCoroutine != null)
            {
                Debug.Log("画像アップロード中に多重呼び出しされました。");
                return;
            }

            var tweetData = new TweetData(gameId, text, hashTags);

            var title = tweetData.GameUrl;
            var desc = text;
            _currentCoroutine = CoroutineHandler.StartStaticCoroutine(
                GyazoUploader.CaptureScreenshotAndUpload(
                    title
                    , desc
                    , (res, error) =>
                    {
                        if (string.IsNullOrEmpty(error))
                        {
                            Debug.Log("画像アップロード成功 : " + res.permalink_url);
                            //エラーなし => ツイートする
                            tweetData.ImageUrl = res.permalink_url;
                            Tweet(tweetData);
                        }
                        else
                        {
                            //エラーあり
                            Debug.LogError("画像アップロード失敗 : " + error);
                        }

                        _currentCoroutine = null;
                    }));
        }

        public static void Tweet(ITweetData data)
        {
            Tweet(data.GetShareUrl());
        }

        private static void Tweet(string tweetUrl)
        {
            if (Application.platform == RuntimePlatform.WebGLPlayer)
            {
#if UNITY_2017_2_OR_NEWER
                OpenWindow(tweetUrl);
#else
				Application.ExternalEval ("var F = 0;if (screen.height > 500) {F = Math.round((screen.height / 2) - (250));}window.open('" + tweetUrl + "','intent','left='+Math.round((screen.width/2)-(250))+',top='+F+',width=500,height=260,personalbar=no,toolbar=no,resizable=no,scrollbars=yes');");
#endif
            }
            else
            {
#if UNITY_EDITOR
                //URLを実行する（自動的にブラウザで開かれるはず）
                System.Diagnostics.Process.Start(tweetUrl);
#else
				Debug.Log ("WebGL以外では実行できません。");
				Debug.Log (tweetUrl);
#endif
            }
        }
    }
}