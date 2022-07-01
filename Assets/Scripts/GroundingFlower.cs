using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundingFlower : MonoBehaviour
{
    /// <summary>
    /// Which event will be played when the object is spawned
    /// </summary>
    public AK.Wwise.Event GrowWwiseEvent;

    public List<GameObject> flowers;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Spawn()
    {
        GameObject newFlower = Instantiate(flowers[Random.Range(0, flowers.Count)], gameObject.transform.position, Quaternion.Euler(0, Random.Range(0, 360), 0));
        newFlower.GetComponent<Animator>().SetBool("Completed", true);

        if (GrowWwiseEvent != null)
        {
            GrowWwiseEvent.Post(gameObject);
        }
    }
}
