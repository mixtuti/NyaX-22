using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AudioManager;

public class HitPlaySound : MonoBehaviour
{
    void OnCollisionEnter(Collision collision) {
        SEManager.Instance.Play(SEPath.WALL_HIT,0.2f);
    }
}
