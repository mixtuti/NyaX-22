using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Racket : MonoBehaviour
{
    private float accel = 1000.0f;//加える力の大きさ

    void Update()
    {
        this.GetComponent<Rigidbody>().AddForce(transform.right*Input.GetAxisRaw("Horizontal")*accel,ForceMode.Impulse);
    }
}
