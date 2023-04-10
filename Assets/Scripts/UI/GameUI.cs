using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GameUI : MonoBehaviour
{
    #region Singleton
    public static GameUI instance;
    private void Awake()
    {
        instance = this;
    }
    #endregion

    [Header("In-Game Pannel")]
    [SerializeField] GameObject inGamePannel;
    [SerializeField] TMP_Text coinsText;

    [Header("Death Pannel")]
    [SerializeField] GameObject deathPannel;
    [SerializeField] TMP_Text DeathCoinsTxt;

    [Header("Win Pannel")]
    [SerializeField] GameObject WinPannel;
    [SerializeField] TMP_Text WinCoinsTxt;

    public int NoOfCoinsToUnlock;
    private void Start()
    {
        AllPannelOff();
        inGamePannel.SetActive(true);
    }

    public void AllPannelOff()
    {
        inGamePannel.SetActive(false);
        deathPannel.SetActive(false);
        WinPannel.SetActive(false);
    }

    //in-game pannel
    public void UpdateCoinsText(int coins)
    {
        coinsText.text = "Coins: " + coins;
        if(coins == NoOfCoinsToUnlock)
        {
            GameObject[] doors = GameObject.FindGameObjectsWithTag("door");
            foreach (GameObject door in doors)
                GameObject.Destroy(door);
        }
    }

    //Death-pannel

    public void OnDeathPannel(int coins)
    {
        GameUI.instance.AllPannelOff();
        deathPannel.SetActive(true);

        DeathCoinsTxt.text = coins.ToString();
    }
    public void RestartBtn()
    {
        SceneManagement.instance.StartGame();
    }
    public void MainMenubtn()
    {
        SceneManagement.instance.LoadMainmenu();
    }

    //Win Pannel
    public void WinPannelOn(int coins)
    {
        AllPannelOff();
        WinPannel.SetActive(true);

        WinCoinsTxt.text = "Coins Collected: " + coins.ToString();
    }

    public void NextLevel()
    {
        SceneManagement.instance.StartGame();
    }

}
