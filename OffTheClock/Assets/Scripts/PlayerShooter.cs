using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooter : MonoBehaviour
{
    //public GameObject staple;
    public LineRenderer lineRenderer;
    public LayerMask layerMask;
    public Transform playerTransform;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            DrawLine();


            RaycastHit2D rayCastHit = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y), Input.mousePosition, Mathf.Infinity, layerMask);
            
            if (rayCastHit.collider != null)
            {
                Debug.Log("HIT");
            }
        }
    }

    void DrawLine()
    {
        Vector2 playerPosition = transform.position;
        Vector2 screenMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //Vector2 worldMousePos = Camera.main.ScreenToWorldPoint(new(screenMousePos.x, screenMousePos.y, transform.position.z - Camera.main.transform.position.z));
        //mousePosition.z = 0;
        //float angle = Mathf.Atan2(b.Y - a.Y, b.X - a.X);
        //Debug.Log(angle);
        ////Vector3 mousePosition = Input.mousePosition;
        //Vector2 combinedPosition = playerPosition - worldMousePos;
        //combinedPosition.Normalize();
        //combinedPosition *= 10;
        ////float distance = combinedPosition.magnitude;
        ////Vector3 direction = combinedPosition / distance;

        Vector3[] points = new Vector3[3];
        points[0] = playerTransform.position;
        points[1] = screenMousePos;
        Vector3 difference = new Vector3(points[1].x - points[0].x, points[1].y - points[0].y);

        float val;

        if (difference.x > difference.y)
        {
            val = 15 / difference.x;
        }
        //Vector3 difference2 = new Vector3(difference.x - points[0].x, difference.y - points[0].y);
        //points[2] = new Vector3(points[1].x + difference.x, points[1].y + difference.y);
        //Debug.Log(mousePosition);

        lineRenderer.startWidth = 0.1f;
        lineRenderer.endWidth = 0.1f;
        lineRenderer.startColor = new Color(0.0f, 0.0f, 0.0f, 0.0f);
        lineRenderer.endColor = Color.white;
        lineRenderer.positionCount = 3;
        lineRenderer.SetPositions(points);
    }
}
