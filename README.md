# unityroom-tweet

[ゲーム投稿サイト unityroom](http://unityroom.com/)専用、WebGLからツイートするためのサンプルコードです。

![スクリーンショット](https://user-images.githubusercontent.com/7110482/45599527-0202db80-ba28-11e8-8fe6-1d37736f7926.png)

[-> 動作デモはこちら](https://unityroom.com/games/unityroom-tweet-sample)

# 使い方

1. [Releases](https://github.com/naichilab/unityroom-tweet/releases)ページから、`unityroom-tweet.unitypackage` をダウンロードします。（最新のものでOKです。下記画像は最新ではないです。）

![スクリーンショット](https://user-images.githubusercontent.com/7110482/45599551-7c336000-ba28-11e8-9edc-877b82a4fe34.png)

1. ダウンロードしたパッケージをunityにインポートします。（最新のものは下記画像とは若干違います。）

![スクリーンショット](https://user-images.githubusercontent.com/7110482/45599656-6b83e980-ba2a-11e8-8be8-00f99b48a55e.png)

> Sampleフォルダはお好みでどうぞ。

1. ツイートしたいタイミングで下記のように呼び出してください。

```.cs
//本文のみツイート（画像なし）
naichilab.UnityRoomTweet.Tweet ("YOUR-GAMEID", "ツイートサンプルです。");
//本文＋ハッシュタグツイート（画像なし）
naichilab.UnityRoomTweet.Tweet ("YOUR-GAMEID", "ツイートサンプルです。", "unityroom");
//本文＋ハッシュタグ＊２ツイート（画像なし）
naichilab.UnityRoomTweet.Tweet ("YOUR-GAMEID", "ツイートサンプルです。", "unityroom", "unity1week");
//本文のみツイート（画像あり）
// (unityroomでは2019/03現在エラーとなります。) naichilab.UnityRoomTweet.TweetWithImage ("YOUR-GAMEID", "ツイートサンプルです。");
//本文＋ハッシュタグツイート（画像あり）
// (unityroomでは2019/03現在エラーとなります。) naichilab.UnityRoomTweet.TweetWithImage ("YOUR-GAMEID", "ツイートサンプルです。", "unityroom");
//本文＋ハッシュタグ＊２ツイート（画像あり）
// (unityroomでは2019/03現在エラーとなります。) naichilab.UnityRoomTweet.TweetWithImage ("YOUR-GAMEID", "ツイートサンプルです。", "unityroom", "unity1week");
```

画像ツイートをするためには後述するGyazoアクセストークンの設定が必要です。

# 補足

### `YOUR-GAMEID` について

`YOUR-GAMEID` の部分には、ゲーム固有のIDが入ります。
unityroom上でゲームを新規作成し(タイトル登録のみで構いません)、
ゲーム設定画面から `その他` の設定画面を開くと確認できます。

![ゲーム設定画面](https://cloud.githubusercontent.com/assets/7110482/25494312/3cbe7882-2bb4-11e7-8d49-b54ae23ba2e5.png)

### Gyazoアクセストークンについて

> 2019/03追記 unityroomからGyazoへのアップロードが失敗するようになりました。（CORSによるエラー）
> 原因は確認中ですが、画像ツイートが必要な場合はImgur等、別の方法を使っていただくとよいかもしれません。
> 参考 ： https://github.com/ttyyamada/TweetWithScreenShotInWebGL

画像ありツイート(TweetWithImage)を行うためには、Gyazoのアクセストークンが必要です。

取得方法はこちら -> https://blog.naichilab.com/entry/gyazo-access-token

コピーしたトークンを、以下の要領で貼り付けてください。

1. Assets -> naichilab -> unityroom-tweet -> Resources -> `GyazoSetting.asset` を選択する。
1. インスペクタウィンドウで `Gyazo Access Token` に貼り付ける。

![スクリーンショット](https://user-images.githubusercontent.com/7110482/45599644-295aa800-ba2a-11e8-8238-7aa153ba1467.png)

### 画像ツイートについて

`TweetWithImage` は、初心者の方でもとにかく簡単に使えるよう、スクリーンショットの取得や画像のアップロード処理を隠蔽しています。
そのため、ユーザーがツイートボタンを押した瞬間の画面がキャプチャされ、アップロード＆ツイートされます。

ゲームによってはゲームオーバーの瞬間に画像を撮影しておき、ツイートするタイミングとはずらしたい場合もあるかと思います。
その場合は、`TweetWithImage` の中身を参考にしていただき、改変してお使いください。

### 細かい補足

スクリプト内で呼びだしているtwitterのURLは、本来ブラウザから自動で取得されるのですが、unityroomはiframeを使っている関係でうまく動きません。
そのため苦肉の策としてGameIDを使ってスクリプト内でURLを構築して明示的に渡す形にしています。
