using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerBehavior : MonoBehaviour
{
    /// <summary>
    /// Which event will be played when touch is started
    /// </summary>
    public AK.Wwise.Event GrabWwiseEvent;

    /// <summary>
    /// Which event will be played when touch is started
    /// </summary>
    public AK.Wwise.Event ThrowWwiseEvent;

    public AK.Wwise.Event WwiseGroundEvent;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    //is called when the fruit is grabbed
    public void OnGrab()
    {
        
        gameObject.GetComponent<Rigidbody>().isKinematic = false;

        if (GrabWwiseEvent != null)
        {
            GrabWwiseEvent.Post(gameObject);
        }
    }

    //is called when the fruit is released
    public void OnRelease()
    {
        if (ThrowWwiseEvent != null)
        {
            ThrowWwiseEvent.Post(gameObject);
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
