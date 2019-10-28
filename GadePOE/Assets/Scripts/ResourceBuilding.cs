using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourceBuilding : Building
{
    [SerializeField] int resources;
    public int numResources { get => resources; }

    // Start is called before the first frame update
    void Start()
    {
        hp = 15;
        areYouDead = false;
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
        resources = Random.Range(0, 15);
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

        GameObject[] enemies = null;
        enemies = allEnemies(team);       //which team is the enemy?
        foreach (GameObject e in enemies)
        {
            if (e.GetComponent<Unit>().AreYouDead == true)
            {
                resources += 1;
            }
            Text resourcesText = GameObject.Find("ResourceCanvas").GetComponent<Text>();
            resourcesText.text = "Resources: " + resources;
        }
    }

    protected GameObject[] allEnemies(int team)
    {
        GameObject[] enemies = null;
        if (team == 1)
        {
            enemies = GameObject.FindGameObjectsWithTag("Team 2");
        }
        else
        {
            enemies = GameObject.FindGameObjectsWithTag("Team 1");
        }
        return enemies;
    }
}
