using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SnakeTeil : MonoBehaviour
{
    public Transform SnakeHead;
    public float CircleDiameter;
    public float Interval = 0.2f;
    public TextMeshPro hitpointText;
    public PlayerControl Player;
    
   // public AudioPlayer AudioPlayer;
    public int Hitpoints { get; private set; }
    public Game Game;
    ParticleSystem particle;
    public AudioSource audioSource;

    private List<Transform> snakeCircles = new List<Transform>();
    private List<Vector3> positions = new List<Vector3>();
    private float Timer = 0;

    public DeathScence DeathScence;

    void Start()
    {
        positions.Add(SnakeHead.position);
        particle = GetComponent<ParticleSystem>();
        particle.Stop();
        
    }

    void Update()
    {
        Timer -= Time.deltaTime;

        float distance = (SnakeHead.position - positions[0]).magnitude;

        if (distance > CircleDiameter)
        {
            Vector3 direction = (SnakeHead.position - positions[0]).normalized;

            positions.Insert(0, positions[0] + direction * CircleDiameter);
            positions.RemoveAt(positions.Count - 1);

            distance -= CircleDiameter;
        }

        for (int i = 0; i < snakeCircles.Count; i++)
        {
            snakeCircles[i].position = Vector3.Lerp(positions[i + 1], positions[i], distance / CircleDiameter);
        }
    }

    public void AddCircle()
    {
        Hitpoints++;
        hitpointText.text = (Hitpoints + 1).ToString();
        Transform circle = Instantiate(SnakeHead, positions[positions.Count - 1], Quaternion.identity, transform);
        snakeCircles.Add(circle);
        positions.Add(circle.position);
    }

    public void RemoveCircle()
    {
        int lastIndex = snakeCircles.Count - 1;

        if (snakeCircles.Count <= 0) 
        {
            
            Game.OnPlayerDied();
            DeathScence.Death();
            

        }
        else
        {
            Hitpoints--;
            hitpointText.text = (Hitpoints + 1).ToString();
            Destroy(snakeCircles[lastIndex].gameObject);
            snakeCircles.RemoveAt(lastIndex);
            positions.RemoveAt(lastIndex + 1);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.TryGetComponent(out Food food))
        {
            for (int i = 0; i < food.value; i++)    
            {
                AddCircle();
                
            }
            audioSource.Play();
            Destroy(food.gameObject);  
        }
    }

    private void OnCollisionStay(Collision other)
    {
        if (Timer <= 0 && other.gameObject.TryGetComponent(out Block block))
        {
          
            RemoveCircle();
            Timer = Interval;
            particle.Play();
           
   
        }
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.TryGetComponent(out Block block))
        {
            particle.Stop();
        }
        else
        {
            particle.Play();
        }
   
    
    }
}