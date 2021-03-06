﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletB : MonoBehaviour {

    private Vector2 dir;

    private new Rigidbody2D rigidbody2D;

    //弾の速度設定
    public float speed = 2.0f;

	// Use this for initialization
	void Start () {
        rigidbody2D = GetComponent<Rigidbody2D>();
        //ランダムな方向に進む、距離で割って正規化している。速度の均一化。
        dir = new Vector2(Random.Range(-0.5f,0.5f),-1.0f);
        dir = dir / dir.magnitude;
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
