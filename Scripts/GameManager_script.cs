using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class GameManager_script : MonoBehaviour
{
    public int collected = 0;
    public int needToCollect = 5;
    public bool can_teleport = false;

    public void Collect(){
        collected +=1;
        if(collected >= needToCollect){
            can_teleport = true;
            next_scene(1);
        }
    }
    public void next_scene(int number){
        SceneManager.LoadScene(number);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
