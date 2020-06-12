using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {

    public GameObject gmovtext;

    public GameObject bmbutton;

	// Use this for initialization
	void Start () {

    }
	
	// Update is called once per frame
	void Update () {
        //プレイヤーが破壊されたら
        if(!GameObject.Find("Player")){
            gmovtext.gameObject.SetActive(true);
            bmbutton.gameObject.SetActive(true);

            //エンター押すと
            if(Input.GetKeyDown(KeyCode.M)){
                SceneManager.LoadScene("Title");

            }

        }
	}
}
