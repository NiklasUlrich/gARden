using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TinyMushrooms : MonoBehaviour
{
    /// <summary>
    /// List of the tiny mushrooms' animators, Should be 5 in total
    /// </summary>
    public Animator[] mushroomAnimators;

    /// <summary>
    /// determines which mushroom is animated next
    /// </summary>
    int iterator = 0;

    /// <summary>
    /// true if the mushroom is currently animating
    /// </summary>
    bool animating = false;

    /// <summary>
    /// a timer in secons
    /// </summary>
    float timer = 0f;

    /// <summary>
    /// the time between two tiny mushrooms' growth animation
    /// </summary>
    public float interval = 0.2f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (animating)
        {
            timer += Time.deltaTime;
            Debug.Log(timer);
            if(timer >= interval)
            {
                mushroomAnimators[iterator].SetBool("Completed", true);
                Debug.Log("animating tiny mushroom " + iterator);
                iterator++;
                if(iterator == mushroomAnimators.Length)
                {
                    animating = false;
                }

                timer -= interval;
            }
        }
    }

    /// <summary>
    /// starts all the tiny mushroom's animations
    /// </summary>
    public void Animate()
    {
        animating = true;
    }
}
