using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_controll : MonoBehaviour
{
    public Vector3 offset;
    public Transform target;
    // Start is called before the first frame update
    void Start()
    {
        offset = target.position - transform.position;
    }

    // Update is called once per frame
    void Update()
    {
       transform.position = target.position - offset; 
    }
}
