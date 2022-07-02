using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dandelion : MonoBehaviour
{
    public GameObject seeds;

    public Transform center;

    public float explosionForce;

    public bool explodeOnStart;
    // Start is called before the first frame update
    void Start()
    {
        if (explodeOnStart)
        {
            explode();
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void explode()
    {
        Rigidbody[] seedRBs = seeds.GetComponentsInChildren<Rigidbody>();

        for(int i = 0; i < seedRBs.Length; i++)
        {
            seedRBs[i].isKinematic = false;
            seedRBs[i].AddExplosionForce(explosionForce, center.position, .3f, 0);
            Debug.Log("added Explosion force");
        }
    }
}
