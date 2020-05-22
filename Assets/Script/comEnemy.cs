using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class comEnemy : MonoBehaviour {

    //敵のタイプ
    public char type = 'A';

    //アサインするプレハブ
    public GameObject exobj;

    public GameObject eniobj;

    public GameObject ebobjA;

    public GameObject ebobjB;

    public GameObject ebobjC;

    //アイテムドロップ確率設定
    public int enirand = 4;

    //プレハブを生成する自分の座標
    private Vector3 Eposition;

    //複製するインスタンス
    private GameObject instanceex;

    private GameObject instanceeni;

    private GameObject instanceebA;

    private GameObject instanceebB;

    private GameObject instanceebC;

    //弾生成の間隔設定
    public float TimeOut = 2.0f;

    private float EbTime = 0.0f;

    private Vector2 dir;

    public float speed  = 3.0f;

    new Rigidbody2D rigidbody2D;

    //画面外生成時消えない為の判定
    bool Evisible = false;

    //タイプB用のスイッチ
    bool EBswitch = true;

    //タイプC用のスイッチ
    bool ECswitch = true;

    // Use this for initialization
    void Start () {
        dir = new Vector2( 0.0f, -1.0f);
        rigidbody2D = GetComponent<Rigidbody2D>();
		
	}

    // Update is called once per frame
    void Update()
    {
        //タイプ別の動き
        switch(type){
            case 'A':
                rigidbody2D.velocity = speed * dir;
                break;

            case 'B':
                //画面内に入ってから、折り返すまでの時間を計測する。
                if (Evisible)
                {
                    //一定間隔で折り返す動き。
                    EbTime += Time.deltaTime;
                }

                if (EbTime <= TimeOut)
                {
                    rigidbody2D.velocity =  speed * dir;
                }else{
                    rigidbody2D.velocity =  - speed * dir;
                }
                break;

            case 'C':
                //画面内に入ってから、折り返すまでの時間を計測する。
                if (Evisible)
                {
                    //一定間隔で折り返す動き。
                    EbTime += Time.deltaTime;
                }

                if (EbTime <= TimeOut)
                {
                    rigidbody2D.velocity = speed * dir;
                }
                else
                {
                    rigidbody2D.velocity = -speed * dir;
                }
                break;

        }


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
            Destroy(this.gameObject);

        }


    }

    void EnemyBullet(){

        switch(type){
            case 'A':
                //一定間隔で弾を打ち出す。
                EbTime += Time.deltaTime;

                if (EbTime >= TimeOut)
                {
                    instanceebA = (GameObject)Instantiate(ebobjA, Eposition, Quaternion.identity);
                    EbTime = 0.0f;
                }
                break;

            case 'B':
                //折り返しする時に弾を発射する。
                if (EbTime >= TimeOut)
                {
                    if (EBswitch)
                    {
                        EBswitch = false;
                    for (int i = 0; i <= 5; i++)
                        {
                            instanceebB = (GameObject)Instantiate(ebobjB, Eposition, Quaternion.identity);
                        }
                    }
                }
                break;

            case 'C':
                //折り返しする時に弾を発射する。
                if (EbTime >= TimeOut)
                {
                    if (ECswitch)
                    {
                        Vector3 enbvec = new Vector3(0, 0, 0);
                        ECswitch = false;
                        for (int i = 0; i <= 3; i++)
                        {
                            enbvec.y += 0.2f; 
                            instanceebC = (GameObject)Instantiate(ebobjC, Eposition + enbvec, Quaternion.identity);
                        }
                    }
                }
                break;



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
