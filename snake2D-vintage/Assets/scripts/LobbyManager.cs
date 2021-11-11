using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class LobbyManager : MonoBehaviour
{

    public GameObject singlePlayerMenu;
    public GameObject multiPlayerMenu;
    public GameObject helpMenue;
    public Button singlePlayerMenuBackButton;
    public Button multiPlayerMenuBackButton;
    public Button helpBackButton;
    public Button singlePlayer;
    public Button  multiPlayer;
    public Button help;
    public Button singleOkay;
    public Button MultiOkay;
    public TMP_InputField singleplayerOneName; 
    public TMP_InputField multiplayerOneName;
    public TMP_InputField multiplayerTwoName;
   
  



    // Start is called before the first frame update
    private void Awake()
    {
        AddListners();
    }

    private void openGameTwo()
    {
        gameManager.instance.playerONEName = multiplayerOneName.text;
        gameManager.instance.playertwoName = multiplayerTwoName.text;
        gameManager.instance.SingleGameMode = false;
        gameManager.instance.Reset();
        SceneManager.LoadScene(1);
        RemoveListners();
        
       
    }

    private void openGameOne()
    {
        SceneManager.LoadScene(1);
        gameManager.instance.SingleGameMode = true;
        gameManager.instance.Reset();
        gameManager.instance.playerONEName = singleplayerOneName.text;
        RemoveListners();
    }

    private void closeHelpMenu()
    {
        helpMenue.gameObject.SetActive(false);
    }

    private void closeMultiPLayerMenu()
    {
        multiPlayerMenu.gameObject.SetActive(false);
    }

    private void closeSingleMenu()
    {
        singlePlayerMenu.gameObject.SetActive(false);
    }

    private void OpenHelpmenu()
    {
        helpMenue.gameObject.SetActive(true);
    }

    private void OpenMultiPlayerMenu()
    {
        multiPlayerMenu.gameObject.SetActive(true);
    }

    private void OpenSinglePlayerMenu()
    {
        singlePlayerMenu.gameObject.SetActive(true); 
    }

   private void AddListners()
    {
        singlePlayer.onClick.AddListener(OpenSinglePlayerMenu);
        multiPlayer.onClick.AddListener(OpenMultiPlayerMenu);
        help.onClick.AddListener(OpenHelpmenu);
        singlePlayerMenuBackButton.onClick.AddListener(closeSingleMenu);
        multiPlayerMenuBackButton.onClick.AddListener(closeMultiPLayerMenu);
        helpBackButton.onClick.AddListener(closeHelpMenu);
        singleOkay.onClick.AddListener(openGameOne);
        MultiOkay.onClick.AddListener(openGameTwo);
    }

    private void RemoveListners()
    {
        singlePlayer.onClick.RemoveAllListeners();
        multiPlayer.onClick.RemoveAllListeners();
        help.onClick.RemoveAllListeners();
        singlePlayerMenuBackButton.onClick.RemoveAllListeners();
        multiPlayerMenuBackButton.onClick.RemoveAllListeners();
        helpBackButton.onClick.RemoveAllListeners();
        singleOkay.onClick.RemoveAllListeners();
        MultiOkay.onClick.RemoveAllListeners();
    }
}
