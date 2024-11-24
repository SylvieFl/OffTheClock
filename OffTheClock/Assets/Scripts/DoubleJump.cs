using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoubleJump : MonoBehaviour
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
        PlayerMovement playerMovement = collision.GetComponentInParent<PlayerMovement>();

        if (playerMovement != null )
        {
            playerMovement.canDoubleJump = true;
            GameObject.Find("CoffeeUI").GetComponent<RawImage>().color = Color.white;
            Destroy(gameObject);
        }
    }
}
