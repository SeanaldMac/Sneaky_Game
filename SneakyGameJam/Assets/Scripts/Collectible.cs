using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Collectible : MonoBehaviour
{
    public Text pickupText;
    private bool canPickUp = false;


    void Start()
    {
        pickupText.gameObject.SetActive(false);
    }

    void Update()
    {
        if (canPickUp && Input.GetKeyDown(KeyCode.Space))
            PickUp();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            pickupText.gameObject.SetActive(true);
            canPickUp = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            pickupText.gameObject.SetActive(false);
            canPickUp = false;
        }
    }

    private void PickUp()
    {
        gameObject.SetActive(false);
    }



}
