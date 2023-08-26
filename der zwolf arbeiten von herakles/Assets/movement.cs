using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    public float speed;
    void Update()
    {
        if(Input.GetKey(KeyCode.A)){
            transform.Translate(UnityEngine.Vector3.left * speed * Time.deltaTime);
        }
        if(Input.GetKey(KeyCode.D)){
            transform.Translate(UnityEngine.Vector3.right * speed * Time.deltaTime);
        }
    }
}
