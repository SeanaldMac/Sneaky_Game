using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinMirror : MonoBehaviour
{
    public Text canWinText;
    private bool canPickUp = false;
    public GameObject flowerC, medsC, heartC, gc;


    void Start()
    {
        canWinText.gameObject.SetActive(false);
    }

    void Update()
    {
        if (canPickUp && Input.GetKeyDown(KeyCode.Space) && !flowerC.activeInHierarchy && !medsC.activeInHierarchy && !heartC.activeInHierarchy)
            PickUp();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            canWinText.gameObject.SetActive(true);
            canPickUp = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            canWinText.gameObject.SetActive(false);
            canPickUp = false;
        }
    }

    private void PickUp()
    {
        gameObject.SetActive(false);
        gc.GetComponent<GameController>().winner = true;
        gc.GetComponent<GameController>().GameOver();
    }
}
