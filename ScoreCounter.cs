using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCounter : MonoBehaviour
{
    GameObject Score;
    GameObject gamecontroller;
    // Start is called before the first frame update
    void Start()
    {
        this.Score = GameObject.Find("Score");
        this.gamecontroller = GameObject.Find("GameController");

    }

    // Update is called once per frame
    void Update()
    {
        int target_destroy = this.gamecontroller.GetComponent<GameController>().target_destroy;
        int tower_destroy = this.gamecontroller.GetComponent<GameController>().tower_destroy;
        int tank_destroy = this.gamecontroller.GetComponent<GameController>().tank_destroy;
        int score = target_destroy * 100 + tower_destroy * 200 + tank_destroy * 500;
       // Debug.Log(score);
        this.Score.GetComponent<Text>().text = "Score " + score.ToString("D");
    }
}
