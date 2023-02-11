using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelGenerator : MonoBehaviour
{
    int LevelUnLock;
    public Button[] buttons;

    
    void Start()
    {
        LevelUnLock = PlayerPrefs.GetInt("levels", 1);
        for (int i = 0; i < buttons.Length; i++) buttons[i].interactable = LevelUnLock > i;
        
    }

    public void LoadLevel(int LevelIndex)
    { 
        SceneManager.LoadScene(LevelIndex);  
    }

}
