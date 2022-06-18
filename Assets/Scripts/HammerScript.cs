using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerScript : MonoBehaviour
{
    public GameObject piggyBunk;
    public GameObject hammer;

    public AudioClip[] sounds = new AudioClip[2];
    private AudioSource audioSource;

    public GameObject[] textBox = new GameObject[2];

    public GameObject door;

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
        textBox[0].SetActive(false);
        textBox[1].SetActive(false);
        door.SetActive(true);

        audioSource = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();
        grabbed = GetComponent<OVRGrabbable>();
        //それぞれのコンポートを取得
    }

    void Update(){
        if(grabbed.isGrabbed){//持たれているときとそうでないときで物理演算をオンオフする
            rb.isKinematic = false;
        }
        else{
            rb.isKinematic = true;
        }
    }

    private void OnCollisionEnter(Collision collision){
        //衝突した相手の情報をCollision型で返す（Collision型には様々な情報が含まれている）
        if(collision.gameObject.CompareTag("PiggyBunk")){
            audioSource.PlayOneShot(sounds[0]);
            piggyBunk.SetActive(false);
            textBox[1].SetActive(true);
            door.SetActive(false);
        }
    }
}


