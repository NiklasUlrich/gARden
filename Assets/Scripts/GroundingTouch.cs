using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Microsoft.MixedReality.Toolkit.Input;

public class GroundingTouch : MonoBehaviour, IMixedRealityTouchHandler
{
    /// <summary>
    /// Is true if the player is currently touching the object
    /// </summary>
    private bool playerIsTouching = false; 

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTouchCompleted(HandTrackingInputEventData eventData) 
    {
        playerIsTouching = false;
        Debug.Log("[Debug] Touch completed");
    }

    public void OnTouchStarted(HandTrackingInputEventData eventData)
    {
        playerIsTouching = true;
        Debug.Log("[Debug] Touch started");
    }

    public void OnTouchUpdated(HandTrackingInputEventData eventData) { }
}
