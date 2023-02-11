using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerControl : MonoBehaviour
{
    public float Speed;                             //Скорость
    public Rigidbody Player;                       //componentPlayer ... Игрок
    Vector3 tempVect = new Vector3(0, 0, 0.1f);
    private Vector3 _previousMousePosition;        // позиция мыши
    private Game Game;
   
                                
    public Transform SnakeHead;                    //позиция головы
    public int value;
    private int Health;   
   
    public TextMeshPro PointsText;           
                          
    private SnakeTeil componentSnakeTail;       

    public Vector3 velocity { get; internal set; }

    void Start()
    {
        Player = GetComponent<Rigidbody>();                  
        componentSnakeTail = GetComponent<SnakeTeil>();        
        PointsText.SetText(Health.ToString());                 

    }

    void FixedUpdate()
    {

        tempVect = Speed * Time.deltaTime * tempVect.normalized;     
        Player.MovePosition(transform.position + tempVect);                  

        if (Input.GetMouseButton(0))
        {
            Vector3 delta = Input.mousePosition - _previousMousePosition;
            delta = delta.normalized * Speed * Time.deltaTime;
            Vector3 newPosition = new Vector3(transform.position.x + delta.x, transform.position.y, transform.position.z + tempVect.z);
            Player.MovePosition(newPosition);
        }
        _previousMousePosition = Input.mousePosition;

    }

}
