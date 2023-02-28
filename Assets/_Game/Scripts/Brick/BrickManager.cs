using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickManager : MonoBehaviour
{
    public static BrickManager Instance;
    public Dictionary<BrickColor, Material> MaterialDict = new Dictionary<BrickColor, Material>();
    public List<Material> Materials = new List<Material>();
    private void Awake()
    {
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

    private Renderer _renderer;
    private Material _material;
    public Material GetBrickMaterial(Brick brick)
    {
        _renderer = brick.Renderer;
        _material = _renderer.material;
        Debug.Log(_material + "  mat");
        return _material;
    }

}
