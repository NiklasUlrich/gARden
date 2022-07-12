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

    /// <summary>
    /// a timer in secons
    /// </summary>
    private float timer = 0f;

    /// <summary>
    /// the time between two flowers' growth animation in seconds
    /// </summary>
    public float interval = 0.1f;

    
    private List<GroundingFlower> flowerAnimators;

    /// <summary>
    /// counts through the flowers
    /// </summary>
    private int iterator = 0;

    /// <summary>
    /// is true once all flowers have been animated
    /// </summary>
    private bool animationCompleted = false;

    /// <summary>
    /// Which event will be played when the object is spawned
    /// </summary>
    public AK.Wwise.Event GrowWwiseEvent;

    // Start is called before the first frame update
    void Start()
    {
        flowerAnimators = new List<GroundingFlower>(GetComponentsInChildren<GroundingFlower>());
    }

    // Update is called once per frame
    void Update()
    {
        if (!animationCompleted && playerIsTouching)
        {
            timer += Time.deltaTime;
            if (timer >= interval)
            {
                if(iterator < flowerAnimators.Count)
                {
                    flowerAnimators[iterator].Spawn();
                    iterator++;
                }
                else
                {
                    animationCompleted = true;
                }
                timer -= interval;
            }
        }
    }

    public void OnTouchCompleted(HandTrackingInputEventData eventData) 
    {

    }

    public void OnTouchStarted(HandTrackingInputEventData eventData)
    {
        if (!playerIsTouching)
        {
            playerIsTouching = true;

            gameObject.GetComponent<Renderer>().enabled = false;

            if (GrowWwiseEvent != null)
            {
                GrowWwiseEvent.Post(gameObject);
            }
        }
        

    }

    public void OnTouchUpdated(HandTrackingInputEventData eventData) { }
}
