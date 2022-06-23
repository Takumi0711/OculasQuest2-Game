using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyScript : MonoBehaviour
{
    private Rigidbody rb;
    //Rigidbody型の変数
    private OVRGrabbable grabbed;
    //OVRGrabbable型の変数
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        grabbed = GetComponent<OVRGrabbable>();
    }

    // Update is called once per frame
    void Update()
    {
        if(grabbed.isGrabbed){//持たれているときとそうでないときで物理演算をオンオフする
            rb.isKinematic = false;
        }
        else{
            rb.isKinematic = true;
        }        
    }
}
