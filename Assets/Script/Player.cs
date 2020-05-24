using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {

    //初期エネルギ＝
    public float energy = 1000.0f;
    //初期残機数
    public int stock = 3;

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

    //プレイヤーのスプライト
    public Sprite CPsprite;

    public Sprite RPsprite;

    public Sprite LPsprite;

    //プレイヤーのスプライト管理
    private SpriteRenderer Prenderer;

    //スプライトの色
    private Color Pcolor;
    //色変化の時間
    private float cTimeOut = 1.0f;
    private float rTimeOut = 0.5f;
    private float cTime;

    //無敵時間
    private float mTimeOut = 3.0f;
    private float mTime = 0.0f;
    private bool mTimenow = false;
    //無敵時間中の色
    private Color mcolor = new Color( 1.0f, 1.0f, 1.0f, 1.0f);

    //エネルギーゲージを操作
    GameObject EnergyGage;
    Image EG;

    //パワーアップ効果音
    public AudioClip audiopowup;
    AudioSource audiosource;

    public bool start = false;

    private void Start()
    {
        audiosource = this.GetComponent<AudioSource>();

        EnergyGage = GameObject.Find("EnergyGage");

        EG = EnergyGage.GetComponent<Image>();
        
        Prenderer = this.GetComponent<SpriteRenderer>();

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

        dir = new Vector2(0,1.0f);
    }

    private void Update()
    {

        //自分の現在の位置得る
        Pposition = this.transform.position;

        if (start)
        {
            // 右・左
            var x = Input.GetAxisRaw("Horizontal");

            //移動に応じてスプライトを変更する。
            if (x > 0)
            {
                Prenderer.sprite = RPsprite;
            }
            else if (x < 0)
            {
                Prenderer.sprite = LPsprite;
            }
            else
            {
                Prenderer.sprite = CPsprite;
            }

            // 上・下
            var y = Input.GetAxisRaw("Vertical");

            this.dir = new Vector2(x, y);


            //弾発射プレイやーの位置にインスタンス化
            if (Input.GetKeyDown("space"))
            {
                GameObject instancepb = (GameObject)Instantiate(pbobj, Pposition, Quaternion.identity);
            }

            PlayerEnergy();

        }else{

            rigidbody2D.velocity = dir * speed;
            if(Pposition.y >= -2.0f){
                start = true;
            }
        }

        //無敵時間
        MutekiTime();

    }

    private void PlayerEnergy()
    {
        //エネルギー処理
        energy -= 0.25f;
        //サイズ内に収める
        if (energy <= 0)
        {
            energy = 0;
            PlayerDeth();

        }
        else if (energy >= 1000)
        {
            energy = 1000;

        }
        else if (energy <= 300)
        {
            //200以下で危険信号
            cTime += Time.deltaTime;

            Pcolor = new Color(1.0f, 1.0f, 1.0f);

            if (cTime >= cTimeOut)
            {
                //色変える 
                Pcolor = new Color(1.0f, 0.3f, 0.3f);
                //赤の状態終わる
                if (cTime >= rTimeOut + cTimeOut) cTime = 0.0f;
            }

            //エネルギーが減るにつれて、点滅間隔を早くする。
            if ((int)energy % 10 == 0)
            {
                if (cTimeOut >= 0.1)
                {
                    cTimeOut -= 0.1f;
                }
            }


        }
        else
        {
            //色もどす
            Pcolor = new Color(1.0f, 1.0f, 1.0f, 1.0f);
            cTimeOut = 1.0f;
        }

        //色を適用
        Prenderer.color = Pcolor;
        EG.color = Pcolor;



    }

    private void MutekiTime(){

        //無敵時間中
        if(mTimenow){

            //時間経過で無敵時間終了
            mTime += Time.deltaTime;

            if (mTimeOut <= mTime)
            {
                mTimenow = false;
            }

            //無敵時間中点滅処理
            if ( (int)(mTime * 10)  % 2 == 0)
            {
                //透明度変える 
                mcolor = new Color(1.0f, 1.0f, 1.0f, 0.0f);
            }else{

                //透明度変える 
                mcolor = new Color(1.0f, 1.0f, 1.0f, 1.0f);
            }


        }
        else{
            //無敵時間終わり
            //時間リセット
            mTime = 0.0f;

            //透明度戻す
            mcolor = new Color(1.0f, 1.0f, 1.0f, 1.0f);

        }

        //無敵時間中の色を適用
        Prenderer.color = mcolor;



    }

    private void FixedUpdate()
    {
        if (start)
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
    }


    void PlayerDeth(){

        Instanceex = (GameObject)Instantiate(exobj, Pposition, Quaternion.identity);

        //残機がゼロ以下なら
        if (stock <= 0)
        {
            stock = 0;
            Destroy(this.gameObject);
        }else{
            //残機減らす
            stock--;

            //画面外に戻す
            this.transform.position = new Vector3( 0, -6.0f, 0);
            //進む方向を決める
            dir = new Vector2(0, 0.5f);
            //正面のスプライトにする
            Prenderer.sprite = CPsprite;
            //エネルギーリセット
            energy = 500.0f;
            //無敵時間反映
            mTimenow = true;
            //画面内に入る
            start = false;
        }

    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!mTimenow)
        {
            //敵の場合
            if (other.gameObject.tag == "enemy")
            {

                PlayerDeth();
            }

            //敵の弾の場合
            if (other.gameObject.tag == "EB")
            {

                PlayerDeth();
            }


            //エナジーアイテムの場合
            if (other.gameObject.tag == "energy")
            {
                audiosource.PlayOneShot(audiopowup);
                energy += 100;
                Destroy(other.gameObject);
            }

        }
    }

}

