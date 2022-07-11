using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TinyMushroomBehavior : MonoBehaviour
{
    public AK.Wwise.Event WwisePickUpEvent;
    public AK.Wwise.Event WwiseThrowEvent;
    public AK.Wwise.Event WwiseGroundEvent;


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
        if (WwisePickUpEvent != null)
        {
            WwisePickUpEvent.Post(gameObject);
        }
    }

    public void OnThrow()
    {
        if (WwiseThrowEvent != null)
        {
            WwiseThrowEvent.Post(gameObject);
        }
    }

    public void OnGroundCollision()
    {
        if (WwiseGroundEvent != null)
        {
            WwiseGroundEvent.Post(gameObject);
        }
    }
}