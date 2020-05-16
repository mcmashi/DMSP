using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class comEnemy : MonoBehaviour {

    public GameObject exobj;

    private Vector3 Eposition;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        Eposition = this.transform.position;
		
	}

    void OnTriggerEnter2D(Collider2D collision){
        //プレイヤーの弾に当たると消える。
        if (collision.gameObject.tag == "PB"){

            GameObject instance = (GameObject)Instantiate(exobj, Eposition, Quaternion.identity);
            Destroy(collision.gameObject);
            Destroy(this.gameObject);

        }


    }
}
