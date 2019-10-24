using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceBuilding : MonoBehaviour
{
    [SerializeField] int resource;
    public int numResource { get => resource; }

    // Start is called before the first frame update
    void Start()
    {
        resource = Random.Range(0, 15);
        //healthBar = GetComponentsInChildren<Image>()[1];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
