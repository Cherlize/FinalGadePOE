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
        attack = 3;
        range = 2;
        speed = 1;
        team = 3;
        gameObject.tag = "Team 3";
        healthBar = GetComponentsInChildren<Image>()[1];
    }
}
