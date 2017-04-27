# unityroom-tweet

[ゲーム投稿サイト unityroom](http://unityroom.com/)専用、WebGLからツイートするためのサンプルコードです。

![スクリーンショット](https://cloud.githubusercontent.com/assets/7110482/25494678/65c266f2-2bb5-11e7-989d-dbceb2c2c15d.png)

[->デモ](https://unityroom.com/games/unityroom-tweet-sample/webgl)

# 使い方

1. 下記スクリプトを `Assets/` 以下に入れてください。

[UnityRoomTweet.cs](https://github.com/naichilab/unityroom-tweet/blob/master/Assets/naichilab/unityroom-tweet/UnityRoomTweet.cs)

2. ツイートしたいタイミングで下記のように呼び出してください。

```.cs
//本文のみツイート
naichilab.UnityRoomTweet.Tweet ("[YOUR-GAMEID-HERE]", "ツイートサンプルです。");
//本文＋ハッシュタグツイート
naichilab.UnityRoomTweet.Tweet ("[YOUR-GAMEID-HERE]", "ツイートサンプルです。", "unityroom");
//本文＋ハッシュタグ＊２ツイート
naichilab.UnityRoomTweet.Tweet ("[YOUR-GAMEID-HERE]", "ツイートサンプルです。", "unityroom", "unity1week");
```

`[YOUR-GAMEID-HERE]` の部分には、ゲーム固有のIDが入ります。
unityroom上でゲームを新規作成し(タイトル登録のみで構いません)、
ゲーム設定画面から `その他` の設定画面を開くと確認できます。

![ゲーム設定画面](https://cloud.githubusercontent.com/assets/7110482/25494312/3cbe7882-2bb4-11e7-8d49-b54ae23ba2e5.png)
		
