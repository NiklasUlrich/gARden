using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneCollider : MonoBehaviour
{
    /// <summary>
    /// The event that will be played
    /// </summary>
    //public AK.Wwise.Event ZoneWwiseEvent;

    public AK.Wwise.Switch mySwitch;

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

            /*if (ZoneWwiseEvent != null)
            {
                ZoneWwiseEvent.Post(gameObject);
            }*/
        }
    }
}
