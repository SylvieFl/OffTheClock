using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

public class EnemyShooter : MonoBehaviour
{
    // Start is called before the first frame update
    public LayerMask layerMask;
    public GameObject EnemyBullet;
    private bool ableToShoot = true;
    public Animator animator;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = GameObject.Find("Player").transform.position - transform.position;

        RaycastHit2D ray = Physics2D.Raycast(transform.position, direction, Mathf.Infinity, layerMask);
        //Debug.DrawRay(transform.position, direction);

        if (ray.collider.gameObject.CompareTag("Player") && ableToShoot)
        {
            Instantiate(EnemyBullet, transform.position + (direction.normalized * 3), Quaternion.identity);
            StartCoroutine(waiter());
        }
    }

    //void ShootPlayer()
    //{
    //    Instantiate(EnemyBullet, transform.position, Quaternion.identity);
    //}

    IEnumerator waiter()
    {
        animator.SetBool("IsShooting", true);
        ableToShoot = false;
        yield return new WaitForSeconds(2.0f);

        ableToShoot = true;
        animator.SetBool("IsShooting", false);
    }
}
