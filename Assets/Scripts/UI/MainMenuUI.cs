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
    }
    public void ExitButton()
    {
        SceneManagement.instance.ExitGame();
    }
}
