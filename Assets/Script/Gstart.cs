using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gstart : MonoBehaviour {

    GameObject Player;

    Player script;

	// Use this for initialization
	void Start () {
        Player = GameObject.Find("Player");
        script = Player.GetComponent<Player>();
		
	}
	
	// Update is called once per frame
	void Update () {
        //ゲームがスタートと同時に消す
        if(script.start){
            Destroy(this.gameObject);

        }
	}
}
