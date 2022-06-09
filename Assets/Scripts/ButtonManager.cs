using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class ButtonManager : MonoBehaviour
{
    public GameObject button; //ボタン
    public UnityEvent onPress; //ボタンを押したときのイベント（これは今回設定してない）
    public UnityEvent onRelease;
    GameObject presser;
    AudioSource sound;
    bool isPressed;
    //boolはフラグ立て

    //色を変えるためのキューブ
    public GameObject[] cube = new GameObject[3];

    public Material[] materials = new Material[5];
    //5種類のマテリアルを設定

    private const int COLOR_RED = 0;
    private const int COLOR_BLUE = 1;
    private const int COLOR_GREEN = 2;
    private const int COLOR_WHITE = 3;
    private const int COLOR_BLACK = 4;
    //色に番号を付ける

    private int[] cubeColor = new int[3];
    //cubeColor[0]はCube1

    void Start()
    {
        sound = GetComponent<AudioSource>();
        isPressed = false;

        cubeColor[0] = COLOR_RED;
        cubeColor[1] = COLOR_BLUE;
        cubeColor[2] = COLOR_GREEN;
        //cubeの持つ初期値を設定した
    }

    private void OnTriggerEnter(Collider other){
        /*OnTriggerEnter＝トリガーオブジェクトに侵入した瞬間呼び出される
        OnTriggerStay＝トリガーオブジェクトに侵入している間呼び出される
        OnTriggerExit＝トリガーオブジェクトから脱出した瞬間呼び出される
        トリガーオブジェクトはIsTriggerにチェックを入れないと使用できない*/
        
        if(!isPressed){
            button.transform.localPosition = new Vector3(0, 0.26f, 0);
            //押したときにボタンをへこませる
            presser = other.gameObject;
            //presserを押されたオブジェクトにする
            onPress.Invoke();
            //Invoke(Hogehoge, time)で、time秒後にHogehogeをする
            //今回は、設定したUnityEventのonPressを行う
            sound.Play();
            isPressed = true;
        }
    }

    private void OnTriggerExit(Collider other){
        //
        if(other.gameObject == presser){
            button.transform.localPosition = new Vector3(0, 0.52f, 0);
            onRelease.Invoke();
            isPressed = false;
        }
    }

    //ここを変えればいろいろできる！！
    public void SpawnSphere(){ //ボールを量産する
        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere.transform.localPosition = new Vector3(0, 1, 2);
        sphere.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        sphere.AddComponent<Rigidbody>();
    }

    public void PushButton1(){ 
        ChangeColor(0);
    }

    public void ChangeColor(int buttonNo){
        cubeColor[buttonNo] += 1;
        if(cubeColor[buttonNo] < COLOR_BLACK){
            cube[buttonNo].GetComponent<Renderer>().material.color = Color.materials[cubeColor[buttonNo]];
        }
        else{
            cube[buttonNo].GetComponent<Renderer>().material.color = Color.red;
        }

    }
   
}