using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextFade : MonoBehaviour
{
    public TextMeshPro text;
    public float fadeSpeed;
    public byte colorR;
    public byte colorG;
    public byte colorB;

    bool fadeStarted = false;
    bool fadeCompleted = false;
    float alphaValue = 0f;

    // Start is called before the first frame update
    void Start()
    {
        text.gameObject.GetComponent<Renderer>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (fadeStarted && !fadeCompleted)
        {
            alphaValue += Time.deltaTime * 1000f * fadeSpeed;
            if (alphaValue >= 240)
            {
                alphaValue = 255;
                fadeCompleted = true;
            }
            text.color = new Color32(colorR, colorG, colorB, (byte)alphaValue);
        }
    }

    public void FadeIn()
    {
        fadeStarted = true;
        text.gameObject.GetComponent<Renderer>().enabled = true;
        text.color = new Color32(0, 0, 0, 0);
    }

    public void setText(int secrets)
    {
        text.SetText("You seem to be a playful soul!\nTell your faerie guide that you made\n{0}\ndiscoveries!", secrets);
    }

    public void HeightText(float height)
    {
        text.SetText("Height is: " + height);
        FadeIn();
    }
}