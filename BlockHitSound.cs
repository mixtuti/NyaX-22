using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AudioManager;

public class BlockHitSound : MonoBehaviour
{
    int count = 0;

    void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.tag == "Block") {
            if(count % 2 == 0){
                SEManager.Instance.Play(SEPath.HIT,0.5f);
                // count++;
            }
            else{
                SEManager.Instance.Play(SEPath.HIT_ANOTHER,0.5f);
                // count++;
            }
            count++;
            Debug.Log(count);
        }
        else if(collision.gameObject.tag == "Wall"){
            SEManager.Instance.Play(SEPath.WALL_HIT,0.2f);
        }
        else if(collision.gameObject.tag == "Racket"){
            SEManager.Instance.Play(SEPath.HIT_RACKET,0.7f);
        }
    }
}
