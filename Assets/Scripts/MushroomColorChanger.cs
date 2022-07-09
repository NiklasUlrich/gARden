using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomColorChanger : MonoBehaviour
{
    public Color startColor;
    public Color[] randomColors;
    public Color endColor;

    private int counter = 0;
    private int currentColor;

    public int numberOfHits;
    public bool completed = false;

    Renderer mushroomRenderer;
    Mesh mesh;

    // Start is called before the first frame update
    void Start()
    {
        mushroomRenderer = gameObject.GetComponent<Renderer>();
        mushroomRenderer.material.SetColor("_Color", startColor);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void colorChange()
    {
        counter++;
        if (counter >= numberOfHits)
        {
            completed = true;
            mushroomRenderer.material.SetColor("_Color", endColor);
        }
        if (!completed)
        {
            int randomColor = currentColor;
            while (randomColor == currentColor)
            {
                randomColor = Random.Range(0, randomColors.Length);
            }

            currentColor = randomColor;
            mushroomRenderer.material.SetColor("_Color", randomColors[randomColor]);
        }
        
    }
}
