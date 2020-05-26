using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBulletS1: MonoBehaviour {

    private Vector3 dir;

    private new Rigidbody2D rigidbody2D;

    //z軸の回転角度
    float BBrad;

    //弾の速度設定
    public float speed = 2.0f;

	// Use this for initialization
	void Start () {
        rigidbody2D = GetComponent<Rigidbody2D>();
        //z軸の回転角度をラジアン化
        BBrad = this.transform.eulerAngles.z * (Mathf.PI / 180.0f);
        //角度BBradから、xとyの位置ベクトルに変換。
        dir =  new Vector3(Mathf.Cos(BBrad),Mathf.Sin(BBrad),0);
        //dir = dir / dir.magnitude;
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
