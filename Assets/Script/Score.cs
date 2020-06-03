using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour {

    Text scoretext;

    public int score;

    public static int AllScore;

	// Use this for initialization
	void Start () {

        if (SceneManager.GetActiveScene().name == "Result")
        {
            scoretext = this.gameObject.GetComponent<Text>();
        }
        else if(SceneManager.GetActiveScene().name == "Title")
        {
            //初期化
            score = 0;
            AllScore = 0;
        }else{
            scoretext = this.gameObject.GetComponent<Text>();
            score = AllScore;

        }
	}
	
	// Update is called once per frame
	void Update () {

        if (SceneManager.GetActiveScene().name == "Title") return;

        //もし最終結果のシーンなら
        if(SceneManager.GetActiveScene().name == "Result"){
            for (int i = 0; i < 10;i++)
            {
                //合計スコア表示
                score += 10;
                score = Mathf.Min(score, AllScore);
            }
        }


        //スコアを表示
        this.scoretext.text = "Score: " + score;

    }

    public void ScoreUpdate()
    {
        AllScore += score;

        return;
    }
}
