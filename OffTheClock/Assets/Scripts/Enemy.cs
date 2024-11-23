using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
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
                //Debug.Log(playerMovement.canDash);
                Destroy(gameObject);
            }
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
