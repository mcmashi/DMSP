using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class comEnemy : MonoBehaviour {

    //アサインするプレハブ
    public GameObject exobj;

    public GameObject eniobj;

    public GameObject ebobj;

    //アイテムドロップ確率設定
    public int enirand = 4;

    //プレハブを生成する自分の座標
    private Vector3 Eposition;

    //複製するインスタンス
    private GameObject instanceex;

    private GameObject instanceeni;

    private GameObject instanceeb;

    //弾生成の間隔設定
    public float TimeOut = 2.0f;

    private float EbTime = 0.0f;


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        Eposition = this.transform.position;
        EnemyBullet();

		
	}

    void OnTriggerEnter2D(Collider2D collision){
        //プレイヤーの弾に当たると消える。アイテムを出す。
        if (collision.gameObject.tag == "PB"){

            instanceex = (GameObject)Instantiate(exobj, Eposition, Quaternion.identity);
            int tmp = Random.Range(0, enirand);
            if (tmp == 0)
            {
                instanceeni = (GameObject)Instantiate(eniobj, Eposition, Quaternion.identity);
            }
            Destroy(collision.gameObject);
            Destroy(this.gameObject);

        }


    }

    void EnemyBullet(){
        //一定間隔で弾を打ち出す。
        EbTime += Time.deltaTime;

        if(EbTime >= TimeOut){
            instanceeb = (GameObject)Instantiate(ebobj, Eposition, Quaternion.identity);
            EbTime = 0.0f;
        }


    }
}
