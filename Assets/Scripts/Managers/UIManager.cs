using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

//Written by Kenneth Vedder. 2023

public class UIManager : MonoBehaviour
{
    public Image mainShade;
    public float shadeFadeSpeed;
    public bool inSequence;
    
    public UnityEvent checkAfterSequence;

    public bool overrideStart;
    //
    private Color myColor;
    private float alphaVal;
    float dimShadeValue;

    void Start()
    {
        if(!overrideStart)
        {
            SetShadeValue(0.7f); // initializing value
            SetShade(false);
        }
        else
        {
            Debug.Log("Start values are being overriden");
        }
    }

    //These methods work to set the private values from external sources
    public void SetAlphaValue(float value)
    {
        alphaVal = value;
    }

    public void SetShadeValue(float value)
    {
        dimShadeValue = value;
    }
    //
    
    public void SetShade(bool dimTheScene)
    {
        if(dimTheScene)
        {
            StartCoroutine(FadeShade(alphaVal, dimShadeValue, true));
        }
        else
        {
            StartCoroutine(FadeShade(alphaVal, 0, false));
        }
    }

    public void SequenceState(bool playing)
    {
        if(playing)
        {
            inSequence = true;
        }
        else
        {
            inSequence = false;
            checkAfterSequence.Invoke();
        }
    }

    //----//

    IEnumerator FadeShade(float startVal, float endVal, bool inOrOut)
    {
        float myNum = 0;
        
        mainShade.gameObject.SetActive(true);

        while(myNum < shadeFadeSpeed)
        {
            myNum += Time.deltaTime;
            alphaVal = Mathf.Lerp(startVal, endVal, myNum/shadeFadeSpeed);

            myColor.a = alphaVal;
            mainShade.color = myColor;

            yield return null;
        }

        if(!inOrOut)
        {
            mainShade.gameObject.SetActive(false);
            SequenceState(false);
        }
        else
        {
        }   
    }
}
