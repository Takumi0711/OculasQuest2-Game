using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class ButtonManager : MonoBehaviour
{
    public GameObject button;
    public UnityEvent onPress;
    public UnityEvent onRelease;
    GameObject presser;
    AudioSource sound;
    bool isPressed;

    void Start()
    {
        sound = GetComponent<AudioSource>();
        isPressed = false;
    }

    private void OnTriggerEnter(Collider other){
        if(!isPressed){
            button.transform.localPosition = new Vector3(0, 0.26f, 0);
            presser = other.gameObject;
            //presserを押されたオブジェクトにする
            onPress.Invoke();
            //Invoke(Hogehoge, time)で、time秒後にHogehogeをする
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

    public void SpawnSphere(){ //ボールを量産する
        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere.transform.localPosition = new Vector3(0, 1, 2);
        sphere.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        sphere.AddComponent<Rigidbody>();
    }
   
}