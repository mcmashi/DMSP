using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletA : MonoBehaviour {

    //プレイヤーの情報取得用
    GameObject Player;

    private Vector2 dir;

    private new Rigidbody2D rigidbody2D;

    //弾の速度設定
    public float speed = 2.0f;

	// Use this for initialization
	void Start () {
        rigidbody2D = GetComponent<Rigidbody2D>();
        Player = GameObject.Find("Player");
        //プレイヤーに向かうベクトルを生成して、距離で割って正規化している。速度の均一化。
        if (Player == null)
        {
            dir = new Vector2( 0, -1.0f);

        }else{

            dir = Player.transform.position - this.transform.position;
            var distance = dir.magnitude;
            dir = dir / distance;

        }
    }
	
	// Update is called once per frame
	void Update () {


        rigidbody2D.velocity = dir * speed;

    }

    void OnBecameInvisible()
    {
        //画面外に出ると消える。
        Destroy(this.gameObject);
    }
}
