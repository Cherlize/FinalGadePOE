using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Wizard : Unit
{
    private float Timer = 0;
    // Start is called before the first frame update
    void Start()
    {
        hp = 8;
        areYouDead = false;
        maxHp = hp;
        attack = 2;
        range = 3;
        speed = 2f;
        team = 3;
        Cooldown = 4;
        gameObject.tag = "Team 3";
        healthBar = GetComponentsInChildren<Image>()[1];
    }

    // Update is called once per frame for the AoE attack
    void update()
    {
        healthBar.fillAmount = (float)hp / maxHp;
        //Movement
        GameObject[] enemies = NearestEnemies();
        foreach (GameObject e in enemies)
        {
            if (hp > (maxHp * (50 / 100)))      //if above 50% health
            {
                if (InRange(e) == true)     //if enemy is in range
                {
                    AttackMethod(e);        //attack enemy
                }
                else
                {   //move towards enemy
                    transform.position = Vector3.MoveTowards(transform.position, e.transform.position, speed * Time.deltaTime);
                }
            }
            else
            {
                if (hp <= 0)
                {
                    isDead();
                }
                transform.position = Vector3.MoveTowards(transform.position, NearestEnemy().transform.position * -1, speed * Time.deltaTime);
            }
        }
    }

    protected GameObject[] NearestEnemies()
    {
        GameObject[] enemies = null;
        GameObject[] temp = null;

        enemies = GameObject.FindGameObjectsWithTag("Team 1");
        temp = GameObject.FindGameObjectsWithTag("Team 2");
        int oldSize = enemies.Length;      //saves original length
        Array.Resize(ref enemies, enemies.Length + temp.Length);      //resizes array to expand by array two's length
        for (int i = oldSize; i < enemies.Length; i++)
        {
            enemies[i] = temp[i - oldSize];          //starts adding from beginning of second array
        }
        return enemies;
    }

    /*protected void wizardAttack(GameObject[] enemies)
    {
        foreach (GameObject enemy  in enemies)
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
                        enemy.GetComponent<Unit>().Hp -= attack;

                    }
                    Timer = 0;
                }
            }
        }
    }*/
}
