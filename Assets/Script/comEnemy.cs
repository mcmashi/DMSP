using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class comEnemy : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D collision){
        //プレイヤーの弾に当たると消える。
        if (collision.gameObject.tag == "PB"){
            Destroy(this.gameObject);

        }


    }
}
