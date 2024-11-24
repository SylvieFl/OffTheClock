using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bullet : MonoBehaviour
{
    private Vector3 mousePos;
    private Camera mainCam;
    private Rigidbody2D rb;
    public float force;
    //public Transform target;

    // Start is called before the first frame update
    void Start()
    {
        //mainCam = GameObject.
        rb = GetComponent<Rigidbody2D>();
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = mousePos - GameObject.Find("Player").transform.position;
        Vector3 rotation = transform.position - mousePos;
        rb.velocity = new Vector2(direction.x, direction.y).normalized * force;
        float rot = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rot + 90);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log(collision.gameObject.name);
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Enemy") || (collision.gameObject.CompareTag("ShooterEnemy")))
        {
            if (collision.gameObject.CompareTag("ShooterEnemy"))
            {
                collision.GetComponent<EnemyShooter>().health -= 1;
                if (collision.GetComponent<EnemyShooter>().health < 1)
                {
                    PlayerMovement playerMovement = GameObject.Find("Player").GetComponent<PlayerMovement>();
                    playerMovement.canDash = true;
                }
                Color color = collision.GetComponent<SpriteRenderer>().color;
                //color.r -= 0.1f;
                color.b -= 0.1f;
                color.g -= 0.1f;
                collision.GetComponent<SpriteRenderer>().color = color;
            }
            Destroy(gameObject);
        }
        else if (collision.gameObject.CompareTag("Boss")) //End the game
        {
            SceneManager.LoadScene(6);
        }


    }
}
