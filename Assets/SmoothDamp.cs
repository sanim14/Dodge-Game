using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothDamp : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Transform target;
    Vector3 vect;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position != target.position)
        {
            Vector3 newPos = Vector3.SmoothDamp(transform.position, target.position, ref vect, .5f);
            newPos.z = -10f;
            transform.position = newPos;
        }
        else
        {
            transform.position = new Vector3(transform.position.x + .0001f, transform.position.y + .0001f, transform.position.z);
        }
    }
}
