using System.Text;
using System.Linq;
using UnityEngine;

namespace naichilab
{
	public static class UnityRoomTweet
	{
		/// <summary>
		/// ツイートします。
		/// </summary>
		/// <param name="text">本文</param>
		/// <param name="hashtag">ハッシュタグ(#は不要) 複数指定可</param>
		public static void Tweet (string text, params string[] hashtags)
		{
			const string SHAREURL = "http://twitter.com/share?";

			var sb = new StringBuilder ();
			sb.Append (SHAREURL);
			sb.Append ("original_referer=");
			sb.Append ("&text=" + WWW.EscapeURL (text));
			if (hashtags.Any ()) {
				sb.Append ("&hashtags=" + WWW.EscapeURL (string.Join (",", hashtags)));
			}

			if (Application.platform == RuntimePlatform.WebGLPlayer) {
				Application.ExternalEval ("var F = 0;if (screen.height > 500) {F = Math.round((screen.height / 2) - (250));}window.open('" + sb.ToString () + "','intent','left='+Math.round((screen.width/2)-(250))+',top='+F+',width=500,height=260,personalbar=no,toolbar=no,resizable=no,scrollbars=yes');");
			} else {
				Debug.Log ("WebGL以外では実行できません。");
				Debug.Log (sb.ToString ());
			}
		}
	}
}