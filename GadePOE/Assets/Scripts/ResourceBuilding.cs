using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourceBuilding : Building
{
    [SerializeField] int resource;
    public int numResource { get => resource; }

    // Start is called before the first frame update
    void Start()
    {
        hp = 15;
        maxHp = hp;
        productionSpeed = 1 * Time.deltaTime;
        team = Random.Range(1, 3);
        switch (team)
        {
            case 1:
                gameObject.tag = "Team 1";
                break;
            case 2:
                gameObject.tag = "Team 2";
                break;
        }
        GetComponent<MeshRenderer>().material = arrMaterials[team - 1];
        resource = Random.Range(0, 15);
        healthBar = GetComponentsInChildren<Image>()[1];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
