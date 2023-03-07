using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting;
using Random = UnityEngine.Random;


public class Brick : MonoBehaviour
{

    [SerializeField] private ColorData colorData;
    [SerializeField] private MeshRenderer renderer;


    public BrickColor _brickColor;


    private void Start()
    {
        Start_ChangeColor(GetBrickColor());
    }
    private void Update()
    {
    }
    public void Start_ChangeColor(BrickColor brickColor)
    {

        _brickColor = brickColor;
        renderer.material = colorData.GetMatColor(brickColor);
    }

    public BrickColor GetBrickColor()
    {
        int temp = Random.Range(0, 6);
        switch (temp)
        {
            case 0:
                {
                    return BrickColor.Black;

                }
            case 1:
                {
                    return BrickColor.Blue;

                }
            case 2:
                {
                    return BrickColor.Green;

                }
            case 3:
                {
                    return BrickColor.Purple;

                }
            case 4:
                {
                    return BrickColor.Red;

                }
            case 5:
                {
                    return BrickColor.Yellow;

                }
            default: return BrickColor.Black;
        }
    }
    public void AfterHit(Brick _brick, BrickColor nullColor)
    {
        _brickColor = nullColor;
        renderer.material = colorData.GetMatColor(nullColor);
    }

    public void ResetColorAfterTime()
    {
        Invoke("Change", 2.5f);
    }

    private void Change()
    {
        if (_brickColor == BrickColor.Null)
        {
            Start_ChangeColor(GetBrickColor());
        }
    }

}
