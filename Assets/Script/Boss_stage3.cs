using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss_stage3 : MonoBehaviour {

    new Rigidbody2D rigidbody2D;

    //ボスが所定の位置に着いたか
    public bool enter = false;

    private float boTime = 0.0f;

    //放射弾を打つ間隔
    public float CBBTimeOut = 0.4f;

    //単発弾を打つタイミング
    private int BBcount = 0;

    //ボスの動くスピード：初期値は画面内に入るまでのスピード
    private float speed = 1.0f;

    private Vector2 dir;

    //左右移動を繰り返す為の判定
    private bool repeat = false;

    //画面外生成時消えない為の判定
    bool Bvisible = false;

    //ボスのHP
    public int BossHP = 180;

    //アサインするオブジェクト
    public GameObject exobj;

    public GameObject BBRobj;

    public GameObject BBHobj;

    public GameObject BBeam1;

    public GameObject BBeam2;

    //そのインスタンス
    private GameObject Instanceex;

    private GameObject Instancebbr;

    private GameObject Instancebbh;

    private GameObject Instancebbm1;

    private GameObject Instancebbm2;

    //現在のボスの位置
    public Vector3 Bossposition;

    //スコア
    GameObject score;

    Score Sscript;

    //警告音
    AudioSource audiosource;
    //警告エフェクト
    Image redimage;
    float TimeOut = 1.0f;
    float rTime;

    //ウェーブの状態を取得する。
    GameObject Wave;

    Stage3_Wave wscript;

    //アニメーション
    Animator banimator;
    int dbw;

    //ウィングの状態
     GameObject LW;
     GameObject RW;


     LeftW lwscript;
     RightW rwscript;


    // Use this for initialization
    void Start () {

        redimage = GameObject.Find("redzone").GetComponent<Image>();

        audiosource = this.GetComponent<AudioSource>();

        rigidbody2D = this.GetComponent<Rigidbody2D>();
        //下に降りてくる向き
        dir = new Vector2( 0, -1.0f);

        score = GameObject.Find("Score");
        Sscript = score.GetComponent<Score>();

        Wave = GameObject.Find("Stage");
        wscript = Wave.GetComponent<Stage3_Wave>();

        banimator = this.GetComponent<Animator>();

        dbw = banimator.GetInteger("damage");

        LW = GameObject.Find("LPoint");
        RW = GameObject.Find("RPoint");

        lwscript = LW.GetComponent<LeftW>();
        rwscript = RW.GetComponent<RightW>();

    }
	
	// Update is called once per frame
	void Update () {

        //現在の位置代入
        Bossposition = this.transform.position;

        //ボスの動作
        if (!enter)
        {

            //赤く点滅させる

            rTime += Time.deltaTime;

            if (rTime >= TimeOut)
            {
                redimage.color = new Color(0.5f, 0.0f, 0.0f, 0.5f);
                rTime = 0.0f;
            }else{
                redimage.color = Color.Lerp(redimage.color, Color.clear, Time.deltaTime);
            }

            //画面外から、所定の位置に移動すると次の動作になる。
            if (this.transform.position.y <= 2.3)
            {
                enter = true;
                boTime = 0.0f;
                repeat = true;
                speed = 2.0f;
                //警告音ミュート
                audiosource.mute = true;
                redimage.color = Color.clear;
            }

        }

        //左右移動繰り返し
        else if (repeat)
        {
            dir = new Vector2(-1.0f, 0);
            if (this.transform.position.x <= -1.2f)
            {
                repeat = false;
            }
        }
        else if(!repeat){
            dir = new Vector2(1.0f, 0);
            if (this.transform.position.x >= 1.2f)
            {
                repeat = true;
            }

        }

        //移動処理
        rigidbody2D.velocity = speed * dir;

        //ボスのアニメーション
        BossAnime();

        //画面内か判定
        if (GetComponent<Renderer>().isVisible)
        {
            Bvisible = true;
        }

        //時間計測

        if(enter)boTime += Time.deltaTime; 

        //死亡時の処理
        if(BossHP <= 0){
            dir = new Vector2( 0, 0);

            for (int i = 0; i < 10;i++){
                Vector3 randtmp = new Vector3(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f), 0);
                Instanceex = (GameObject)Instantiate(exobj, Bossposition + randtmp, Quaternion.identity);

            }
            //スコア加算
            Sscript.score += 10000;
            wscript.cler();
            Destroy(this.gameObject);

        }

        //弾発射
        //列弾
        if(enter && boTime >= CBBTimeOut){
            /*
            float bbrx = -4.0f;
            for (int i = 2; i <= 10;i++)
            {

                Instancebbr = (GameObject)Instantiate(BBRobj, Bossposition + new Vector3(bbrx, 0, 0), Quaternion.identity);
                 
                bbrx += 0.8f;
            }
            */
            float tmpeuler = 20.0f;
            for (int i = 1; i <= 18; i++)
            {
                Instancebbh = (GameObject)Instantiate(BBHobj, Bossposition, Quaternion.Euler(0, 0, tmpeuler * i));
            }
            boTime = 0.0f;
            BBcount++;
        }
        //ビーム砲発射
        if(enter && BBcount >= 20){

            if (lwscript.brokeL == false)
            {


                Instancebbm1 = (GameObject)Instantiate(BBeam1, Bossposition + new Vector3(-0.46f, -0.5f, 0), Quaternion.identity);

                Instancebbm1.transform.parent = this.transform;



            }

            if(rwscript.brokeR == false){
                Instancebbm2 = (GameObject)Instantiate(BBeam2, Bossposition + new Vector3(0.85f, -0.5f, 0), Quaternion.identity);

                Instancebbm2.transform.parent = this.transform;


            }

            //第二形態
            if(dbw == 3){
                float bbrx = -4.0f;
                for (int i = 1; i <= 10; i++)
                {
                    float bbry = -0.4f;
                    for (int j = 1; j <= 4; j++)
                    {
                        Instancebbr = (GameObject)Instantiate(BBRobj, Bossposition + new Vector3(bbrx, bbry, 0), Quaternion.identity);
                        bbry += 0.2f;

                    }
                    bbrx += 0.8f;
                }

            }


            BBcount = 0;
        }

    }


    void BossAnime()
    {
        //アニメーションを変更する


        if (lwscript.brokeL == true && dbw == 0)
        {

            dbw = 1;
            Instanceex = (GameObject)Instantiate(exobj, Bossposition + new Vector3(-0.8f,0.6f,0), Quaternion.identity);

        }

        if (rwscript.brokeR == true && (dbw == 0 || dbw == 1))
        {

            dbw = 2;
            Instanceex = (GameObject)Instantiate(exobj, Bossposition + new Vector3(0.8f, 0.6f, 0), Quaternion.identity);

        }

        if (lwscript.brokeL == true && rwscript.brokeR == true)
        {

            dbw = 3;
        }

        //アニメーションの状態セット
        banimator.SetInteger("damage",dbw);

    }



    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "PB"){

            //所定の位置に着いてからダメージ判定
            if (enter && dbw == 3)
            {
                Destroy(other.gameObject);
                BossHP--;

            }
        }

    }
}
