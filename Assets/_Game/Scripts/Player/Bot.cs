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
        switch (other.tag)
        {
            case Variable.NOCOLORBRICK:
                {
                    Debug.Log("Hit");
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

}
