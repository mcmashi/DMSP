using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBulletS2: MonoBehaviour {

    private Vector3 dir;

    private new Rigidbody2D rigidbody2D;

    //z軸の回転角度
    float BBrad;

    //弾の速度設定
    public float speed = 2.0f;

	// Use this for initialization
	void Start () {
        rigidbody2D = GetComponent<Rigidbody2D>();
        dir = new Vector3( 0, -1.0f, 0);
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
