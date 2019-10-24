using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEngine : MonoBehaviour
{
    [SerializeField] GameObject[] options = new GameObject[4];
  //  [SerializeField] GameObject[] buildings = new GameObject[2];

    // Start is called before the first frame update
    void Start()
    {
        int units = 10;
        for (int i = 0; i < units; i++)
        {
            Spawn();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Spawn()
    {
       // GameObject building = Instantiate(buildings[Random.Range(0, 3)]); 
        GameObject units = Instantiate(options[Random.Range(0, 4)]);
        units.transform.position = new Vector3(Random.Range(-20, 20), 0, Random.Range(-20, 20));
        //building.transform.position = new Vector3(Random.Range(-10, 10), 0, Random.Range(-10, 10));
    }
}
