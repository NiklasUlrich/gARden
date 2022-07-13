using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundingObserver : MonoBehaviour
{
    bool finished = false;
    GroundingFlower[] flowers;
    public AK.Wwise.Event FinishedWwiseEvent;
    public ParticleSystem[] effects;

    // Start is called before the first frame update
    void Start()
    {
        flowers = GetComponentsInChildren<GroundingFlower>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!finished)
        {
            CheckDandelions();
        }
    }

    void CheckDandelions()
    {
        finished = true;
        for (int i = 0; i < flowers.Length; i++)
        {
            if (!flowers[i].Spawned)
            {
                finished = false;
                return;
            }
        }

        Debug.Log("Grounding completed");
        if (FinishedWwiseEvent != null)
        {
            FinishedWwiseEvent.Post(gameObject);
        }

        for (int i = 0; i < effects.Length; i++)
        {
            effects[i].Play();
            Debug.Log("[Debug] playing grounding Event");
        }
    }
}

