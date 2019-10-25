using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    [SerializeField] protected float cooldown;
    float Timer = 0;
    protected Image healthBar;

    //accessors
    public int Hp { get => hp; set => hp = value; }
    public int MaxHp { get => maxHp; }
    public int Attack { get => attack; }
    public float Speed { get => speed; }
    public int Range { get => range; }
    public int Team { get => team; }
    public float Cooldown { get => cooldown; set => cooldown = value; }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.fillAmount = (float)hp / maxHp;
        //Movement
        if (InRange(NearestEnemy()) == false)   //enemy is not in range
        {
            transform.position = Vector3.MoveTowards(transform.position, NearestEnemy().transform.position, speed * Time.deltaTime);    //Move towards enemy
        }
        else
        {
            if ((hp > (maxHp * (25 / 100))))     //if above 25% hp
            {
                AttackMethod(NearestEnemy());       //attack enemy in range
                if (hp <= 0)
                {
                    isDead();
                }                
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, NearestEnemy().transform.position * -1, speed * Time.deltaTime);
                if (hp <= 0)
                {
                    isDead();
                }
            }
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
                if (enemy.name.Contains("Building"))
                {
                    enemy.GetComponent<Building>().Hp -= attack;
                   
                }
                else
                {
                    enemy.GetComponent<Unit>().hp -= attack;
                  
                }
                Timer = 0;
            }
        }
    }

    protected GameObject NearestEnemy()
    {
        GameObject Unit = null;
        GameObject[] arrTeamTwo = null;
        GameObject[] arrWizards = null;
        GameObject[] arrBuildings = null;
        GameObject[] arrUnits = null;

        switch (team)       //this unit's team
        {
            case 1: //Team 1
                {
                    
                    arrUnits = GameObject.FindGameObjectsWithTag("Team 2");
                    arrWizards = GameObject.FindGameObjectsWithTag("Team 3");
                    int oldSize = arrUnits.Length;
                    Array.Resize(ref arrUnits, arrUnits.Length + arrWizards.Length);
                    for (int i = oldSize; i < arrUnits.Length; i++)
                    {
                        arrUnits[i] = arrWizards[i - oldSize];
                    }

                    /*For BUILDINGS
                    arrBuildings = GameObject*/
                    break;
                }
            case 2: //Team 2
                {
                    arrUnits = GameObject.FindGameObjectsWithTag("Team 1");
                    arrWizards = GameObject.FindGameObjectsWithTag("Team 3");
                    int oldSize = arrUnits.Length;
                    Array.Resize(ref arrUnits, arrUnits.Length + arrWizards.Length);
                    for (int i = oldSize; i < arrUnits.Length; i++)
                    {
                        arrUnits[i] = arrWizards[i - oldSize];
                    }
                    break;
                }
            case 3:         //wizards
                {
                    arrUnits = GameObject.FindGameObjectsWithTag("Team 1");
                    arrTeamTwo = GameObject.FindGameObjectsWithTag("Team 2");
                    int oldSize = arrUnits.Length;      //saves original length
                    Array.Resize(ref arrUnits, arrUnits.Length + arrTeamTwo.Length);      //resizes array to expand by array two's length
                    for (int i = oldSize; i < arrUnits.Length; i++)
                    {
                        arrUnits[i] = arrTeamTwo[i - oldSize];          //starts adding from beginning of second array
                    }
                    break;
                }
        }               
            float distance = 200;

            foreach (GameObject temp in arrUnits)       //for each unit in the array, either
            {
                float tempDist = Vector3.Distance(transform.position, temp.transform.position);     //check the distance between us and the unit in the array
                if (tempDist <= distance)       //if its nearer than the previous one
                {
                    distance = tempDist;        //update the distance
                    Unit = temp;                //set the temp to the new closest enemy
                }
            }
            return Unit;
                //returns the nearest enemy of the opposite team
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

    protected void isDead()
    {
            Destroy(gameObject);
    }
}
