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
    [SerializeField] protected Material[] arrMaterials;
   // [SerializeField] GameObject choices = new GameObject[2];

    protected Image healthBar;

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

    protected void isDead()
    {
        Destroy(gameObject);
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
}
