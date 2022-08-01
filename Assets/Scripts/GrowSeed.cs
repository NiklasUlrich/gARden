using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowSeed : MonoBehaviour
{
    /// <summary>
    /// A list of the seedling objects which can be spawned from fruit
    /// </summary>
    public List<GameObject> seedlings;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // <OnTriggerEnter>
    /// <summary>
    /// Is triggered when an objects enters the ground. Reacts when the object contains certain scripts
    /// </summary>
    /// <param name="other">the collider of the entering GameObjects</param>
    private void OnTriggerEnter(Collider other)
    {
        //Plants a seedling + plays vfx when other is a fruit
        Fruit fruit = other.gameObject.GetComponent<Fruit>();
        if (fruit != null && !fruit.banana)
        {
            fruit.Plant();
            return;
        }

        //Plays collision sound if other is tiny mushroom
        TinyMushroomBehavior tinyMushroom = other.gameObject.GetComponent<TinyMushroomBehavior>();
        if (tinyMushroom != null)
        {
            tinyMushroom.OnGroundCollision();
            return;
        }

        //plays collision sound if other is tiny flower
        FlowerBehavior flower = other.gameObject.GetComponent<FlowerBehavior>();
        if (flower != null)
        {
            flower.OnGroundCollision();
            return;
        }
    }
}
