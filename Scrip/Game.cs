using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    public PlayerControl Player;
    public GameObject Loss;
    public GameObject Finish;

    
    public Rigidbody Rigidbody;

    public enum State
    {
        Playing,
        Finish,
        Loss,
    }

    public State CurrentState { get; private set; }

    public void OnPlayerDied()
    {
        if (CurrentState != State.Playing) return;
        
        CurrentState = State.Loss;
        Player.enabled = false;

    }

    
    public void YouFinish()
    {
        CurrentState = State.Finish;
        Player.enabled = false;
     
    }

    private void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }
}

