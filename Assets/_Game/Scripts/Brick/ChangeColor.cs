using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    private Renderer _renderBrick;
    [SerializeField] GameObject _objBrick;


    private void Start()
    {
        //GetBrick:
        _renderBrick=_objBrick.GetComponent<Renderer>();

    }

}
