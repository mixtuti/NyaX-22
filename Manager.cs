using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    public CountDownTimer cdt;

    [Header("次のシーン")] public SceneReference next_scene;

    // ゲームステート
    public enum GameState{
        Opening,
        Playing,
        Clear,
        Over
    }

    // 現在のゲーム進行状態
    public GameState currentState = GameState.Opening;
    // パネル
    private GameObject panel;
    // タイトル
    private GameObject title;
    // ラケット
    private GameObject racket;
    // ボール
    private GameObject ball;

    // テキスト
    private Text text;
    // ステージ
    public int stage = 1;

    // Use this for initialization
    void Start () {
        // Panelゲームオブジェクトを検索し取得する
        panel = GameObject.Find("Panel");       
        // Titleゲームオブジェクトを検索し取得する
        title = GameObject.Find("Title");       
        // ラケットゲームオブジェクトを検索し取得する
        racket = GameObject.Find("Racket");     
        // ボールゲームオブジェクトを検索し取得する
        ball = GameObject.Find("Ball");
        // テキスト
        text = title.GetComponent<Text> ();

        // オープニング
        GameOpening ();
    }

    // Update is called once per frame
    void Update () {
        // ゲーム中ではなく、Spaceキーが押されたらtrueを返す。
        if(currentState == GameState.Opening && Input.GetKeyDown (KeyCode.Space)) {
            dispatch (GameState.Playing);                   
        }

        if (currentState == GameState.Playing) {
            // ゲームクリアーの判定
            if (GameObject.FindGameObjectsWithTag ("Block").Length == 0) {
                dispatch (GameState.Clear);
            }
        }

        if(Input.GetKey (KeyCode.R)){
            SceneManager.LoadScene (SceneManager.GetActiveScene().name);
        }
    }

    // 状態による振り分け処理
    public void dispatch (GameState state){
        GameState oldState = currentState;

        currentState = state;
        switch (state) {
            case GameState.Opening:
                GameOpening ();
                break;
            case GameState.Playing:
                GameStart ();
                break;
            case GameState.Clear :
                GameClear ();
                break;
            case GameState.Over:
                if (oldState == GameState.Playing) {
                    GameOver ();
                }
                break;
        }

    }

    // オープニング処理
    void GameOpening ()
    {
        currentState = GameState.Opening;

        // タイトル名のセット
        SetTitle ("Game Start", Color.green);

        // ボールの動作停止
        Time.timeScale = 0;

        // ラケットの初期位置をセット
        racket.transform.position = new Vector3 (0.0f, 0.0f, -8.5f);
        // ボールの初期位置をセット
        ball.transform.position = new Vector3 (0.0f, 0.0f, -7.5f);

        // ステージ作成
        FindObjectOfType<BlockMap>().CreateStage(stage);

        cdt.InitTimer();
    }

    // ゲームクリアー処理
    void GameClear ()
    {
        // ステージ最大数の取得
        int stageMax = FindObjectOfType<BlockMap> ().GetStageMax();

        // 次のステージへ
        stage++;
        if (stage > stageMax) {

            // タイトル名のセット
            SetTitle ("Game Clear", Color.yellow);
            // ステージ初期値
            stage = 1;
        } 
        else {
            // タイトル名のセット
            SetTitle (string.Format("Stage {0} Clear", stage -1) , Color.yellow);
        }
        //3秒後にオープニング処理を呼び出す
        Invoke ("GameOpening", 1f);
    }

    // ゲームスタート処理
    void GameStart ()
    {
        // パネル非活性化
        panel.SetActive (false);

        // ボールの動作開始
        Time.timeScale = 1.0f;

        // ボールの初期化
        FindObjectOfType<Ball> ().Init ();
    }

    // ゲームオーバー処理
    public void GameOver ()
    {
        // タイトル名のセット
        SetTitle ("Game Over", Color.red);
        // ステージ初期値
        stage = 1;

        // ハイスコアの保存
        FindObjectOfType<Score> ().Save();

        // 3秒後にオープニング処理を呼び出す
        Invoke("ToTitle", 3f);
    }

    // オープニング処理
    void SetTitle (string message, Color color)
    {
        // タイトル名のセット
        text.text = message;
        text.color = color;
        // パネル活性化
        panel.SetActive (true);
    }

    void ToTitle(){
        SceneManager.LoadSceneAsync(next_scene);
    }
}
