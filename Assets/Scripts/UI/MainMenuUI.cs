using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuUI : MonoBehaviour
{
    private void Start()
    {        

    }
    public void StartButton()
    {
        SceneManagement.instance.StartGame();
        BackgroundMusic.instance.LoadinGameMusic();
    }
    public void ExitButton()
    {
        SceneManagement.instance.ExitGame();
    }
}
