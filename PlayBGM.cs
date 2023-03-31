using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AudioManager;

public class PlayBGM : MonoBehaviour
{
    void Start()
    {
        BGMManager.Instance.Play(BGMPath.BGM_BLOCK);
    }

    void Update()
    {
        if(Input.GetKey (KeyCode.N)){
            BGMSwitcher.FadeOutAndFadeIn(BGMPath.NYAN100_CARNIVAL);
        }
        if(Input.GetKey (KeyCode.O)){
            BGMSwitcher.FadeOutAndFadeIn(BGMPath.BGM_BLOCK);
        }
    }
}
