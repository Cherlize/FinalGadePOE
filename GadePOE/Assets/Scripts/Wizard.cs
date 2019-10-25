using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Wizard : Unit
{
    // Start is called before the first frame update
    void Start()
    {
        hp = 8;
        maxHp = hp;
        attack = 2;
        range = 2;
        speed = 1f;
        team = 3;
        Cooldown = 6;
        gameObject.tag = "Team 3";
        healthBar = GetComponentsInChildren<Image>()[1];
    }

    // Update is called once per frame for the AoE attack
    /*void update()
    {
        //Movement
        if (InRange(NearestEnemy()) == false)   //enemy is not in range
        {
            transform.position = Vector3.MoveTowards(transform.position, NearestEnemy().transform.position, speed * Time.deltaTime);    //Move towards enemy
        }
        else
        {
            if ((hp > (hp * (50 / 100))))     //if above 50% hp
            {
                if (true)
                {

                }
                AttackMethod(NearestEnemy());       //attack enemy in range
                if (hp <= 0)
                {
                    isDead();
                }
            }
            else
            {
                if (hp <= 0)
                {
                    isDead();
                }
                transform.position = Vector3.MoveTowards(transform.position, NearestEnemy().transform.position * -1, speed * Time.deltaTime);        //Move away
            }
        }
    }*/
}
