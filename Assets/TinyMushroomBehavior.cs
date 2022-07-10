using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TinyMushroomBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnGrab()
    {
        gameObject.GetComponent<Rigidbody>().isKinematic = false;
        Debug.Log("Tiny Mushroom picked up");
    }
}
