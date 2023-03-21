using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //Component:
    [SerializeField] private CharacterController _charController;
    [SerializeField] private Animator _animator;
    [SerializeField] private Joystick _mngrJoystick;
    [SerializeField] private GameObject tempPlayer;

    //Transform:
    private Transform meshPlayer;


    //Movement:
    private float inputX;
    private float inputZ;
    private Vector3 v_movement;
    private float movementSpeed;
    [SerializeField] private float gravity;

    // Start is called before the first frame update
    void Start()
    {

        _charController = tempPlayer.GetComponent<CharacterController>();
        meshPlayer = tempPlayer.transform.GetChild(0);
        _animator = meshPlayer.GetComponent<Animator>();
        _mngrJoystick = GameObject.Find(Variable.IMGJOYSTICKBACKGROUND).GetComponent<Joystick>();
    }

    // Update is called once per frame
    void Update()
    {
        inputX = _mngrJoystick.InputHorizontal();
        inputZ = _mngrJoystick.InputVertical();
        if (inputX == 0 && inputZ == 0)
        {
            _animator.SetBool(Variable.ISRUNNING, false);
        }
        else
        {
            _animator.SetBool(Variable.ISRUNNING, true);
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



        if (movementSpeed > 0)
        {
            v_movement = new Vector3(inputX * movementSpeed, tempY, inputZ * movementSpeed);
        }
        while (movementSpeed == 0)
        {
            if (inputZ > 0)
            {
                Stop();
                v_movement = new Vector3(inputX * movementSpeed, tempY, inputZ * movementSpeed);
                break;
            }
            else
            {
                NotStop();
                v_movement = new Vector3(inputX * movementSpeed, tempY, inputZ * movementSpeed);
                break;
            }
        }

        _charController.Move(v_movement);


        //mesh rotate:
        if (inputX != 0 || inputZ != 0)
        {
            Vector3 lookDir = new Vector3(v_movement.x, 0, v_movement.z);
            meshPlayer.rotation = Quaternion.LookRotation(lookDir);
            gameObject.transform.rotation = Quaternion.LookRotation(lookDir);

        }
    }

    public void Stop()
    {
        movementSpeed = 0;
    }
    public void NotStop()
    {
        movementSpeed = Variable.MOVEMENTSPEED;
    }
}
