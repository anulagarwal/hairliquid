using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{

    public static GameManager Instance = null;

    public int currentLevel;
    public EnumsManager.GameState currentState;
    public GameObject confetti;
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }



    // Start is called before the first frame update
    void Start()
    {
        SoundManager.Instance.PlaySound(EnumsManager.Sound.LiquidFill);
        TinySauce.OnGameStarted();
        currentLevel = PlayerPrefs.GetInt("level", 1);
        UIManager.Instance.UpdateLevelText(1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartLevel()
    {

    }


    public void Win()
    {        
        confetti.SetActive(true);
        Invoke("WinScreen", 2f);
        currentLevel++;
        PlayerPrefs.SetInt("level", currentLevel);
    }

    public void WinScreen()
    {
        TinySauce.OnGameFinished(false,0);
        UpdateState(EnumsManager.GameState.Win);
    }
    public void Lose()
    {
        Invoke("LoseScreen", 2f);
    }

    public void LoseScreen()
    {
        TinySauce.OnGameFinished(true, 0);
        UpdateState(EnumsManager.GameState.Lose);

    }
    public void LoadLevel(string s)
    {
        SceneManager.LoadScene(s);
    }
    
    public void UpdateState(EnumsManager.GameState state)
    {
        currentState = state;
        UIManager.Instance.UpdateState(currentState);
    }
    
}
