using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{
    // Start is called before the first frame update
    private static GameObject original = null;
    private Text timer;
    private int previousSceneIndex = 0;
    float TimeT = 0f;
    int lives = 0;

    private void Awake()
    {
        if (original == null)
            original = gameObject;
        if (gameObject != original)
            Destroy(gameObject);
    }
    void Start()
    {
        DontDestroyOnLoad(this);

        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            GetComponent<AudioSource>().Play();
        }
    }

    public void saveLives (int livesUsed)
    {
        lives = livesUsed;
    }

    // Update is called once per frame
    void Update()
    {
        GameObject.FindObjectOfType<Player>().startNewScene(lives);

        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        if (currentSceneIndex == 0 && previousSceneIndex == 2)
        {
            // Reset the timer when transitioning from scene 9 to scene 0
            TimeT = 0f;
        }

        previousSceneIndex = currentSceneIndex;

        GameObject playerObject = GameObject.FindWithTag("Player");
        if (GameObject.FindObjectOfType<Player>().isResetAllowed() && Input.GetKey(KeyCode.R))
        {
            GameObject.FindObjectOfType<Player>().resetGame();
            playerObject.transform.position = new Vector3(-7.74f, 2.6f, 0f);
        }

        if (GameObject.FindObjectOfType<Player>().isResetAllowed())
        {
            return;
        }

        TimeT += Time.deltaTime;
        int hours = (int)TimeT / 3600;
        int min = (int)TimeT / 60;
        int seconds = (int)TimeT % 60;

        if (min / 60 >= 60)
        {
            min -= 60;
            hours++;
        }

        string TimeText = "00:00:00";
        if (hours / 10 == 0)
        {
            TimeText = "0" + hours + ":";
        }
        else
        {
            TimeText = hours + ":";
        }
        if (min / 10 == 0)
        {
            TimeText += "0" + min + ":";
        }
        else
        {
            TimeText += min + ":";
        }
        if (seconds / 10 == 0)
        {
            TimeText += "0" + seconds;
        }
        else
        {
            TimeText += seconds;
        }

        timer = GameObject.Find("Timer").GetComponent<Text>();
        timer.text = TimeText;
    }
}
