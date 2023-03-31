using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialTextScript : MonoBehaviour
{
    public string str;
    public CollectedTextScript textScript;
    void Start()
    {
        textScript = GameObject.FindWithTag("CollectedText").GetComponent<CollectedTextScript>();
        textScript.SpecialText(str);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
