using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour {

    public GameObject gmovtext;

    public GameObject pletext;

	// Use this for initialization
	void Start () {

    }
	
	// Update is called once per frame
	void Update () {
        //プレイヤーが破壊されたら
        if(!GameObject.Find("Player")){
            gmovtext.gameObject.SetActive(true);
            pletext.gameObject.SetActive(true);

            //エンター押すと
            if(Input.GetKeyDown(KeyCode.Space)){

            }

        }
	}
}
