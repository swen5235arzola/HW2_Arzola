using UnityEngine;
using UnityEngine.UI;
using System.Collections;

//Author: Unity Tutorial
//Modified By: Adriana Arzola
//Date: 04/07/2019
public class ScoreManager : MonoBehaviour
{
    public static int score;

    Text text;

    void Awake ()
    {
        text = GetComponent <Text> ();
        score = 0;
    }


    void Update ()
    {
        text.text = "Score: " + score;
    }
}
