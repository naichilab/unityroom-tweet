using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace naichilab
{
	public class TweetSample : MonoBehaviour
	{
		public void Tweet (string text)
		{
			naichilab.UnityRoomTweet.Tweet ("ツイートサンプルです。");
		}

		public void TweetWithHashtag ()
		{
			naichilab.UnityRoomTweet.Tweet ("ツイートサンプルです。", "unityroom");
		}

		public void TweetWithHashtags ()
		{
			naichilab.UnityRoomTweet.Tweet ("ツイートサンプルです。", "unityroom", "unity1week");
		}

	}
}
