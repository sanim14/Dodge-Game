using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPointFollower : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] List<GameObject> list = new List<GameObject>();
    [SerializeField] int currentWP = 0;
    [SerializeField] float speed;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        Vector2 goal = list[currentWP].transform.position;
        Vector2 newPos = Vector2.MoveTowards(transform.position, list[currentWP].transform.position, speed*Time.deltaTime);
        transform.position = newPos;

        if(Mathf.Abs(transform.position.x-goal.x) < .1 && Mathf.Abs(transform.position.y-goal.y) < .1)
        {
            currentWP = (currentWP+1)%list.Count;
        }
    }
}