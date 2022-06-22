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

    private bool doseCrouching;
    //しゃがんでいるかどうかのフラグ

    public float JumpForce = 0.3f;
    private Vector3 MoveThrottle = Vector3.zero;

    void Awake()
    {
        //Controller = gameObject.GetComponent<CharacterController>();
    }

    void Start()
    {
        controller = GetComponent<CharacterController>();

        controller.height = 1.0f;
        doseCrouching = false;

    }
 
    void Update()
    {
        moveH = OVRInput.Get(OVRInput.RawAxis2D.LThumbstick).x;
        //Getは、指定したボタン（今回はスティック）を押し続けているという判定
        moveV = OVRInput.Get(OVRInput.RawAxis2D.RThumbstick).y;
        movement = new Vector3(moveH, 0, moveV);
 
        Vector3 desiredMove = cameraC.transform.forward * movement.z + cameraC.transform.right * movement.x;
        moveDir.x = desiredMove.x * 3f;
        moveDir.z = desiredMove.z * 3f;
        moveDir.y -= gravity * Time.deltaTime;
 
        controller.Move(moveDir * Time.deltaTime * speed);

        Crouch();
        //Jump();
    }

    private void Crouch(){
        if(OVRInput.GetDown(OVRInput.Button.Two)){
            if(doseCrouching == false){
                //GetDownは指定したボタン（またはスティックを押したときという判定）
                controller.height = 0.5f;
                //ボタンが押されたときにCharacterControllerのHeightを変える
                doseCrouching = true;
            }else{
                controller.height = 1.0f;
                doseCrouching = false;
            }
        }
    }

    /*public bool Jump(){
		if (!Controller.isGrounded)
			return false;

		MoveThrottle += new Vector3(0, transform.lossyScale.y * JumpForce, 0);

		return true;
	}*/

}