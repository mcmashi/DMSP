﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage1_Wave : MonoBehaviour {

    //デバックモード
    public bool debugwave = false;

    //アサインする敵のプレハブ
    public GameObject enrobAobj;

    public GameObject enrobBobj;

    public GameObject enrobCobj;

    public GameObject bossobj;

    private GameObject InstanceenrobA;

    private GameObject InstanceenrobB;

    private GameObject InstanceenrobC;

    private GameObject Instanceboss;

    //ウェーブの順番
    private int wcount = 0;

    //0:何も無い  1:雑魚敵A  2:雑魚敵B 3:雑魚的C
    //ウェーブ01
    //----------------------------
    private int[,] Wave1= new int[5,9]{
        {1,0,1,0,1,0,1,0,1},
        {0,0,0,0,0,0,0,0,0},
        {0,0,1,0,1,0,1,0,0},
        {0,0,0,0,0,0,0,0,0},
        {0,0,0,0,1,0,0,0,0}

    };
    //ウェーブ02
    //----------------------------
    private int[,] Wave2 = new int[5, 9]{
        {0,0,0,0,0,0,0,0,0},
        {0,2,0,0,3,0,0,2,0},
        {0,0,2,0,0,0,2,0,0},
        {0,0,0,2,0,2,0,0,0},
        {0,0,0,0,2,0,0,0,0}

    };
    //ウェーブ03
    //----------------------------
    private int[,] Wave3 = new int[5, 9]{
        {0,0,1,0,1,0,1,0,0},
        {0,0,1,0,1,0,1,0,0},
        {0,0,0,0,0,0,0,0,0},
        {2,0,0,0,2,0,0,0,2},
        {0,0,0,0,0,0,0,0,0}

    };
    //ウェーブ04
    //----------------------------
    private int[,] Wave4 = new int[5, 9]{
        {0,0,3,0,0,0,3,0,0},
        {3,3,0,0,0,0,0,3,3},
        {3,0,0,0,3,0,0,0,3},
        {0,0,3,0,0,0,3,0,0},
        {0,0,0,0,0,0,0,0,0}

    };
    //ウェーブ05
    //----------------------------
    private int[,] Wave5 = new int[5, 9]{
        {3,0,0,0,0,0,0,0,3},
        {0,0,3,0,2,0,3,0,0},
        {0,0,0,2,0,2,0,0,0},
        {0,1,0,0,1,0,0,1,0},
        {0,0,0,0,0,0,0,0,0}

    };
    //ウェーブ06
    //----------------------------
    private int[,] Wave6 = new int[5, 9]{
        {0,1,0,0,0,0,0,1,0},
        {0,0,0,0,3,0,0,0,0},
        {1,0,2,0,0,0,2,0,1},
        {1,0,0,0,0,0,0,0,1},
        {0,3,0,0,3,0,0,3,0}

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
    }
	
	// Update is called once per frame
	void Update () {

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

                    case 10:
                        //ボス生成
                        Instanceboss = (GameObject)Instantiate(bossobj,new Vector3( 0, 10.0f, 0),Quaternion.identity);
                        break;

                }



            }
        }

		
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

                }
            }


        }


        return 0;
    }
}