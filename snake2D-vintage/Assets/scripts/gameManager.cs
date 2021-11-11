using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameManager : MonoBehaviour
{
    public static gameManager instance;
    public string playerONEName;
    public string playertwoName;
    public int playerOneScore;
    public int PlayerTwoScore;
    public GameObject playerOne;
    public GameObject playerTWO;
    public  bool canInstanciate ;
    public GameObject gameOver;
    public bool player1dead;
    public bool player2dead;
    public bool SingleGameMode; // true - single false - multi
    public TextMeshProUGUI gameoverText;
    public TextMeshProUGUI finalscore;
    private void Awake()
    {

        if (instance == null)
        {
           
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        

    }
    private void Update()
    {
        if(SceneManager.GetActiveScene().buildIndex==1)
        {
            if (SingleGameMode && canInstanciate)
            {
                Instantiate(playerOne);
                playerOne.GetComponent<headMovement>().playerNUmber = 1;
                canInstanciate = false;

            }

            if(!SingleGameMode && canInstanciate)
            {
                Instantiate(playerOne,new Vector3(0,0,0),Quaternion.identity);
                playerOne.GetComponent<headMovement>().playerNUmber = 1;
                Instantiate(playerTWO, new Vector3(10, 0, 0), Quaternion.identity);
                playerTWO.GetComponent<headMovement>().playerNUmber = 2;
                canInstanciate = false;
            }
        }

      
       
    }
    public void gameOverDisplay()
    {
        gameoverText.gameObject.SetActive(true);
        finalscore.gameObject.SetActive(true);
        if (SingleGameMode)
        {
            if (player1dead)
                gameoverText.text = playerONEName + " is dead ";
            finalscore.text = " SCORE : " + playerOneScore;
        }
        if(!SingleGameMode)
        {
           

            if (player1dead)
                gameoverText.text = playerONEName + " is dead " + playertwoName + " won ";
            else if (player2dead)
                gameoverText.text = playertwoName + " is dead " + playerONEName + " won ";

            else if (playerOneScore > PlayerTwoScore)
                gameoverText.text = playerONEName + "  killed " + playertwoName;
            else if (playerOneScore < PlayerTwoScore)
                gameoverText.text = playertwoName + " killed " + playerONEName;



            finalscore.text = playerONEName +" score " + playerOneScore + " \n " + playertwoName + " score " + PlayerTwoScore;
        }
   

}
    public void Reset()
    {
        canInstanciate = true;
        gameoverText.gameObject.SetActive(false);
        finalscore.gameObject.SetActive(false);
    }



}
