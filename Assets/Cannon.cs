using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    [SerializeField] GameObject bullet;

    void Start()
    {
        // Invoke the Shoot method every 2 seconds, starting after 0 seconds
        InvokeRepeating("Shoot", 0f, 2f);
    }

    // This method will be invoked every 2 seconds
    void Shoot()
    {
        GameObject b = Instantiate(bullet, transform.position + transform.right * -3f, transform.rotation);
        Rigidbody2D bulletRb = b.GetComponent<Rigidbody2D>();

        // Set the velocity of the bullet to move left
        bulletRb.velocity = -transform.right * 5f;
    }
}
