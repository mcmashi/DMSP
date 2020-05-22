using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletSub : MonoBehaviour {

    GameObject score;

    Score Sscript;
    

	// Use this for initialization
	void Start () {
        score = GameObject.Find("Score");
        Sscript = score.GetComponent<Score>();

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "enemy"){
            //スコア加算
            Sscript.score += 10;

            Destroy(this.gameObject);

        }
    }
}
