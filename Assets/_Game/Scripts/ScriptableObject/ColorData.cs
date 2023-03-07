using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum BrickColor
{
    Black = 0,
    Blue = 1,
    Green = 2,
    Purple = 3,
    Red = 4,
    Yellow = 5,
    Null = 6
}
[CreateAssetMenu(fileName = "ColorData", menuName = "ScriptableObjects/ColorData", order = 1)]
public class ColorData : ScriptableObject
{
    [SerializeField] Material[] materials;

    public Material GetMatColor(BrickColor brickColor)
    {
        return materials[(int)brickColor];
    }
}
