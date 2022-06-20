using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    private Vector3 movement;
    private CharacterController controller;
 
    public GameObject cameraC;
    private Vector3 moveDir = Vector3.zero;
    private float gravity = 9.8f;
    private float moveH;
    private float moveV;

    [Range(0.1f, 2f)]
	public float crouchHeight = 1f;  // しゃがんだ時の背の高さ
	[Range(0.1f, 5f)]
	public float normalHeight = 2f;  // 通常時の背の高さ
 
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }
 
    void Update()
    {
        moveH = OVRInput.Get(OVRInput.RawAxis2D.LThumbstick).x;
        moveV = OVRInput.Get(OVRInput.RawAxis2D.RThumbstick).y;
        movement = new Vector3(moveH, 0, moveV);
 
        Vector3 desiredMove = cameraC.transform.forward * movement.z + cameraC.transform.right * movement.x;
        moveDir.x = desiredMove.x * 3f;
        moveDir.z = desiredMove.z * 3f;
        moveDir.y -= gravity * Time.deltaTime;
 
        controller.Move(moveDir * Time.deltaTime * speed);

        Crouch();
    }

    private void Crouch(){
        if(Input.GetKey(KeyCode.LeftCommand)){
            controller.height = crouchHeight;
        }
        else{
            controller.height = normalHeight;
        }
    }
}