using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class TriggerToScene : MonoBehaviour
{
    public int numberOfTergetScene;
    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Player"){
            SceneManager.LoadScene(numberOfTergetScene);
        }
    }
}
