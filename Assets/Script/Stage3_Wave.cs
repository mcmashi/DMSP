using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Stage3_Wave : MonoBehaviour {

    //デバックモード
    public bool debugwave = false;

    //アサインする敵のプレハブ
    public GameObject enrobAobj;

    public GameObject enrobBobj;

    public GameObject enrobCobj;

    public GameObject enrobDobj;

    public GameObject bossobj;

    private GameObject InstanceenrobA;

    private GameObject InstanceenrobB;

    private GameObject InstanceenrobC;

    private GameObject InstanceenrobD;

    private GameObject Instanceboss;

    //プレイヤーの状態を取得する。
    GameObject Player;

    Player pscript;

    //スコアの状態反映
    GameObject score;

    Score Sscript;

    //リザルト時間
    float progressTime;
    float resultTime = 4.0f;

    //ウェーブの順番
    private int wcount = 0;

    //0:何も無い  1:雑魚敵A  2:雑魚敵B 3:雑魚的C  4:雑魚的D
    //ウェーブ01
    //----------------------------
    private int[,] Wave1= new int[5,9]{
        {2,3,0,0,4,0,0,3,2},
        {0,0,0,0,0,0,0,0,0},
        {0,0,0,0,0,0,0,0,0},
        {0,1,0,1,0,1,0,1,0},
        {1,0,1,0,1,0,1,0,1}

    };
    //ウェーブ02
    //----------------------------
    private int[,] Wave2 = new int[5, 9]{
        {0,0,0,0,4,0,0,0,0},
        {0,0,0,4,0,4,0,0,0},
        {0,0,4,0,4,0,4,0,0},
        {0,4,0,0,0,0,0,4,0},
        {0,2,0,0,2,0,0,2,0}

    };
    //ウェーブ03
    //----------------------------
    private int[,] Wave3 = new int[5, 9]{
        {0,0,0,0,0,0,0,0,0},
        {4,3,4,3,0,0,0,0,0},
        {0,0,0,0,0,4,3,4,3},
        {4,3,4,3,0,0,0,0,0},
        {0,0,0,0,0,4,3,4,3}

    };
    //ウェーブ04
    //----------------------------
    private int[,] Wave4 = new int[5, 9]{
        {0,0,1,0,1,0,1,0,0},
        {3,1,0,1,0,1,0,1,3},
        {3,0,0,0,0,0,0,0,3},
        {3,0,0,4,4,4,0,0,3},
        {3,0,0,4,4,4,0,0,3}

    };
    //ウェーブ05
    //----------------------------
    private int[,] Wave5 = new int[5, 9]{
        {0,0,0,0,0,0,0,0,0},
        {0,0,4,0,4,0,4,0,0},
        {0,0,0,0,2,0,0,0,0},
        {0,0,2,0,1,0,2,1,0},
        {0,3,3,3,3,3,3,3,0}

    };
    //ウェーブ06
    //----------------------------
    private int[,] Wave6 = new int[5, 9]{
        {0,3,4,0,0,0,4,3,0},
        {4,0,0,0,3,0,0,0,4},
        {4,0,4,0,0,0,4,0,4},
        {0,0,2,0,0,0,2,0,0},
        {0,2,0,0,2,0,0,2,0}

    };
    //ウェーブ07
    //----------------------------
    private int[,] Wave7 = new int[5, 9]{
        {1,2,3,4,4,4,3,2,1},
        {0,1,2,3,4,3,2,1,0},
        {0,0,1,2,3,2,1,0,0},
        {0,0,0,1,2,1,0,0,0},
        {0,0,0,0,1,0,0,0,0}

    };
    //ウェーブ08
    //----------------------------
    private int[,] Wave8 = new int[5, 9]{
        {0,4,0,0,0,3,2,1,0},
        {0,4,0,0,3,2,1,0,0},
        {0,4,0,3,2,1,0,0,0},
        {0,4,0,0,0,0,0,0,0},
        {0,4,3,2,1,0,0,0,0}

    };
    //ウェーブ09
    //----------------------------
    private int[,] Wave9 = new int[5, 9]{
        {0,0,0,0,0,0,0,0,0},
        {0,0,0,0,0,0,0,0,0},
        {0,0,0,0,0,0,0,0,0},
        {0,0,0,0,0,0,0,0,0},
        {0,0,0,0,0,0,0,0,0}

    };

    public float TimeOut = 10.0f;

    private float ewTime = 0.0f;

    //画面内の左上座標を格納
    float camx = 0.0f;
    float camy = 0.0f;


	// Use this for initialization
	void Start () {
        //カメラ内の左上を基準にして敵が出現する為、左上の座標を取得。
        var mainCamera = Camera.main;
        var top = mainCamera.ViewportToWorldPoint(new Vector3(0.0f, 1.0f, 0.0f));
        camx = top.x;
        camy = top.y;

        Player = GameObject.Find("Player");
        pscript = Player.GetComponent<Player>();

        score = GameObject.Find("Score");
        Sscript = score.GetComponent<Score>();
    }
	
	// Update is called once per frame
	void Update () {

        //プレイヤーの状態によって、ウェーブの進行を制御
        if (pscript.start)
        {
            debugwave = false;
        }else{
            debugwave = true;
        }

        //デバッグ中か判定
        if (!debugwave)
        {

            //一定時間でウェーブが始まる。
            ewTime += Time.deltaTime;

            if (ewTime >= TimeOut)
            {
                wcount++;

                ewTime = 0.0f;
                switch (wcount)
                {
                    case 1:
                        WaveDraw(Wave1);
                        break;
                    case 2:
                        WaveDraw(Wave2);
                        break;
                    case 3:
                        WaveDraw(Wave3);
                        break;
                    case 4:
                        WaveDraw(Wave4);
                        break;
                    case 5:
                        WaveDraw(Wave5);
                        break;
                    case 6:
                        WaveDraw(Wave6);
                        break;
                    case 7:
                        WaveDraw(Wave7);
                        break;
                    case 8:
                        WaveDraw(Wave8);
                        break;
                    case 9:
                        WaveDraw(Wave9);
                        break;

                    case 10:
                        //ボス生成
                        Instanceboss = (GameObject)Instantiate(bossobj,new Vector3( 0, 10.0f, 0),Quaternion.identity);
                        break;

                }

            }
        }

        if(pscript.clear == true)
        {
            //画面外でたら次のシーンへ
            Transform ptransform = Player.GetComponent<Transform>();
            if (ptransform.position.y > 6.0f)
            {
                StageResult();

            }

        }
		
	}

    public void cler(){

        //ステージクリア判定

        //ストック0以下ではない
        if (pscript.stock >= 0)
        {
                pscript.clear = true;


        }


        return;
    }


    int WaveDraw(int[,] wave){
        //ウェーブを作る。
        for (int i = 0; i < 5; i++)
        {

            for (int j = 0; j < 9; j++)
            {
                //最初の一体目のx座標が左端の座標+zeropointになる。
                float zeropoint = 0.4f;
                //space分x座標をずらして敵を配置。
                float spacex = j * 0.6f;
                //space分y座標をずらして敵を配置。
                float spacey = i * 0.6f;

                switch (wave[i, j]){
                    case 1:
                        InstanceenrobA = (GameObject)Instantiate(enrobAobj, new Vector3(spacex + camx + zeropoint, 5 - spacey + camy, 0), Quaternion.identity);
                        break;

                    case 2:
                        InstanceenrobB = (GameObject)Instantiate(enrobBobj, new Vector3(spacex + camx + zeropoint, 5 - spacey + camy, 0), Quaternion.identity);
                        break;

                    case 3:
                        InstanceenrobC = (GameObject)Instantiate(enrobCobj, new Vector3(spacex + camx + zeropoint, 5 - spacey + camy, 0), Quaternion.identity);
                        break;

                    case 4:
                        InstanceenrobD = (GameObject)Instantiate(enrobDobj, new Vector3(spacex + camx + zeropoint, 5 - spacey + camy, 0), Quaternion.identity);
                        break;

                }
            }


        }


        return 0;
    }

    void StageResult()
    {

        progressTime += Time.deltaTime;

        if (progressTime >= resultTime)
        {
            Sscript.ScoreUpdate();
            SceneManager.LoadScene("Result");

        }

    }

}