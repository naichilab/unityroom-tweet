# unityroom-tweet

[ゲーム投稿サイト unityroom](http://unityroom.com/)専用、WebGLからツイートするためのサンプルコードです。

![スクリーンショット](https://cloud.githubusercontent.com/assets/7110482/25494678/65c266f2-2bb5-11e7-989d-dbceb2c2c15d.png)

[->デモ](https://unityroom.com/games/unityroom-tweet-sample/webgl)

# 使い方

1. [Releases](https://github.com/naichilab/unityroom-tweet/releases)ページから、`unityroom-tweet.unitypackage` をダウンロードします。

![2017-12-19 1 59 19](https://user-images.githubusercontent.com/7110482/34117857-48c3d248-e460-11e7-9d54-3633fbc851f6.png)

1. ダウンロードしたパッケージをunityにインポートします。

![2017-12-19 2 00 38](https://user-images.githubusercontent.com/7110482/34117886-6e7120b8-e460-11e7-820a-db1e840016ad.png)

> Sampleフォルダはお好みでどうぞ。

1. ツイートしたいタイミングで下記のように呼び出してください。

```.cs
//本文のみツイート
naichilab.UnityRoomTweet.Tweet ("YOUR-GAMEID", "ツイートサンプルです。");
//本文＋ハッシュタグツイート
naichilab.UnityRoomTweet.Tweet ("YOUR-GAMEID", "ツイートサンプルです。", "unityroom");
//本文＋ハッシュタグ＊２ツイート
naichilab.UnityRoomTweet.Tweet ("YOUR-GAMEID", "ツイートサンプルです。", "unityroom", "unity1week");
```

`YOUR-GAMEID` の部分には、ゲーム固有のIDが入ります。
unityroom上でゲームを新規作成し(タイトル登録のみで構いません)、
ゲーム設定画面から `その他` の設定画面を開くと確認できます。

![ゲーム設定画面](https://cloud.githubusercontent.com/assets/7110482/25494312/3cbe7882-2bb4-11e7-8d49-b54ae23ba2e5.png)
		
# 補足
スクリプト内で呼びだしているtwitterのURLは、本来ブラウザから自動で取得されるのですが、unityroomはiframeを使っている関係でうまく動きません。
そのため苦肉の策としてGameIDを使ってスクリプト内でURLを構築して明示的に渡す形にしています。
