using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    //初期エネルギ＝
    public float energy = 1000.0f;

    // 移動スピード
    public float speed = 5;

    // 移動する向き
    private Vector2 dir;

    // 画面の左・右・上・下の境界の位置
    private float boundL;
    private float boundR;
    private float boundT;
    private float boundB;

    private new Rigidbody2D rigidbody2D;

    //アサインするプレハブ
    public GameObject pbobj;

    public GameObject exobj;

    //そのプレハブを生成する自分の座標
    Vector3 Pposition;

    //複製するインスタンス
    private GameObject Insancepb;

    private GameObject Instanceex;

    private void Start()
    {

        this.rigidbody2D = this.GetComponent<Rigidbody2D>();

        // あらかじめ、画面上下左右の縁がワールド空間上でどこに位置するか調べておく
        var mainCamera = Camera.main;
        var positionZ = this.transform.position.z;
        var topRight = mainCamera.ViewportToWorldPoint(new Vector3(1.0f, 1.0f, positionZ));
        var bottomLeft = mainCamera.ViewportToWorldPoint(new Vector3(0.0f, 0.0f, positionZ));
        this.boundL = bottomLeft.x + 0.2f;
        this.boundR = topRight.x - 0.2f;
        this.boundT = topRight.y - 0.2f;
        this.boundB = bottomLeft.y + 0.2f;
    }

    private void Update()
    {
        // 右・左
        var x = Input.GetAxisRaw("Horizontal");

        // 上・下
        var y = Input.GetAxisRaw("Vertical");

        this.dir = new Vector2(x, y);

        //自分の現在の位置得る
        Pposition = this.transform.position;

        //弾発射プレイやーの位置にインスタンス化
        if(Input.GetKeyDown("space")){
            GameObject instancepb = (GameObject)Instantiate(pbobj,Pposition,Quaternion.identity);
        }


        //エネルギー処理
        energy -= 0.5f;

        if(energy <= 0){
            energy = 0;

        }else if(energy >= 1000){
            energy = 1000;

        }

    }

    private void FixedUpdate()
    {
        // 現在の位置
        var position = this.rigidbody2D.position;

        // 範囲制限を加える前の速度
        var velocity = this.dir * this.speed;

        // 今回の物理状態更新での移動量
        var deltaPosition = velocity * Time.deltaTime;

        // 範囲制限を加えなかった場合の、予想される移動先
        var nextPosition = position + deltaPosition;

        // 予想移動先の座標をクランプする
        var clampedNextPosition = new Vector2(
            Mathf.Clamp(nextPosition.x, this.boundL, this.boundR),
            Mathf.Clamp(nextPosition.y, this.boundB, this.boundT));

        // クランプ後の移動先座標から移動量を求める
        var clampedDeltaPosition = clampedNextPosition - position;

        // クランプ後の移動量から速度を求める
        var clampedVelocity = clampedDeltaPosition / Time.deltaTime;

        // クランプ後の速度を代入
        this.rigidbody2D.velocity = clampedVelocity;
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        //敵の場合
        if(other.gameObject.tag == "enemy"){

            Instanceex = (GameObject)Instantiate(exobj, Pposition, Quaternion.identity);
            Destroy(this.gameObject);
        }

        //敵の弾の場合
        if (other.gameObject.tag == "EB")
        {

            Instanceex = (GameObject)Instantiate(exobj, Pposition, Quaternion.identity);
            Destroy(this.gameObject);
        }


        //エナジーアイテムの場合
        if (other.gameObject.tag == "energy"){

            energy += 100;
            Destroy(other.gameObject);
        }
    }

}

