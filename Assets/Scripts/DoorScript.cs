using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject door;
    void Start()
    {
        door.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PushButton(){
        door.SetActive(false);
    }
}
