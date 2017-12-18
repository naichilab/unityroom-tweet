using System.Text;
using System.Linq;
using UnityEngine;
using System.Runtime.InteropServices;

namespace naichilab
{
	public static class UnityRoomTweet
	{
		[DllImport ("__Internal")]
		private static extern void OpenWindow (string url);

		const string GAMEURL = "https://unityroom.com/games/{0}";
		const string WEBGLURL = "https://unityroom.com/games/{0}/webgl";
		const string SHAREURL = "http://twitter.com/share?";

		/// <summary>
		/// ツイートします。
		/// </summary>
		/// <param name="gameId">unityroomゲーム登録時に設定した固有の文字列</param>
		/// <param name="text">本文</param>
		/// <param name="hashtag">ハッシュタグ(#は不要) 複数指定可</param>
		public static void Tweet (string gameId, string text, params string[] hashtags)
		{
			string gameUrl = string.Format (GAMEURL, gameId);
			string webglUrl = string.Format (WEBGLURL, gameId);

			var sb = new StringBuilder ();
			sb.Append (SHAREURL);
			sb.Append ("&url=" + WWW.EscapeURL (gameUrl));
			sb.Append ("&original_referer=" + WWW.EscapeURL (webglUrl));
			sb.Append ("&text=" + WWW.EscapeURL (text));
			if (hashtags.Any ()) {
				sb.Append ("&hashtags=" + WWW.EscapeURL (string.Join (",", hashtags)));
			}

			if (Application.platform == RuntimePlatform.WebGLPlayer) {
#if UNITY_2017_2_OR_NEWER
				OpenWindow (sb.ToString ());
#else
				Application.ExternalEval ("var F = 0;if (screen.height > 500) {F = Math.round((screen.height / 2) - (250));}window.open('" + sb.ToString () + "','intent','left='+Math.round((screen.width/2)-(250))+',top='+F+',width=500,height=260,personalbar=no,toolbar=no,resizable=no,scrollbars=yes');");
#endif
			} else {
#if UNITY_EDITOR
				//URLを実行する（自動的にブラウザで開かれるはず）
				System.Diagnostics.Process.Start (sb.ToString ());
#else
				Debug.Log ("WebGL以外では実行できません。");
				Debug.Log (sb.ToString ());
#endif
			}
		}
	}
}