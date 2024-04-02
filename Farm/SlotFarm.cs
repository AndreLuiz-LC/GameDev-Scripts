using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotFarm : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private SpriteRenderer spriteRenderer; 
    [SerializeField] private Sprite hole;
    [SerializeField] private Sprite carrot;
    
    [Header("Settings")]
    [SerializeField] private int digAmount; //quantiade de "escavção" ou tempo cavando para cavar o buraco
    [SerializeField] private bool detecting; 
    [SerializeField] private float waterAmount; //total de água para nascer uma cenoura


    private int initialDigAmount;
    private float currentWater;
    private bool dugHole;

    PlayerItems playerItems;

    void Start()
    {
        playerItems = FindObjectOfType<PlayerItems>();
        initialDigAmount = digAmount;
    }

    private void Update()
    {

        if(dugHole)
        {
            if(detecting)
            {
                currentWater += 0.01f;
            }
            
            //encheu o total necessário
            if(currentWater >= waterAmount) 
            {
                spriteRenderer.sprite = carrot;

                if(Input.GetKeyDown(KeyCode.E))
                {
                    spriteRenderer.sprite = hole;
                    playerItems.carrots++;
                    currentWater = 0f;
                }
            }
        }
    }

    public void OnHit()
    {
        digAmount--;

       if(digAmount <= initialDigAmount / 2)
       {
            spriteRenderer.sprite = hole; //planta o buraco com a metade da hp
            dugHole = true;
       }
       
        // if(digAmount <= 0)
        // {            
        //     spriteRenderer.sprite = carrot; //plantar cenoura
        // }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Dig"))
        {
            OnHit();
        }

        if(collision.CompareTag("Water"))
        {
            detecting = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Water"))
        {
            detecting = false;
        } 
    }
}