using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitTreeObserver : MonoBehaviour
{
    bool finished = false;
    FruitBehavior[] fruits;
    public AK.Wwise.Event FinishedWwiseEvent;
    public ParticleSystem[] effects;
    // Start is called before the first frame update
    void Start()
    {
        fruits = GetComponentsInChildren<FruitBehavior>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!finished)
        {
            CheckFruits();
        }
    }

    void CheckFruits()
    {
        finished = true;
        for (int i = 0; i < fruits.Length; i++)
        {
            if (!fruits[i].Planted)
            {
                finished = false;
                return;
            }
        }

        Debug.Log("Mushrooms completed");
        if (FinishedWwiseEvent != null)
        {
            FinishedWwiseEvent.Post(gameObject);
        }

        for (int i = 0; i < effects.Length; i++)
        {
            effects[i].Play();
        }
    }
}
