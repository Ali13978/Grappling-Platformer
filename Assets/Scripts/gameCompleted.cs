using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameCompleted : MonoBehaviour
{
    private void Awake()
    {
        PlayerPrefs.SetInt("LevelNumber", 1);
    }
}
