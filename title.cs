using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using AudioManager;

public class title : MonoBehaviour
{
    [Header("次のシーン")] public SceneReference next_scene;
    void Start()
    {
        BGMManager.Instance.Play(
            audioPath       : BGMPath.FULL, //再生したいオーディオのパス
            volumeRate      : 1,                //音量の倍率
            delay           : 0,                //再生されるまでの遅延時間
            pitch           : 1,                //ピッチ
            isLoop          : true,             //ループ再生するか
            allowsDuplicate : false             //他のBGMと重複して再生させるか
        );
    }

    void Update()
    {
        if(Input.GetKey(KeyCode.Space)){
            BGMManager.Instance.FadeOut();
            SEManager.Instance.Play(
                audioPath       : SEPath.CAT_ROBOT, //再生したいオーディオのパス
                volumeRate      : 0.2f,                //音量の倍率
                delay           : 0,                //再生されるまでの遅延時間
                pitch           : 1,                //ピッチ
                isLoop          : false             //ループ再生するか
            );
            SceneManager.LoadSceneAsync(next_scene);
        }
    }
}
