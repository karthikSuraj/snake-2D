using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class headMovement : MonoBehaviour
{
  public  List<Transform> _body = new List<Transform>();
    public Transform  body;
    public GameObject gameOver;
    public Button restart;
    int horizontal = 1;
    int vertical = 0;
    int score = 0;
    bool die = false;
    public TextMeshProUGUI scoreText;
    public string playerName;
    public int playerNUmber;

    
   
    // Start is called before the first frame update
    void Start()
    {
        Time.fixedDeltaTime = 0.5f;
        
    }
    private void Awake()
    {
        
        restart.onClick.AddListener(RESET);
        if (playerNUmber == 1)
            playerName = gameManager.instance.playerONEName; 
        if (playerNUmber == 2)
            playerName = gameManager.instance.playertwoName;
        refreshUI();

    }

    private void RESET()
    {
        gameManager.instance.Reset();
        SceneManager.LoadScene(0);
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!die)
        direction();
    }
    private void FixedUpdate()
    {
        if(!die)
        {
            follower();
            move();
        }
       
        


    }

    void direction()
    {   
        if(playerNUmber==1)
        {
            gameManager.instance.playerOneScore = score;
            if (Input.GetKeyDown(KeyCode.W) && horizontal != 0)
            {
                transform.rotation = Quaternion.Euler(0, 0, 90);
                horizontal = 0;
                vertical = 1;
            }
            else if (Input.GetKeyDown(KeyCode.S) && horizontal != 0)
            {
                transform.rotation = Quaternion.Euler(0, 0, -90);
                horizontal = 0;
                vertical = -1;
            }
            else if (Input.GetKeyDown(KeyCode.A) && vertical != 0)
            {
                transform.rotation = Quaternion.Euler(0, 0, 180);

                horizontal = -1;
                vertical = 0;
            }
            else if (Input.GetKeyDown(KeyCode.D) && vertical != 0)
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);
                horizontal = 1;
                vertical = 0;
            }
        }else if(playerNUmber==2)
        {
            gameManager.instance.PlayerTwoScore = score;
            if (Input.GetKeyDown(KeyCode.UpArrow) && horizontal != 0)
            {
                transform.rotation = Quaternion.Euler(0, 0, 90);
                horizontal = 0;
                vertical = 1;
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow) && horizontal != 0)
            {
                transform.rotation = Quaternion.Euler(0, 0, -90);
                horizontal = 0;
                vertical = -1;
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow) && vertical != 0)
            {
                transform.rotation = Quaternion.Euler(0, 0, 180);

                horizontal = -1;
                vertical = 0;
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow) && vertical != 0)
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);
                horizontal = 1;
                vertical = 0;
            }
        }

       
        
    }
    void move()
    {
        float x = Mathf.Round(this.transform.position.x) + horizontal;
        float y = Mathf.Round(this.transform.position.y) + vertical;
        this.transform.position = new Vector2(x, y);
    }
     void Grow()
    {

        Transform tail = Instantiate(body);
        tail.position = _body[_body.Count - 1].position;
        _body.Add(tail);
    }
                     

    void follower()
    {
        for(int i = _body.Count-1; i>0 ; i--)
        {
            _body[i].position = _body[i - 1].position;
            //float y = Mathf.Round(_body[i].transform.position.y) - vertical;
            //float x = Mathf.Round(_body[i].transform.position.x) - horizontal;
            //_body[i].transform.position = new Vector3(x, y, 0);
        }
    }
        
   

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.GetComponent<foodManager>()!=null)
        {
            Grow();
         // collision.gameObject.transform.position = new Vector3(Random.Range(-10.0f, 10.0f), Random.Range(-4.5f, 4.27f), 0);
            foodManager fm = collision.gameObject.GetComponent<foodManager>();
            if(fm.nameOFTheFood== "YellowPepper")
            {
                score += fm.PickUpPoints;
                refreshUI();
               
            } 
            if(fm.nameOFTheFood== "strawBerry")
            {
                score += fm.PickUpPoints;
                refreshUI();

            }
        }



        if (collision.gameObject.CompareTag("body") || (collision.gameObject.CompareTag("walls")))
        {
            die = true;
            if (playerNUmber == 1)
                gameManager.instance.player1dead = die;
            else if (playerNUmber == 2)
                gameManager.instance.player2dead = die;

            gameOver.SetActive(die);
            gameManager.instance.gameOverDisplay();
        }
                                  
     }
    void refreshUI()
    {
        scoreText.text = playerName +" : "+ score.ToString();
    }
}

