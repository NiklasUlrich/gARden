using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EasterEggObserver : MonoBehaviour
{
    public FruitBehavior banana;
    bool bananaFound = false;

    public GameObject mushrooms;
    TinyMushroomBehavior[] tinyMushrooms;
    bool mushroomsFound = false;

    public GameObject dandelionParent;
    Dandelion[] dandelions;
    bool dandelionsFound = false;

    // Start is called before the first frame update
    void Start()
    {
        tinyMushrooms = mushrooms.GetComponentsInChildren<TinyMushroomBehavior>();
        dandelions = dandelionParent.GetComponentsInChildren<Dandelion>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!bananaFound)
        {
            BananaUpdate();
        }
        if (!mushroomsFound)
        {
            MushroomUpdate();
        }
        if(!dandelionsFound)
        {
            DandelionUpdate();
        }
    }

    void BananaUpdate()
    {
        if (!banana.gameObject.GetComponent<Rigidbody>().isKinematic)
        {
            bananaFound = true;
            Debug.Log("Banana found");
        }
    }

    void MushroomUpdate()
    {
        for (int i = 0; i < tinyMushrooms.Length; i++)
        {
            if (!tinyMushrooms[i].gameObject.GetComponent<Rigidbody>().isKinematic)
            {
                mushroomsFound = true;
                Debug.Log("Mushrooms found");
                return;
            }
        }
    }

    void DandelionUpdate()
    {
        for(int i = 0; i < dandelions.Length; i++)
        {
            if (dandelions[i].DoubleExploded)
            {
                dandelionsFound = true;
                Debug.Log("Dandelion found");
                return;
            }
        }
    }
}
