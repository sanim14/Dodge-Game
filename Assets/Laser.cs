using UnityEngine;

public class Laser : MonoBehaviour
{
    private bool isBlinking = true;
    private float timeSinceLastBlink = 0f;
    private float blinkInterval = 0.2f; // Adjust as needed
    private int blinkCount = 0;
    private int maxBlinkCount = 10; // Adjust as needed
    private float timeSinceLastReset = 0f;
    private float resetInterval = 5f; // Time interval before resetting

    void Start()
    {
        // Set visibility to false at the start
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<Collider2D>().enabled = false;
    }

    public bool getIsBlinking()
    {
        return isBlinking;
    }

    void Update()
    {
        if(GetComponent<SpriteRenderer>().enabled == false)
        {
            GetComponent<Collider2D>().enabled = false;
            GetComponent<AudioSource>().Stop();
        }


        if (isBlinking)
        {
            timeSinceLastBlink += Time.deltaTime;

            if (timeSinceLastBlink >= blinkInterval)
            {
                ToggleVisibility();
                timeSinceLastBlink = 0f;
                blinkCount++;

                if (blinkCount >= maxBlinkCount)
                {
                    isBlinking = false;
                    ToggleVisibility(); // Ensure visibility is on after blinking
                    GetComponent<Collider2D>().enabled = true;
                    GetComponent<AudioSource>().Play();
                    blinkCount = 0;
                }
            }
        }
        else
        {
            timeSinceLastReset += Time.deltaTime;

            if (timeSinceLastReset >= resetInterval)
            {
                // Start blinking again
                isBlinking = true;
                GetComponent<Collider2D>().enabled = false;
                GetComponent<AudioSource>().Stop();
                timeSinceLastReset = 0f;
            }
        }
    }

    void ToggleVisibility()
    {
        if (GetComponent<SpriteRenderer>() != null)
        {
            GetComponent<SpriteRenderer>().enabled = !GetComponent<SpriteRenderer>().enabled;
        }
        else
        {
            Debug.LogError("SpriteRenderer not found on the GameObject. Make sure it is attached.");
        }
    }
}
