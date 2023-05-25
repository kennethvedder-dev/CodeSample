using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

//Written by Kenneth Vedder. 2023

public class CoinObject : MonoBehaviour
{
    public Coin coinInfo;
    [SerializeField] private GameObject pickUPVFX;
    [SerializeField] private AudioClip pickUp;
    public bool picked;
    public bool interactive;
    [SerializeField] private Transform UILocation;

    [Header("")]
    public UnityEvent coinWasClicked;

    [Header("Movement Settings")]
    public float amplitude = .2f;
    public float speed;

    [Header("External logic")]
    public AudioSource aSrc;
    public Player _Player;

    SpriteRenderer spriteRend;

    void Start()
    {
        //initialize components
        spriteRend = GetComponent<SpriteRenderer>();

        if(_Player == null)
        {
            _Player = (Player)FindObjectOfType(typeof(Player));
        }
        else
        {
        }

        //set parameters
        picked = false;
        interactive = true;
        
        //call methods
        SetCoin();
        RandomizePos(); //Lastly, set random locations

    }

    void SetCoin()
    {
        spriteRend.sprite = coinInfo.coinSprite;
        spriteRend.color = coinInfo.tint;
    }

    void FixedUpdate()
    {
        Movement();
    }

    void OnMouseDown()
    {
        PickCoin();
    }

    public void PickCoin()
    {
       if(!picked && interactive)
       {
         picked = true;
         _Player.coinAmount += coinInfo.worth;

         pickUPVFX.SetActive(true);
         pickUPVFX.transform.position = transform.position;
         aSrc.PlayOneShot(pickUp);

         coinWasClicked.Invoke(); 
       }
       else
       {
           Debug.Log("Coin is not interactable");
       }

    }

    void Movement()
    {
        if(picked)
        {
            transform.position = Vector3.Lerp(transform.position, UILocation.transform.position, Time.deltaTime * speed * 3);
        }
        else
        {
            transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y + amplitude * Mathf.Sin(Time.time * speed));
        }
    }

    public void RandomizePos()
    {
        transform.position = new Vector2(Random.Range(-4,5),
                                         Random.Range(-3,5));
    }
}
