using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss_stage1 : MonoBehaviour {

    new Rigidbody2D rigidbody2D;

    //ボスが所定の位置に着いたか
    private bool enter = false;

    private float boTime = 0.0f;

    //放射弾を打つ間隔
    public float CBBTimeOut = 0.8f;

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

    public GameObject BBobj;

    public GameObject ebAobj;

    //そのインスタンス
    private GameObject Instanceex;

    private GameObject Instancebb;

    private GameObject Instanceba;

    //現在のボスの位置
    private Vector3 Bossposition;

    //スコア
    GameObject score;

    Score Sscript;

    //警告音
    AudioSource audiosource;
    //警告エフェクト
    Image redimage;
    float TimeOut = 1.0f;
    float rTime;

    // Use this for initialization
    void Start () {

        redimage = GameObject.Find("redzone").GetComponent<Image>();

        audiosource = this.GetComponent<AudioSource>();

        rigidbody2D = this.GetComponent<Rigidbody2D>();
        //下に降りてくる向き
        dir = new Vector2( 0, -1.0f);

        score = GameObject.Find("Score");
        Sscript = score.GetComponent<Score>();

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
            if (this.transform.position.x <= -1.3f)
            {
                repeat = false;
            }
        }
        else if(!repeat){
            dir = new Vector2(1.0f, 0);
            if (this.transform.position.x >= 1.3f)
            {
                repeat = true;
            }

        }

        //移動処理
        rigidbody2D.velocity = speed * dir;



        //画面内か判定
        if (GetComponent<Renderer>().isVisible)
        {
            Bvisible = true;
        }

        //時間計測
                boTime += Time.deltaTime; 

        //死亡時の処理
        if(BossHP <= 0){
            dir = new Vector2( 0, 0);

            for (int i = 0; i < 10;i++){
                Vector3 randtmp = new Vector3(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f), 0);
                Instanceex = (GameObject)Instantiate(exobj, Bossposition + randtmp, Quaternion.identity);

            }
            //スコア加算
            Sscript.score += 1000;

            Destroy(this.gameObject);

        }

        //弾発射
        //放射弾
        if(enter && boTime >= CBBTimeOut){
            float tmpeuler = 20.0f;
            for (int i = 1; i <= 18;i++)
            {
                Instancebb = (GameObject)Instantiate(BBobj, Bossposition, Quaternion.Euler(0, 0, tmpeuler * i));
            }
            boTime = 0.0f;
            BBcount++;
        }
        //単発弾発射
        if(enter && BBcount == 8){
          
            Instanceba = (GameObject)Instantiate(ebAobj, Bossposition, Quaternion.identity);
            
            BBcount = 0;
        }

    }



    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "PB"){
            Destroy(other.gameObject);

            //所定の位置に着いてからダメージ判定
            if(enter)BossHP--;
        }

    }
}
