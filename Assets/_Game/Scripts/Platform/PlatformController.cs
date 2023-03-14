using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class PlatformController : MonoBehaviour
{

    [SerializeField] int floorNumber;
    [SerializeField] List<Character> characterList;

    //Thuoc tinh:
    public List<BrickColor> platformColorList;
    //private List<BrickColor> allColor;
    private void Awake()
    {
        
        List<BrickColor> temp = GetListColor(characterList);
        platformColorList = new List<BrickColor>(temp);
        platformColorList.Add(BrickColor.Null);
    }
    private void FixedUpdate()
    {
    }

    public List<BrickColor> GetListColor(List<Character> listChar)
    {
        List<BrickColor> colorList = new List<BrickColor>();
        foreach (Character c in listChar)
        {      
            if (c.floor_number == floorNumber && CheckExistElement((int)c.player_number, colorList) == false)
            {

                BrickColor temp = c.player_number;
                colorList.Add(temp);
            }
        }
        return colorList;
    }

    public bool CheckExistElement(int a, List<BrickColor> b)
    {
        for (int i = 0; i < b.Count; i++)
        {
            if (a == (int)b[i])
            {
                return true;
            }
        }
        return false;
    }

    public List<Brick> GetBricksOnPlane()
    {
        List<Brick> listBrickChills = new List<Brick>();
        for (int i = 0; i < this.transform.childCount; i++)
        {
            Transform tf = this.transform.GetChild(i);
            Brick br = tf.gameObject.GetComponent<Brick>();
            listBrickChills.Add(br);
        }
        return listBrickChills;
    }

    public BrickColor CheckColor(int a, List<BrickColor> bcl)
    {
        foreach (BrickColor bc in bcl)
        {
            if (a == (int)bc)
            {
                return bc;
            }
        }
        return BrickColor.Null;
    }


    public List<BrickColor> GetPlatformColorList()
    {

        return this.platformColorList;
    }

}
