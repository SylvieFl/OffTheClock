using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MoveGunPoint : MonoBehaviour
{

    private Vector3 mousePos;
    public GameObject bullet;
    public Transform BulletTransform;
    public bool canFire;
    private float timer;
    public float timeBetweenFiring;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector3 rotation = mousePos - transform.position;

        float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0,0,rotZ);

        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(bullet, BulletTransform.position, Quaternion.identity);
        }

        if (rotZ < -90 || rotZ > 90)
        {
            GetComponentInChildren<SpriteRenderer>().flipY = true;
        }
        else
        {
            GetComponentInChildren<SpriteRenderer>().flipY = false;
        }

            //Debug.Log(rotZ);
    }
}
