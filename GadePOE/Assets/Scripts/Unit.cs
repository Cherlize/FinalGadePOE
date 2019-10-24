using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    //variables
    [SerializeField] protected int range;
    [SerializeField] protected int hp;
    [SerializeField] protected int maxHp;
    [SerializeField] protected int attack;
    [SerializeField] protected float speed;
    [SerializeField] protected int team;
    [SerializeField] protected Material[] arrMaterials;

    int Cooldown = 1;
    float Timer = 0;

    //accessors
    public int Hp { get => hp; set => hp = value; }
    public int MaxHp { get => maxHp; }
    public int Attack { get => attack; }
    public float Speed { get => speed; }
    public int Range { get => range; }
    public int Team { get => team; }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Movement
        if (InRange(NearestEnemy()) == false)   //enemy is not in range
        {
            transform.position = Vector3.MoveTowards(transform.position, NearestEnemy().transform.position, speed * Time.deltaTime);    //Move towards enemy
        }
        else
        {
            if (hp > (hp * (25 / 100)))     //if above 25% hp
            {
                AttackMethod(NearestEnemy());       //attack enemy in range
            }
        }

        if (team == 3)     //wizard code
        {

        }
    }

    //Methods

    protected void AttackMethod(GameObject enemy)
    {
        Timer += Time.deltaTime;
        if (Timer >= Cooldown)
        {
            if (InRange(enemy))
            {
                enemy.GetComponent<Unit>().hp -= attack;
            }
            Timer = 0;
        }

        //healthBar.fillAmount = (float)hp / maxHP;
    }

    protected GameObject NearestEnemy()
    {
        GameObject Unit = null;

        GameObject[] arrTeamOneAndTwo = null;       //for wizards to attack
        GameObject[] arrUnits = null;

        switch (team)       //this unit's team
        {
            case 1:
                arrUnits = GameObject.FindGameObjectsWithTag("Team 2");     //enemy team if this unit is team 1
                break;
            case 2:
                arrUnits = GameObject.FindGameObjectsWithTag("Team 1");     //enemy team if this unit is team 2
                break;
            case 3:         //wizards
                {
                    arrTeamOneAndTwo = GameObject.FindGameObjectsWithTag("Team 1");
                    arrTeamOneAndTwo = GameObject.FindGameObjectsWithTag("Team 2");
                    break;
                }
        }

        //WIZARD CODE
        if (team == 3)
        {
            float nearest = 200;

            foreach (GameObject temp in arrTeamOneAndTwo)       //for each unit in the array
            {
                float TempDist = Vector3.Distance(transform.position, temp.transform.position);     //check the distance between me and the unit in the array
                if (TempDist <= nearest)       //if its nearer than the previous one
                {
                    nearest = TempDist;        //update the distance
                    Unit = temp;                //set the temp to the new closest enemy
                }
            }
            return Unit;        //returns the nearest enemy of the oppesite team
        }

        //TEAM 1 AND 2 CODE
        float distance = 200;

        foreach (GameObject temp in arrUnits)       //for each unit in the array
        {
            float tempDist = Vector3.Distance(transform.position, temp.transform.position);     //check the distance between us and the unit in the array
            if (tempDist <= distance)       //if its nearer than the previous one
            {
                distance = tempDist;        //update the distance
                Unit = temp;                //set the temp to the new closest enemy
            }
        }
        return Unit;        //returns the nearest enemy of the oppesite team
    }

    protected bool InRange(GameObject enemy)
    {
        bool returnVal = false;
        if (Vector3.Distance(transform.position, enemy.transform.position) <= range)      //checks if the distance between me and enemy is smaller/equal to range
        {
            returnVal = true;
        }
        else
        {
            returnVal = false;
        }

        return returnVal;
    }

    protected void isDead(GameObject thisUnit)
    {
        if (hp <= 0)
        {
            Destroy(thisUnit);
        }
    }
}
