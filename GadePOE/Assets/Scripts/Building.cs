using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Building : MonoBehaviour
{
    //variables
    [SerializeField] protected int hp;
    [SerializeField] protected int maxHp;
    [SerializeField] protected float productionSpeed;
    [SerializeField] protected int team;
    [SerializeField] protected bool areYouDead;
    [SerializeField] protected Material[] arrMaterials;
   // [SerializeField] GameObject choices = new GameObject[2];

    protected Image healthBar;

    //accessors
    public int Hp { get => hp; set => hp = value; }
    public int MaxHp { get => maxHp; }
    public float ProductionSpeed { get => productionSpeed; }
    public int Team { get => team; }
    public bool AreYouDead { get => areYouDead; set => areYouDead = value; }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    /* Update is called once per frame
    void Update()
    {

    }*/

    protected void isDead()
    {
        Destroy(gameObject);
        areYouDead = true;
    }
}
