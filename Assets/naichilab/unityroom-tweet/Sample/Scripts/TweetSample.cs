using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace naichilab
{
	public class TweetSample : MonoBehaviour
	{
		public void Tweet (string text)
		{
			naichilab.UnityRoomTweet.Tweet ("unityroom-tweet-sample", "ツイートサンプルです。");
		}

		public void TweetWithHashtag ()
		{
			naichilab.UnityRoomTweet.Tweet ("unityroom-tweet-sample", "ツイートサンプルです。", "unityroom");
		}

		public void TweetWithHashtags ()
		{
			naichilab.UnityRoomTweet.Tweet ("unityroom-tweet-sample", "ツイートサンプルです。", "unityroom", "unity1week");
		}
	}
}
