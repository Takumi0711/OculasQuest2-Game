using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerScript : MonoBehaviour
{
    public GameObject piggyBunk;
    public GameObject hammer;

    public AudioClip sound;
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        piggyBunk.SetActive(true);
        hammer.SetActive(true);

        audioSource = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision){
        //衝突した相手の情報をCollision型で返す（Collision型には様々な情報が含まれている）
        if(collision.gameObject.CompareTag("PiggyBunk")){
            audioSource.PlayOneShot(sound);
            piggyBunk.SetActive(false);
        }
    }
}
