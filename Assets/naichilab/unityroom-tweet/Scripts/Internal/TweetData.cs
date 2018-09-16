using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace naichilab.Scripts.Internal
{
    public class TweetData : ITweetData
    {
        const string ShareUrl = "http://twitter.com/share?";
        private const string GameUrlBase = "https://unityroom.com/games/{0}";

        public string GameId { get; private set; }
        public string Text { get; private set; }
        public IEnumerable<string> HashTags { get; private set; }
        public string ImageUrl { get; set; }

        public TweetData(string gameId, string text, params string[] hashTags)
        {
            if (string.IsNullOrEmpty(gameId)) throw new ArgumentNullException("gameId", "gameIdは必須です。");
            if (string.IsNullOrEmpty(text)) throw new ArgumentNullException("text", "textは必須です。");
            GameId = gameId;
            Text = text;
            HashTags = hashTags.ToList();
        }

        private bool HasImageUrl
        {
            get { return !string.IsNullOrEmpty(ImageUrl); }
        }

        public string GameUrl
        {
            get { return string.Format(GameUrlBase, GameId); }
        }


        public string GetShareUrl()
        {
            //画像付きツイートの場合はゲームURLと画像URLを持つことになる。
            //TwitterCardとして表示させるために、画像URLをメインのURLとして利用する。
            var url = HasImageUrl ? ImageUrl : GameUrl;
            //画像ツイートの場合はゲームURLをテキストに含む
            var text = HasImageUrl ? (Text + " " + GameUrl) : Text;

            var sb = new StringBuilder();
            sb.Append(ShareUrl);
            sb.Append("&url=" + WWW.EscapeURL(url));
            sb.Append("&text=" + WWW.EscapeURL(text));
            if (HashTags.Any())
            {
                var hashTagText = string.Join(",", HashTags.ToArray());
                sb.Append("&hashtags=" + WWW.EscapeURL(hashTagText));
            }

            return sb.ToString();
        }
    }
}