using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndZone : MonoBehaviour
{
    public EasterEggObserver easterEggObserver;
    public TextFade goodbyeText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        int easterEggsFound = easterEggObserver.EasterEggsfound;
        if (other.gameObject.GetComponent<Camera>() != null)
        {
            if(easterEggsFound > 0)
            {
                goodbyeText.setText(easterEggsFound);
                goodbyeText.FadeIn();
            }
   
            Debug.Log("[Debug] reached the end");
            Debug.Log("[Debug] found " + easterEggsFound + " easter eggs");
        }
    }
}
