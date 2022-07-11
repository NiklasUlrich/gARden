using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dandelion : MonoBehaviour
{
    public GameObject seeds;

    public float explosionForce;

    public Transform flowerCenter;

    public float upwardsModifier;

    bool doubleExploded = false;

    bool exploded;

    Rigidbody[] seedRBs;

    public AK.Wwise.Event seedWwiseEvent;

    public bool DoubleExploded { get => doubleExploded; set => doubleExploded = value; }
    public bool Exploded { get => exploded; set => exploded = value; }

    // Start is called before the first frame update
    void Start()
    {
        seedRBs = seeds.GetComponentsInChildren<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void explode(Vector3 explosionCenter, float  explosionRange)
    {
        if (!exploded)
        {
            exploded = true;
        }

        for (int i = 0; i < seedRBs.Length; i++)
        {
            if (!doubleExploded)
            {
                if (!seedRBs[i].isKinematic && Vector3.Distance(explosionCenter, seedRBs[i].gameObject.transform.position) < explosionRange)
                {
                    doubleExploded = true;
                }
            }
            
            seedRBs[i].isKinematic = false;
            seedRBs[i].AddExplosionForce(explosionForce, explosionCenter, explosionRange, upwardsModifier);
        }
    }
}
