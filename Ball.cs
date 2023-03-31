using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private float speed = 10.0f; //20

    [SerializeField] public Rigidbody rb;
    void Start()
    {
        rb.AddForce((transform.forward + transform.right) * speed ,ForceMode.VelocityChange);
    }

    public void Init(){
        // 加速値を初期化
        Rigidbody rd = this.GetComponent<Rigidbody> ();
        rd.velocity = Vector3.zero;
        rd.AddForce((transform.forward + transform.right) * speed, ForceMode.VelocityChange);
    }
}
