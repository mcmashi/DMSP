using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enerugy : MonoBehaviour {

    public float speed = 5.0f;

    private Vector2 dir;

    private new Rigidbody2D rigidbody;

	// Use this for initialization
	void Start () {
        rigidbody = GetComponent<Rigidbody2D>();
        dir = new Vector2(0,-1.0f);
	}
	
	// Update is called once per frame
	void Update () {
        rigidbody.velocity = speed * dir;
	}

    void OnBecameInvisible()
    {
        //画面外に出ると消える。
        Destroy(this.gameObject);
    }
}
