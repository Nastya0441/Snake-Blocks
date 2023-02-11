using UnityEngine;
using TMPro;

public class Block : MonoBehaviour
{
    public TextMeshPro PointsText;
    [SerializeField]
    private int minHitpoints = 3;
    [SerializeField]
    private int maxHitpoints = 5;
    public int Hitpoints { get; set; }
    public Game Game;
    

    //Color lerpedColor = Color.white;               Изменение цвета куба

    void Start()
    {
        //PointsText.SetText(Hitpoints.ToString());
        Hitpoints = Random.Range(minHitpoints, maxHitpoints);
        PointsText.SetText(Hitpoints.ToString());
        //lerpedColor = Color.Lerp(Color.white, Color.red, (float)Value / 20f);
        //this.GetComponent<Renderer>().material.color = lerpedColor;
        
    }

    public void ApplyDamage()
    {
        Hitpoints--;
        PointsText.text = Hitpoints.ToString();

        if (Hitpoints <= 0)
        {
            Destroy(gameObject);
            Game.Rigidbody.velocity = Vector3.zero;
           Game.OnPlayerDied();
            
        }

    }
   

    

}