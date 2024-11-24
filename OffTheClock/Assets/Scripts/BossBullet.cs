using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BossBullet : MonoBehaviour
{
    //private Vector3 mousePos;
    //private Camera mainCam;
    private Rigidbody2D rb;
    public float force;
    public Vector2 destination;
    // Start is called before the first frame update
    void Start()
    {
        //mainCam = GameObject.
        rb = GetComponent<Rigidbody2D>();
        //GameObject.Find("Boss").GetComponent<Boss>().previousPlayerPosition
        //mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = GameObject.Find("Boss").GetComponent<Boss>().previousPlayerPosition - transform.position;
        //Vector2 rotation = transform.position - mousePos;
        rb.velocity = new Vector2(direction.x, direction.y).normalized * force;
        //float rot = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        //transform.rotation = Quaternion.Euler(0, 0, rot + 90);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.name);
        if (collision.gameObject.CompareTag("Player"))
        {
            //Debug.
            collision.GetComponentInParent<PlayerMovement>().Hurt();
            //Destroy(gameObject);
        }
        //else if (collision.gameObject.CompareTag("Ground"))
        //{
            //Destroy(gameObject);
        //}
    }
}
