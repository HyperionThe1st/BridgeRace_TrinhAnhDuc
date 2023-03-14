using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectFather : MonoBehaviour
{
    [SerializeField] private ColorData colorData;
    [SerializeField] private MeshRenderer renderer;
    public BrickColor stepColor;
    public void Start_ChangeColor(BrickColor brickColor)
    {

        stepColor = brickColor;
        renderer.material = colorData.GetMatColor(brickColor);
    }
}
