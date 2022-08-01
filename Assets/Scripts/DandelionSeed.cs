using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DandelionSeed : MonoBehaviour
{
    public AK.Wwise.Event WwisePickUpEvent;
    public AK.Wwise.Event WwiseThrowEvent;

    public Dandelion parent;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void OnThrow()
    {
        if (WwiseThrowEvent != null)
        {
            WwiseThrowEvent.Post(gameObject);
        }
    }

    public void OnGrab()
    {
        gameObject.GetComponent<Rigidbody>().isKinematic = false;
        if (WwisePickUpEvent != null)
        {
            WwisePickUpEvent.Post(gameObject);
        }
    }
}
