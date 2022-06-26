using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowSeed : MonoBehaviour
{
    /// <summary>
    /// A list of the seedling objects which can be spawned from fruit
    /// </summary>
    public List<GameObject> seedlings;

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
            //instantiates a new Seedling Gameobject at the position where the fruit hits the ground
            GameObject newSeedling = Instantiate(seedlings[Random.Range(0, seedlings.Count)], other.transform.position, Quaternion.Euler(0, Random.Range(0, 360) , 0) );
            newSeedling.GetComponent<Animator>().SetBool("Completed", true);
            other.gameObject.SetActive(false);
        }
    }
}
