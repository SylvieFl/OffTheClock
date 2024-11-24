using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoubleJump : MonoBehaviour
{
    public AudioSource coffeeSound;
    private bool inContact = false;
    PlayerMovement playerMovement;
    // Start is called before the first frame update
    void Start()
    {
        playerMovement = GameObject.Find("Player").GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (inContact && !playerMovement.canDoubleJump)
        {
            //PlayerMovement playerMovement = GameObject.Find("Player").GetComponent<PlayerMovement>();

            playerMovement.canDoubleJump = true;
            coffeeSound.PlayOneShot(coffeeSound.clip, 1.5f);
            GameObject.Find("CoffeeUI").GetComponent<RawImage>().color = Color.white;
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            inContact = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            inContact = false;
        }
    }
}
