using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Microsoft.MixedReality.Toolkit.Input;

public class GenericTouchable : MonoBehaviour
{
    public AK.Wwise.Event TouchWwiseEvent;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTouchStarted(HandTrackingInputEventData eventData)
    {
        Debug.Log("[Debug] Generic Touch");
        if (TouchWwiseEvent != null)
        {
            TouchWwiseEvent.Post(gameObject);
        }

    }
}
