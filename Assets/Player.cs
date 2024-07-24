using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    bool up, down, right, left;
    [SerializeField] GameObject Skull1;
    [SerializeField] GameObject Skull2;
    [SerializeField] GameObject Skull3;
    [SerializeField] GameObject Skull4;
    [SerializeField] GameObject Skull5;
    [SerializeField] AudioClip death;
    private Text winText;
    //[SerializeField] Text lives;
    [SerializeField] float speed;
    bool gameOver = false;
    bool isWin = false;
    int lives = 0;
    [SerializeField] Player player;
    Rigidbody2D rb;
    private AudioSource audioSource;


    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        gameOver = false;
        isWin = false;
        winText = GameObject.Find("Win Text").GetComponent<Text>();
        winText.text = "";
        rb = GetComponent<Rigidbody2D>();
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        Skull1.GetComponent<SpriteRenderer>().enabled = false;
        Skull2.GetComponent<SpriteRenderer>().enabled = false;
        Skull3.GetComponent<SpriteRenderer>().enabled = false;
        Skull4.GetComponent<SpriteRenderer>().enabled = false;
        Skull5.GetComponent<SpriteRenderer>().enabled = false;
    }

    public void resetGame()
    {
        if (SceneManager.GetActiveScene().buildIndex == 2 && (isWin))
        {
            SceneManager.LoadScene(0);
        }
        player.transform.position = new Vector3(-7.74f, 2.6f, 0f);
        winText = GameObject.Find("Win Text").GetComponent<Text>();
        winText.text = "";
        isWin = false;
        gameOver = false;
        up = false;
        down = false;
        left = false;
        right = false;
        Skull1.GetComponent<SpriteRenderer>().enabled = false;
        Skull2.GetComponent<SpriteRenderer>().enabled = false;
        Skull3.GetComponent<SpriteRenderer>().enabled = false;
        Skull4.GetComponent<SpriteRenderer>().enabled = false;
        Skull5.GetComponent<SpriteRenderer>().enabled = false;
    }

    public bool isResetAllowed()
    {
        return isWin || gameOver;
    }

    // Update is called once per frame
    void Update()
    {
        if (isWin || gameOver)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            up = true;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            down = true;
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            left = true;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            right = true;
        }



        if (Input.GetKeyUp(KeyCode.W))
        {
            up = false;
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            down = false;
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            left = false;
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            right = false;
        }
    }

    private void FixedUpdate()
    {
        if (isWin || gameOver)
        {
            return;
        }


        Vector2 dir = Vector2.zero;

        if (up)
        {
            dir += new Vector2(0, speed * Time.deltaTime);
        }
        if (down)
        {
            dir += new Vector2(0, -speed * Time.deltaTime);
        }
        if (left)
        {
            dir += new Vector2(-speed * Time.deltaTime, 0);
        }
        if (right)
        {
            dir += new Vector2(speed * Time.deltaTime, 0);
        }

        // Limit the magnitude of the dir vector to the original speed
        dir = Vector2.ClampMagnitude(dir, speed);

        rb.velocity = dir;
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (isWin || gameOver)
        {
            return;
        }

        Obstacle[] obstacle = FindObjectsOfType<Obstacle>();
        foreach (Obstacle o in obstacle)
        {
            if (o.gameObject.Equals(collision.gameObject))
            {
                audioSource.PlayOneShot(death);
                player.transform.position = new Vector3(-7.74f, 2.6f, 0f);
                if (SceneManager.GetActiveScene().buildIndex == 0)
                {
                    if (Skull1.GetComponent<SpriteRenderer>().enabled == false)
                    {
                        Skull1.GetComponent<SpriteRenderer>().enabled = true;
                    }
                    else if (Skull2.GetComponent<SpriteRenderer>().enabled == false)
                    {
                        Skull2.GetComponent<SpriteRenderer>().enabled = true;
                    }
                    else
                    {
                        Skull3.GetComponent<SpriteRenderer>().enabled = true;
                        gameOver = true;
                        winText.text = "Game Over";
                    }
                }
                else if (SceneManager.GetActiveScene().buildIndex == 1)
                {
                    if (Skull1.GetComponent<SpriteRenderer>().enabled == false)
                    {
                        Skull1.GetComponent<SpriteRenderer>().enabled = true;
                    }
                    else if (Skull2.GetComponent<SpriteRenderer>().enabled == false)
                    {
                        Skull2.GetComponent<SpriteRenderer>().enabled = true;
                    }
                    else if (Skull3.GetComponent<SpriteRenderer>().enabled == false)
                    {
                        Skull3.GetComponent<SpriteRenderer>().enabled = true;
                    }
                    else
                    {
                        Skull4.GetComponent<SpriteRenderer>().enabled = true;
                        gameOver = true;
                        winText.text = "Game Over";
                    }
                }
                else
                {
                    if (Skull1.GetComponent<SpriteRenderer>().enabled == false)
                    {
                        Skull1.GetComponent<SpriteRenderer>().enabled = true;
                    }
                    else if (Skull2.GetComponent<SpriteRenderer>().enabled == false)
                    {
                        Skull2.GetComponent<SpriteRenderer>().enabled = true;
                    }
                    else if (Skull3.GetComponent<SpriteRenderer>().enabled == false)
                    {
                        Skull3.GetComponent<SpriteRenderer>().enabled = true;
                    }
                    else if (Skull4.GetComponent<SpriteRenderer>().enabled == false)
                    {
                        Skull4.GetComponent<SpriteRenderer>().enabled = true;
                    }
                    else
                    {
                        Skull5.GetComponent<SpriteRenderer>().enabled = true;
                        gameOver = true;
                        winText.text = "Game Over";
                    }
                }
            }
        }

        GreenBox[] greenBox = FindObjectsOfType<GreenBox>();
        foreach (GreenBox g in greenBox)
        {
            if (g.gameObject.Equals(collision.gameObject))
            {
                if (SceneManager.GetActiveScene().buildIndex == 0)
                {
                    if (Skull1.GetComponent<SpriteRenderer>().enabled == true)
                    {
                        lives++;
                    }
                    if (Skull2.GetComponent<SpriteRenderer>().enabled == true)
                    {
                        lives++;
                    }
                    if (Skull3.GetComponent<SpriteRenderer>().enabled == true)
                    {
                        lives++;
                    }
                    if (Skull4.GetComponent<SpriteRenderer>().enabled == true)
                    {
                        lives++;
                    }
                    if (Skull5.GetComponent<SpriteRenderer>().enabled == true)
                    {
                        lives++;
                    }
                    GameObject.FindObjectOfType<Manager>().saveLives(lives);
                    SceneManager.LoadScene(1);
                }
                if (SceneManager.GetActiveScene().buildIndex == 1)
                {
                    SceneManager.LoadScene(2);
                }
                if (SceneManager.GetActiveScene().buildIndex == 2)
                {
                    winText = GameObject.Find("Win Text").GetComponent<Text>();
                    winText.text = "You win!";
                    isWin = true;
                }
            }
        }

        Bullet[] bullet = FindObjectsOfType<Bullet>();
        foreach (Bullet b in bullet)
        {
            if (b.gameObject.Equals(collision.gameObject))
            {
                player.transform.position = new Vector3(-7.74f, 2.6f, 0f);
                if (SceneManager.GetActiveScene().buildIndex == 0)
                {
                    if (Skull1.GetComponent<SpriteRenderer>().enabled == false)
                    {
                        Skull1.GetComponent<SpriteRenderer>().enabled = true;
                    }
                    else if (Skull2.GetComponent<SpriteRenderer>().enabled == false)
                    {
                        Skull2.GetComponent<SpriteRenderer>().enabled = true;
                    }
                    else
                    {
                        Skull3.GetComponent<SpriteRenderer>().enabled = true;
                        gameOver = true;
                        winText.text = "Game Over";
                    }
                }
                else if (SceneManager.GetActiveScene().buildIndex == 1)
                {
                    if (Skull1.GetComponent<SpriteRenderer>().enabled == false)
                    {
                        Skull1.GetComponent<SpriteRenderer>().enabled = true;
                    }
                    else if (Skull2.GetComponent<SpriteRenderer>().enabled == false)
                    {
                        Skull2.GetComponent<SpriteRenderer>().enabled = true;
                    }
                    else if (Skull3.GetComponent<SpriteRenderer>().enabled == false)
                    {
                        Skull3.GetComponent<SpriteRenderer>().enabled = true;
                    }
                    else
                    {
                        Skull4.GetComponent<SpriteRenderer>().enabled = true;
                        gameOver = true;
                        winText.text = "Game Over";
                    }
                }
                else
                {
                    if (Skull1.GetComponent<SpriteRenderer>().enabled == false)
                    {
                        Skull1.GetComponent<SpriteRenderer>().enabled = true;
                    }
                    else if (Skull2.GetComponent<SpriteRenderer>().enabled == false)
                    {
                        Skull2.GetComponent<SpriteRenderer>().enabled = true;
                    }
                    else if (Skull3.GetComponent<SpriteRenderer>().enabled == false)
                    {
                        Skull3.GetComponent<SpriteRenderer>().enabled = true;
                    }
                    else if (Skull4.GetComponent<SpriteRenderer>().enabled == false)
                    {
                        Skull4.GetComponent<SpriteRenderer>().enabled = true;
                    }
                    else
                    {
                        Skull5.GetComponent<SpriteRenderer>().enabled = true;
                        gameOver = true;
                        winText.text = "Game Over";
                    }
                }
            }
        }

        Laser[] laser = FindObjectsOfType<Laser>();
        foreach (Laser l in laser)
        {
            if (l.gameObject.Equals(collision.gameObject))
            {
                if (l.getIsBlinking() == false)
                {
                    audioSource.PlayOneShot(death);
                    player.transform.position = new Vector3(-7.74f, 2.6f, 0f);
                    if (SceneManager.GetActiveScene().buildIndex == 0)
                    {
                        if (Skull1.GetComponent<SpriteRenderer>().enabled == false)
                        {
                            Skull1.GetComponent<SpriteRenderer>().enabled = true;
                        }
                        else if (Skull2.GetComponent<SpriteRenderer>().enabled == false)
                        {
                            Skull2.GetComponent<SpriteRenderer>().enabled = true;
                        }
                        else
                        {
                            Skull3.GetComponent<SpriteRenderer>().enabled = true;
                            gameOver = true;
                            winText.text = "Game Over";
                        }
                    }
                    else if (SceneManager.GetActiveScene().buildIndex == 1)
                    {
                        if (Skull1.GetComponent<SpriteRenderer>().enabled == false)
                        {
                            Skull1.GetComponent<SpriteRenderer>().enabled = true;
                        }
                        else if (Skull2.GetComponent<SpriteRenderer>().enabled == false)
                        {
                            Skull2.GetComponent<SpriteRenderer>().enabled = true;
                        }
                        else if (Skull3.GetComponent<SpriteRenderer>().enabled == false)
                        {
                            Skull3.GetComponent<SpriteRenderer>().enabled = true;
                        }
                        else
                        {
                            Skull4.GetComponent<SpriteRenderer>().enabled = true;
                            gameOver = true;
                            winText.text = "Game Over";
                        }
                    }
                    else
                    {
                        if (Skull1.GetComponent<SpriteRenderer>().enabled == false)
                        {
                            Skull1.GetComponent<SpriteRenderer>().enabled = true;
                        }
                        else if (Skull2.GetComponent<SpriteRenderer>().enabled == false)
                        {
                            Skull2.GetComponent<SpriteRenderer>().enabled = true;
                        }
                        else if (Skull3.GetComponent<SpriteRenderer>().enabled == false)
                        {
                            Skull3.GetComponent<SpriteRenderer>().enabled = true;
                        }
                        else if (Skull4.GetComponent<SpriteRenderer>().enabled == false)
                        {
                            Skull4.GetComponent<SpriteRenderer>().enabled = true;
                        }
                        else
                        {
                            Skull5.GetComponent<SpriteRenderer>().enabled = true;
                            gameOver = true;
                            winText.text = "Game Over";
                        }
                    }
                }
                
            }
        }

    }

    public void startNewScene(int lives)
    {
        if (SceneManager.GetActiveScene().buildIndex == 2 || SceneManager.GetActiveScene().buildIndex == 1)
        {
            Debug.Log("HI");
            if (lives == 0)
            {
                return;
            }
            if (lives == 1)
            {
                Skull1.GetComponent<SpriteRenderer>().enabled = true;
            }
            if (lives == 2)
            {
                Skull1.GetComponent<SpriteRenderer>().enabled = true;
                Skull2.GetComponent<SpriteRenderer>().enabled = true;
            }
        }
    }

}