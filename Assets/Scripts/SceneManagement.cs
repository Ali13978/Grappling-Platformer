using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneManagement : MonoBehaviour
{
    #region Singleton
    public static SceneManagement instance;
    private void Awake()
    {
        instance = this;
    }
    #endregion
    public void StartGame()
    {
        SceneManager.LoadScene(PlayerPrefs.GetInt("LevelNumber"));
    }

    public void LoadMainmenu()
    {
        SceneManager.LoadScene(0);
        BackgroundMusic.instance.LoadMainMenuMusicClip();
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
