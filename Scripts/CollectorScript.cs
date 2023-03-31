using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectorScript : MonoBehaviour
{
    public int needToCollect;
    public int collected;

    public AudioSource collectSound;
    
    public CollectedTextScript collectedText;   

    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.tag == "Collectable"){
            collected ++;
            collectSound.Play();
            Destroy(other.gameObject);
            collectedText.UpdateText();
        }
    }
}
