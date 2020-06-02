using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBallet : MonoBehaviour {

    //移動スピード
    public float speed = 7.0f;

    //進む方向
    private Vector2 dir;

    private new Rigidbody2D rigidbody2D;

    //SE
    AudioSource balletauido;
    public AudioClip balletse;

	// Use this for initialization
	void Start () {
        this.rigidbody2D = this.GetComponent<Rigidbody2D>();
        this.balletauido = this.GetComponent<AudioSource>();
        this.dir = new Vector2( 0, 1.0f);
        
        balletauido.PlayOneShot(balletse,0.7f);
	}
	
	// Update is called once per frame
	void Update () {

        this.rigidbody2D.velocity = dir * speed;

    }

    void OnBecameInvisible()
    {
        //画面外に出ると消える。
        Destroy(this.gameObject);
    }
}
