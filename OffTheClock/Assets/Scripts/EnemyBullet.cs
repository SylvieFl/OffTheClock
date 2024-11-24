using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    //private Vector3 mousePos;
    //private Camera mainCam;
    private Rigidbody2D rb;
    public float force;
    // Start is called before the first frame update
    void Start()
    {
        //mainCam = GameObject.
        rb = GetComponent<Rigidbody2D>();
        //mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = GameObject.Find("Player").transform.position - transform.position;
        //Vector2 rotation = transform.position - mousePos;
        rb.velocity = new Vector2(direction.x, direction.y).normalized * force;
        //float rot = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        //transform.rotation = Quaternion.Euler(0, 0, rot + 90);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
