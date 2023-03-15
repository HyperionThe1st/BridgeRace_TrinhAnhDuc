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
    private List<BrickColor> brickColorList;

    public BrickColor _brickColor;
    [SerializeField] private PlatformController pc;
    private void Start()
    {
        brickColorList = new List<BrickColor>(pc.platformColorList);
        Start_ChangeColor(RandomColor(brickColorList));
    }
    private void Update()
    {
        if (_brickColor==BrickColor.Null)
        {
            ResetColorAfterTime(1);
        }
        brickColorList = new List<BrickColor>(pc.platformColorList);
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

    public void ResetColorAfterTime(int a)
    {
        if (a==1)
        {
            Invoke("Change", 3.5f);
        } else if (a==2)
        {
            Invoke("StayChange",10.0f);
        }
        
    }

    public void StayChange()
    {
        if (_brickColor==BrickColor.Null)
        {
            Start_ChangeColor(RandomColor(brickColorList));
        }
        
    }

    private void Change()
    {
        if (_brickColor == BrickColor.Null)
        {
            Start_ChangeColor(RandomColor(brickColorList));
        }
    }
    public BrickColor RandomColor(List<BrickColor> lists)
    {
        BrickColor c;
        int a = Random.Range(0,lists.Count);
        c = lists[a];
        return c;
    }

    public void GetFatherColor(List<BrickColor> f_list, List<BrickColor> s_list)
    {
        f_list.Clear();
        foreach (BrickColor c in s_list)
        {
            f_list.Add(c);
        }
    }

}
