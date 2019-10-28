using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Factory : Building
{
    // Start is called before the first frame update
    void Start()
    {
        areYouDead = false;
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
        healthBar.fillAmount = (float)hp / maxHp;
        if (hp <= 0)
        {
            isDead();
        }
    }

    protected GameObject spawnUnit(int numResources)
    {
        for (int i = 0; i < (numResources); i++)
        {
            //spawn unit
            numResources -= 3;
        }
        GameObject unit = null;
        /* GameObject units = Instantiate(choices[Random.Range(0, 2)]);
         units.transform.position = new Vector3(Random.Range(-20, 20), 0, Random.Range(-20, 20));*/
        return unit;
    }
    protected GameObject nearestResourceBuilding(int team)
    {
        GameObject resourceBuilding = null;
        /*if (team == 1)
        {
            resourceBuilding = find
        }*/
        return resourceBuilding;
    }
}
