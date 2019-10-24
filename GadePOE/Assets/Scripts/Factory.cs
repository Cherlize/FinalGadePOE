using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Factory : Building
{
    // Start is called before the first frame update
    void Start()
    {
        hp = 20;
        maxHp = hp;
        productionSpeed = 2 * Time.deltaTime;
        team = Random.Range(1, 3);
        GetComponent<MeshRenderer>().material = arrMaterials[team - 1];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
