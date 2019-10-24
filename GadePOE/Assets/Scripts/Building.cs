using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    //variables
    [SerializeField] protected int hp;
    [SerializeField] protected int maxHp;
    [SerializeField] protected float productionSpeed;
    [SerializeField] protected int team;
    [SerializeField] protected Material[] arrMaterials;

    //accessors
    public int Hp { get => hp; set => hp = value; }
    public int MaxHp { get => maxHp; }
    public float ProductionSpeed { get => productionSpeed; }
    public int Team { get => team; }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
