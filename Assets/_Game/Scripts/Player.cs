using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    //Component:

    [SerializeField] private CharacterController _charController;
    [SerializeField] private Animator _animator;
    [SerializeField] private Joystick _mngrJoystick;


    //Transform:
    private Transform meshPlayer;


    //Movement:
    private float inputX;
    private float inputZ;
    private Vector3 v_movement;
    [SerializeField] private float movementSpeed;
    [SerializeField] private float gravity;

    // Start is called before the first frame update
    void Start()
    {
        GameObject tempPlayer = GameObject.FindGameObjectWithTag("Player");
        _charController = tempPlayer.GetComponent<CharacterController>();
        meshPlayer = tempPlayer.transform.GetChild(0);
        _animator = meshPlayer.GetComponent<Animator>();
        _mngrJoystick = GameObject.Find("imgJoystickBg").GetComponent<Joystick>();
    }

    // Update is called once per frame
    void Update()
    {
        inputX = _mngrJoystick.InputHorizontal();
        inputZ = _mngrJoystick.InputVertical();
        if (inputX == 0 && inputZ == 0)
        {
            _animator.SetBool("isRunning", false);
        }
        else
        {
            _animator.SetBool("isRunning", true);
        }


    }

    private void FixedUpdate()
    {

        //gravity:
        float tempY;

        if (_charController.isGrounded)
        {
            v_movement.y = 0f;
        }
        else
        {
            v_movement.y -= gravity * Time.fixedDeltaTime;
        }
        tempY = v_movement.y;
        //movement:
        v_movement = new Vector3(inputX * movementSpeed, tempY, inputZ * movementSpeed);
        _charController.Move(v_movement);

        //mesh rotate:
        if (inputX != 0 || inputZ != 0)
        {
            Vector3 lookDir = new Vector3(v_movement.x, 0, v_movement.z);
            meshPlayer.rotation = Quaternion.LookRotation(lookDir);
        }

    }
}
