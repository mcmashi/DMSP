using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Result : MonoBehaviour {

    Text scoretext;

    private int score;

    Score sscript;

	// Use this for initialization
	void Start () {
        scoretext = this.gameObject.GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {

        score += 10;
        score =Mathf.Min(score,sscript.AllScore);


        //スコアを表示
        this.scoretext.text = "Score: " + score;

    }

}
