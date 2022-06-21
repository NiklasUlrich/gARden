using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowSeed : MonoBehaviour
{
    public GameObject seedling;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<FruitBehavior>() != null)
        {
            Debug.Log("Fruit hit Ground!");

            GameObject newSeedling = Instantiate(seedling, other.transform.position, Quaternion.identity);
            newSeedling.GetComponent<Animator>().SetBool("Completed", true);
        }
    }
}
