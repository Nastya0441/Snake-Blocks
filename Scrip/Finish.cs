using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{


    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            SceneManager.LoadScene(0);
            UnLockLevel();
        }
    }

    public void UnLockLevel()
    {
        int LevelUnLock = SceneManager.GetActiveScene().buildIndex;

        if (LevelUnLock >= PlayerPrefs.GetInt("levels"))
        {
            PlayerPrefs.SetInt("levels", LevelUnLock + 1);
        }
    }
}
