using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance = null;

    [Header("Panel references")]
    public GameObject MainMenu;
    public GameObject InGame;
    public GameObject Win;
    public GameObject Lose;
    public List<Text> levelTexts;
    public GameObject awesomeText;
    

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    public void SpawnAwesomeText(Vector3 pos, string s)
    {
        GameObject g = Instantiate(awesomeText, pos, Quaternion.identity);
        g.GetComponentInChildren<TextMeshPro>().text = s;
    }

    public void UpdateState(EnumsManager.GameState state)
    {

        switch (state)
        {
            case EnumsManager.GameState.MainMenu:

                MainMenu.SetActive(true);
                InGame.SetActive(false);
                Win.SetActive(false);
                Lose.SetActive(false);

                break;

            case EnumsManager.GameState.InGame:

                MainMenu.SetActive(false);
                InGame.SetActive(true);
                Win.SetActive(false);
                Lose.SetActive(false);

                break;

            case EnumsManager.GameState.Win:

                MainMenu.SetActive(false);
                InGame.SetActive(false);
                Win.SetActive(true);
                Lose.SetActive(false);

                break;

            case EnumsManager.GameState.Lose:

                MainMenu.SetActive(false);
                InGame.SetActive(false);
                Win.SetActive(false);
                Lose.SetActive(true);

                break;

        }

    }

    public void UpdateLevelText(int level)
    {
        foreach(Text t in levelTexts)
        {
            t.text = "Level " + level;
        }    
    }
}
