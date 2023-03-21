using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class Bot : Character
{
    [SerializeField] private Character _char;
    private void Awake()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        switch (other.tag)
        {
            case Variable.NOCOLORBRICK:
                {
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
            case Variable.TRIGGERFLOOR2:
                {
                    PlatformController pc = other.transform.parent.GetComponent<PlatformController>();
                    pc.platformColorList.Add(player_number);
                    break;
                }
            case Variable.BRIDGESTEP:
                {
                    Step step = other.GetComponent<Step>();
                    BoxCollider bcl = step.GetComponent<BoxCollider>();
                    if (step._brickColor != player_number && _char.brick_count > 0)
                    {
                        ReleaseBrick(_char, step);

                    }
                    else if (step._brickColor != player_number && _char.brick_count == 0)
                    {
                        
                    }
                    else if (step._brickColor == player_number)
                    {
                       
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
