using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BrickManager : MonoBehaviour
{
    public static BrickManager Instance;
    public Dictionary<BrickColor, Material> MaterialDict = new Dictionary<BrickColor, Material>();
    public List<Material> Materials = new List<Material>();
    private void Awake()
    {
        Instance = this;
        for (int i = 0; i < Materials.Count; i++)
        {
            switch (i)
            {
                case 0:
                    MaterialDict.Add(BrickColor.Black, Materials[i]);
                    break;
                case 1:
                    MaterialDict.Add(BrickColor.Blue, Materials[i]);
                    break;
                case 2:
                    MaterialDict.Add(BrickColor.Green, Materials[i]);
                    break;
                case 3:
                    MaterialDict.Add(BrickColor.Purple, Materials[i]);
                    break;
                case 4:
                    MaterialDict.Add(BrickColor.Red, Materials[i]);
                    break;
                case 5:
                    MaterialDict.Add(BrickColor.Yellow, Materials[i]);
                    break;
            }
        }
    }


    //public Material GetBrickMaterial(Brick brick)
    //{
    //    Renderer _renderer;
    //    Material _material;
    //    _renderer = brick._renderer;
    //    _material = _renderer.material;
    //    return _material;
    //}


    public BrickColor MaterialNumber(Material thisMaterial)
    {

        bool checkMaterialExist = MaterialDict.ContainsValue(thisMaterial);

        if (checkMaterialExist == true)
        {
            return MaterialDict.FirstOrDefault(x => x.Value == thisMaterial).Key;
        }
        else
        {
            return BrickColor.Null;
        }
    }

    public int GetColorNumber(BrickColor _brickColor)
    {
        int temp = 7;
        BrickColor bc = _brickColor;
        temp = (int)bc;
        return temp;
    }

}
