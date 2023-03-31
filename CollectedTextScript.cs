using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectedTextScript : MonoBehaviour
{
    public CollectorScript collector;
    public void UpdateText(){
        Text text = GetComponent<Text>();
        text.text = collector.collected.ToString() + "/5"; 
    }
    public void SpecialText(string str){
        Text text = GetComponent<Text>();
        text.text = str; 
    }
}
