using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Written by Kenneth Vedder. 2023

public class ChestGFX : MonoBehaviour
{
    public Animation animComp;
    public GameObject chestObject;
    public SpriteRenderer innerSprite;
    public GameObject CanvasScreen;

    [Header("")]
    public float sway;
    public float intensity;

    [Header("")]
    public float sequenceTime;

    [Header("UI Elements")]
    public Text cardNameField;
    public Text cardDescriptionField;

    [Header("SFX")]
    public AudioClip latch;
    public AudioClip bubbles;

    [Header("External logic")]
    public ChestScreen _ChestScreen;
    public SFXHandler _SFXHandler;

    float swayedNumber;

    void Awake()
    {
        //Initialize components
        animComp = GetComponent<Animation>();

        
        //Start functions
        StartSequence();
    }

    public void StartSequence()
    {
        UIShowBuyButton();
        
        animComp.Play("Start");
    }

    void Update()
    {
        //Sway(chestObject.transform); //Instead of math sway, do it with animation?
    }

    void Sway(Transform t)
    {
        swayedNumber = Mathf.PingPong(Time.time * intensity, sway);
        
        t.localEulerAngles = new Vector3 (swayedNumber, t.localEulerAngles.y, -swayedNumber);
    }

    public void GetChestInfo()
    {
        //We're hopping across the scripts references to get info
        innerSprite.sprite = _ChestScreen._Store.chestsInStock[_ChestScreen._Store._Player.chestAmount].cardSprite;

        //Getting card info. Number was getting shifted before because it was getting called in the moment of purchase, after player.chestamount increased
        cardNameField.text = _ChestScreen._Store.chestsInStock[_ChestScreen._Store._Player.chestAmount].cardName;
        cardDescriptionField.text = _ChestScreen._Store.chestsInStock[_ChestScreen._Store._Player.chestAmount].cardDescription;

    }

    public void OpenChest()
    {
        //all vfx logic here 
        UISinkButton();
        Invoke("UIShowCardText", 6);
        //
        animComp.CrossFade("Open");
    }

    public void GoAway()
    {
        UIFadeOut();
        animComp.CrossFade("Away");
    }

    //UI Anim clips

    void UISinkButton()
    {
        CanvasScreen.GetComponent<Animation>().Play("SinkBuyButton");
    }

    void UIShowBuyButton()
    {
        CanvasScreen.GetComponent<Animation>().Play("Buy");
    }

    void UIShowCardText()
    {
        CanvasScreen.GetComponent<Animation>().Play("ShowText");
    }

    void UIFadeOut()
    {
        CanvasScreen.GetComponent<Animation>().Play("FadeOut");
    }
    //

    public void PlayLatchSFX()
    {
        _SFXHandler.PlayClip(latch);
    }

    public void PlayBubblesSFX()
    {
        _SFXHandler.PlayClip(bubbles);
    }
}
