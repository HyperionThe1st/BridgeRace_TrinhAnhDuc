using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public enum PlayerColor
{
    black,
    blue,
    green,
    purple,
    red,
    yellow
}
public class Character : MonoBehaviour
{
    private int brick_count;
    private int player_number;
    private int floor_number;

    public Character()
    {

    }
    public Character(int brick_count, int player_number, int floor_number)
    {
        this.brick_count = brick_count;
        this.player_number = player_number;
        this.floor_number = floor_number;
    }
    
    public void AddBrick()
    {

    }

    public void ReleaseBrick()
    {

    }
    public void VaCham()
    {

    }

}
