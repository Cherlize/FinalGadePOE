using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
        switch (team)
        {
            case 1:
                gameObject.tag = "Team 1";
                break;
            case 2:
                gameObject.tag = "Team 2";
                break;
        }
        healthBar = GetComponentsInChildren<Image>()[1];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
