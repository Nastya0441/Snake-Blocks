using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using Random = System.Random;



public class ScoreUI : MonoBehaviour
{
    //public Text ScoreText;
    //public Text MenuScoreText;
    //public Text BestScoreText;
    //public static int Score;
    //public static int BestScore;




    //bool speedAdded;

    // void Start()
    // {
    //    //SetMenu();
    //    Score = 0;

    //    speedAdded = false;
    //    BestScore = PlayerPrefs.GetInt("BestScore");
    // }


    //void Update()
    //{
    //    ScoreText.text = Score + " ";
    //    MenuScoreText.text = Score + "";

    //    if(Score> BestScore)
    //    {
    //        BestScore = Score;

    //        BestScoreText.text = BestScore + "";
    //        if(!speedAdded && Score > 150)
    //        {
    //            //SM.Speed++;
    //            speedAdded = true;
    //        }
    //    }
    //}


    public TextMesh textMesh;
    private int amount = 0;
   // public GameObject Body;
    // public int Range = 0;
    public GameObject Body;


    private void Start()
    {
        Body = GameObject.Find("Body");
    }

    private void OnEnable()
    {

       
        textMesh.text = amount.ToString();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            for(int i = 0; i<amount; i++)
            {
                int index = other.transform.childCount;
                Transform GameObject = (Instantiate(Body, new Vector3(0, 0, 0), Quaternion.identity)).transform;
                GameObject.transform.localPosition = new Vector3(0, -index, 0);
               
            }
        }
    }

}
