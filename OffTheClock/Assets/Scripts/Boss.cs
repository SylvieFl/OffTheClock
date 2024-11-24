using System.Collections;
using System.Collections.Generic;
using Unity.Hierarchy;
using UnityEngine;
using UnityEngine.Windows;

public class Boss : MonoBehaviour
{
    // Start is called before the first frame update
    public LayerMask layerMask;
    public GameObject BossBullet;
    private bool canFire = true;
    //public Animator animator;
    public LineRenderer lineRenderer;
    private float laserLevel = 1f;
    private bool hasPosition = false;
    public Vector3 previousPlayerPosition;

    public int health = 5;

    void Start()
    {
        lineRenderer.startWidth = laserLevel;
        lineRenderer.endWidth = laserLevel;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 direction = GameObject.Find("Player").transform.position - transform.position;

        RaycastHit2D ray = Physics2D.Raycast(transform.position, direction, Mathf.Infinity, layerMask);

        lineRenderer.SetPosition(0, new Vector3(transform.position.x, transform.position.y, 1));
        Vector3 playerTransform = GameObject.Find("Player").transform.position;
        lineRenderer.SetPosition(1, new Vector3(playerTransform.x, playerTransform.y, 1));
        Vector3 difference = (GameObject.Find("Player").transform.position - transform.position) * 30f;
        difference.z = 1;
        lineRenderer.SetPosition(2, difference);

        if (laserLevel < 0f)
        {
            lineRenderer.startWidth = 0f;
            lineRenderer.endWidth = 0f;
            if (!hasPosition)
            {
                previousPlayerPosition = GameObject.Find("Player").transform.position;
                hasPosition = true;
            }
           

            if (laserLevel < -0.3 && canFire)
            {
                //Debug.Log("FIRE");
                Instantiate(BossBullet, transform.position + (direction.normalized * 3), Quaternion.identity);
                canFire = false;
            }
            if (laserLevel < -0.8f)
            {
                laserLevel = 1f;
                hasPosition = false;
                //canFire = false;
            }
        }
        else
        {
            lineRenderer.startWidth = laserLevel;
            lineRenderer.endWidth = laserLevel;
            canFire = true;
        }
        laserLevel -= 0.008f;
        //Debug.Log(laserLevel);
        //Debug.DrawRay(transform.position, direction);

        //    if (ray.collider.gameObject.CompareTag("Player") && ableToShoot)
        //    {
        //        //Debug.Log("g");
        //        Instantiate(EnemyBullet, transform.position + (direction.normalized * 3), Quaternion.identity);
        //        StartCoroutine(waiter());
        //    }

        //    if (health < 1)
        //    {
        //        //Debug.Log(health);
        //        Destroy(gameObject);
        //    }

        //    if (GameObject.Find("Player").transform.position.x > transform.position.x)
        //    {
        //        GetComponent<SpriteRenderer>().flipX = true;
        //    }
        //    else
        //    {
        //        GetComponent<SpriteRenderer>().flipX = false;
        //    }
        //}

        //void ShootPlayer()
        //{
        //    Instantiate(EnemyBullet, transform.position, Quaternion.identity);
    }

    IEnumerator waiter()
    {
        //animator.SetBool("IsShooting", true);
        //ableToShoot = false;
        yield return new WaitForSeconds(2.0f);
        Debug.Log("end");

        lineRenderer.startWidth = 1f;
        lineRenderer.endWidth = 1f;
        //ableToShoot = true;
        //animator.SetBool("IsShooting", false);
    }
}
