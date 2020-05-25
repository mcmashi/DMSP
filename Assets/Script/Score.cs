using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

    Text scoretext;

    public int score;

    public static int AllScore;

	// Use this for initialization
	void Start () {
        scoretext = this.gameObject.GetComponent<Text>();
        score = AllScore;
	}
	
	// Update is called once per frame
	void Update () {
        //スコアを表示
        this.scoretext.text = "Score: " + score;

    }

    public void ScoreUpdate()
    {
        AllScore += score;

        return;
    }
}
