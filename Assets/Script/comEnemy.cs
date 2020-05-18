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

    private Vector2 dir;

    public float speed  = 3.0f;

    new Rigidbody2D rigidbody2D;

    //画面外生成時消えない為の判定
    bool Evisible = false;

    // Use this for initialization
    void Start () {
        dir = new Vector2( 0.0f, -1.0f);
        rigidbody2D = GetComponent<Rigidbody2D>();
		
	}

    // Update is called once per frame
    void Update()
    {

        rigidbody2D.velocity = speed * dir;

        Eposition = this.transform.position;
        //画面内に入れば打ち始める。
        if (Evisible)
        {
            EnemyBullet();
        }
        //画面内か判定
        if (GetComponent<Renderer>().isVisible)
        {
            Evisible = true;
        }

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

         void OnBecameInvisible()
    {
        if (Evisible)
        {
            //画面外に出ると消える。
            Destroy(this.gameObject);
        }
    }
}
