using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public RawImage noDash;
    public AudioSource deathSound;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            //Rigidbody2D rigidbody = collision.GetComponent<Rigidbody2D>();
            //rigidbody.velocity = Vector2.zero;
            //collision.transform.position = transform.position;
            PlayerMovement playerMovement = GameObject.Find("Player").GetComponent<PlayerMovement>();

            if (playerMovement != null)
            {
                playerMovement.canDash = true;
                noDash.enabled = false;
                deathSound.Play();
                //Debug.Log(playerMovement.canDash);

                Destroy(gameObject);
            }
        }
        else if (collision.gameObject.CompareTag("Player"))
        {
            GameObject.Find("Player").GetComponent<PlayerMovement>().Hurt();
        }
    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.CompareTag("Bullet"))
    //    {
    //        PlayerMovement playerMovement = GameObject.Find("Player").GetComponent<PlayerMovement>();

    //        if (playerMovement != null)
    //        {
    //            playerMovement.canDash = true;
    //            Debug.Log(playerMovement.canDash);
    //            //Destroy(gameObject);
    //        }
    //    }
    //}
}
