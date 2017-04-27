# unityroom-tweet
WebGLからツイートするサンプル

# 使い方

1. 下記スクリプトを `Assets/` 以下に入れてください。

[UnityRoomTweet.cs](https://github.com/naichilab/unityroom-tweet/blob/master/Assets/naichilab/unityroom-tweet/UnityRoomTweet.cs)

2. ツイートしたいタイミングで下記のように呼び出してください。

```.cs
//本文のみツイート
naichilab.UnityRoomTweet.Tweet ("ツイートサンプルです。");
//本文＋ハッシュタグツイート
naichilab.UnityRoomTweet.Tweet ("ツイートサンプルです。", "unityroom");
//本文＋ハッシュタグ＊２ツイート
naichilab.UnityRoomTweet.Tweet ("ツイートサンプルです。", "unityroom", "unity1week");
```



