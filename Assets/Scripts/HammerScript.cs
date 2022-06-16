using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerScript : MonoBehaviour
{
    public GameObject piggyBunk;
    public GameObject hammer;

    public AudioClip sound;
    private AudioSource audioSource;

    public GameObject textBox;

    private Rigidbody rb;
    //Rigidbody型の変数
    private OVRGrabbable grabbed;
    //OVRGrabbable型の変数

    // Start is called before the first frame update
    void Start()
    {
        //ゲーム起動時のオンオフ
        piggyBunk.SetActive(true);
        hammer.SetActive(true);
        textBox.SetActive(false);

        audioSource = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();
        grabbed = GetComponent<OVRGrabbable>();
        //それぞれのコンポートを取得
    }

    void Update(){
        if(grabbed.isGrabbed){
            rb.isKinematic = true;
        }
        else{
            rb.isKinematic = false;
        }
    }

    private void OnCollisionEnter(Collision collision){
        //衝突した相手の情報をCollision型で返す（Collision型には様々な情報が含まれている）
        if(collision.gameObject.CompareTag("PiggyBunk")){
            audioSource.PlayOneShot(sound);
            //piggyBunk.SetActive(false);
            textBox.SetActive(true);
        }
    }
}


