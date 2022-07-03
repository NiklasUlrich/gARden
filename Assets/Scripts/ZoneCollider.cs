using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneCollider : MonoBehaviour
{
    /// <summary>
    /// The trigger that will play the sound
    /// </summary>
    public WwisePlayerEnter trigger;

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
        if(other.gameObject.tag == "MainCamera" )
        {
            //Debug.Log("Entering new Zone");
            trigger.enter();

        }
    }
}
