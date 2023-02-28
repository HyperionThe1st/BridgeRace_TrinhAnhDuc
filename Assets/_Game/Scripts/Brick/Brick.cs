using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting;
using Random = UnityEngine.Random;

public enum BrickColor
{
    Black = 0,
    Blue = 1,
    Green = 2,
    Purple = 3,
    Red = 4,
    Yellow = 5
}
public class Brick : MonoBehaviour
{
    [SerializeField] private ColorData colorData;
    [SerializeField] private Renderer renderer;

    public BrickColor BrickColor { get; set; }
    public Renderer Renderer { get => renderer; set => renderer = value; }

    private void Start()
    {
        ChangeColor(GetBrickColor());
    }

    public void ChangeColor(BrickColor brickColor)
    {
        BrickColor = brickColor;
        renderer.material = colorData.GetMatColor(brickColor);
    }

    private BrickColor GetBrickColor()
    {
        int temp = Random.Range(0, 6);
        switch (temp)
        {
            case 0:
                {
                    return BrickColor.Black;
                    break;
                }
            case 1:
                {
                    return BrickColor.Blue;
                    break;
                }
            case 2:
                {
                    return BrickColor.Green;
                    break;
                }
            case 3:
                {
                    return BrickColor.Purple;
                    break;
                }
            case 4:
                {
                    return BrickColor.Red;
                    break;
                }
            case 5:
                {
                    return BrickColor.Yellow;
                    break;
                }
                default: return BrickColor.Black;
        }
    }

}
