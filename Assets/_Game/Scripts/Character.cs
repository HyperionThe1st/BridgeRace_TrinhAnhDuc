using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Character : MonoBehaviour
{

    //Component:

    private Brick _brickclass;

    //Thuoc tinh"
    public int brick_count { get; set; }
    public int player_number { get; set; }
    public int floor_number { get; set; }



    private BrickColor objectColor;
    public Character()
    {

    }







    public void AddBrick(Character character, Brick _brick)
    {
        character.brick_count += 1;
        _brick.Start_ChangeColor(BrickColor.Null);
        _brick.ResetColorAfterTime();
    }

    public void ReleaseBrick()
    {

    }
    public void VaCham()
    {

    }

}
