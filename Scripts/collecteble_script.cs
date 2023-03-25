using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collecteble_script : MonoBehaviour
{
    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.tag == "Player"){
            GameManager_script manager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager_script>();
            Destroy(gameObject);
            manager.Collect();
        }

    }
}
