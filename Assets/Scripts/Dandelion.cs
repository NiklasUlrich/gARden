using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dandelion : MonoBehaviour
{
    /// <summary>
    /// Parent object that contains the seeds
    /// </summary>
    public GameObject seeds;

    /// <summary>
    /// The rigidbodies of the seed objects
    /// </summary>
    Rigidbody[] seedRBs;

    /// <summary>
    /// The force with which the seeds will explode when triggered
    /// </summary>
    public float explosionForce;

    /// <summary>
    /// ´How much the trajetory of the seed will be corrected upwards
    /// </summary>
    public float upwardsModifier;

    public Transform flowerCenter;

    /// <summary>
    /// True when the seed have been "exploded" again while in midair
    /// </summary>
    bool doubleExploded = false;
    public bool DoubleExploded { get => doubleExploded; set => doubleExploded = value; }

    /// <summary>
    /// True when the plant has already exploded
    /// </summary>
    bool exploded;
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

    public void Explode(Vector3 explosionCenter, float  explosionRange)
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
