using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bot : Character
{
    [SerializeField]private Character _char;
    private void Awake()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Hit1");
        switch (other.tag)
        {
            case Variable.NOCOLORBRICK:
                {
                    Debug.Log("Hit2");
                    Brick brick = other.GetComponent<Brick>();
                    if (brick != null)
                    {
                        BrickColor numbTemp = brick._brickColor;
                        if (player_number == numbTemp)
                        {
                            AddBrick(_char, brick);
                            int count = _char.brick_count;
                        }
                    }
                    break;
                }
        } 
    }
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Hit3");
        switch (collision.gameObject.tag)
        {
            case Variable.NOCOLORBRICK:
                {
                    
                    Brick brick = collision.gameObject.GetComponent<Brick>();
                    if (brick != null)
                    {
                        BrickColor numbTemp = brick._brickColor;
                        if (player_number == numbTemp)
                        {
                            AddBrick(_char, brick);
                            int count = _char.brick_count;
                        }
                    }
                    break;
                }
        }
    }

}
