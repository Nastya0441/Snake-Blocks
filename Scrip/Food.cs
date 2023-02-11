using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class Food : MonoBehaviour
{
    [SerializeField]
    public int value;
    private int _Health;
    private int _Length;
    private SnakeTeil componentSnakeTail;
    public PlayerControl PlayerControl;
    public Game Game;

    

    public TextMeshPro PointsText;

    void Start()
    {
        PointsText.SetText(value.ToString());

    }


    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Food"))
        {
            value = collision.gameObject.GetComponent<Food>().value;
            _Health += value;
            PointsText.SetText(_Health.ToString());
            Destroy(collision.gameObject);
            
            


            for (int i = 0; i < value; i++)
            {
                _Length++;
                
            }

        }
        else if (collision.gameObject.CompareTag("Block"))
        {
            value = collision.gameObject.GetComponent<Block>().Hitpoints;
            if (value >= _Health)
            {
                PlayerControl.velocity = Vector3.zero;   
            }
            else
            {
                _Health -= value;
                PointsText.SetText(_Health.ToString());
                Destroy(collision.gameObject);
                for (int i = 0; i < value; i++)
                {
                    _Length--;
                }
            }
        }
        

        
    }

}