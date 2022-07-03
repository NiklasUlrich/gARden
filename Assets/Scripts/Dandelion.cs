using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dandelion : MonoBehaviour
{
    public GameObject seeds;

    public float explosionForce;

    public Transform flowerCenter;

    public float upwardsModifier;

    public bool explodeOnStart;

    public AK.Wwise.Event clapWwiseEvent;

    public AK.Wwise.Event seedWwiseEvent;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void explode(Vector3 explosionCenter, float  explosionRange)
    {
        Rigidbody[] seedRBs = seeds.GetComponentsInChildren<Rigidbody>();
        if (clapWwiseEvent != null)
        {
            clapWwiseEvent.Post(gameObject);
        }

        for (int i = 0; i < seedRBs.Length; i++)
        {
            seedRBs[i].isKinematic = false;
            seedRBs[i].AddExplosionForce(explosionForce, explosionCenter, explosionRange, upwardsModifier);
        }
    }
}
