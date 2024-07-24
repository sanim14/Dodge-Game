using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTo : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Transform target;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 newPos = Vector2.MoveTowards(transform.position, target.position, .1f);
        transform.position = newPos;
    }
}
