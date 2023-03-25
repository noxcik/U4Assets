using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeGeneratorScript : MonoBehaviour
{
    public Vector3 direction;
    public GameObject prefab;
    public int size;// Размер генерируемого поля.
    public float randomStepMax;
    public float offsetStepMax;

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < size * 5;i++){
            float posy = transform.position.y + Random.Range(-randomStepMax,randomStepMax);
            Vector3 pos = new Vector3(transform.position.x  + Random.Range(-offsetStepMax,offsetStepMax),posy,transform.position.z + Random.Range(-offsetStepMax,offsetStepMax));
            GameObject cube =  Instantiate(prefab,pos,Quaternion.identity); 
            cube.transform.parent = transform.parent;
            transform.Translate(direction * 0.2f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
