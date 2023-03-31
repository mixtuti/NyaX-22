using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    void OnCollisionEnter(Collision collision) {
        //衝突判定
        if (collision.gameObject.tag == "Player") {
            if (FindObjectOfType<Manager> ().currentState == Manager.GameState.Playing) {
                //スコア処理を追加
                string name = this.name;
                int score = int.Parse (name.Substring (name.Length - 1));
                FindObjectOfType<Score> ().AddPoint (score * 10);
            }

            //相手のタグがBallならば、自分を消す
            Destroy(this.gameObject);
        }
    }
}
