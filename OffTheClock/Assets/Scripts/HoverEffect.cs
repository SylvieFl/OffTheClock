using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoverEffect : MonoBehaviour
{
    public float speed;
    public float floatSpan;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position.Set(transform.position.x, Mathf.Sin(Time.time * speed) * floatSpan / 2.0f, transform.position.z);
    }
}
