using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamerasSwither : MonoBehaviour
{
    float timer = 0;
    public float DelayTime;
    public GameObject toEnable;
    public GameObject toDisable;
    // Start is called before the first frame update
    void Start()
    {
        timer = DelayTime;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if(timer <= 0){
            toEnable.SetActive(true);
            toDisable.SetActive(false);
            Destroy(gameObject);
        }
    }
}
