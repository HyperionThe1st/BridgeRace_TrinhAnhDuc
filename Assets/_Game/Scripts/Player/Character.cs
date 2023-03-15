using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Character : MonoBehaviour
{
    //Component:
    private Brick _brickclass;
    [SerializeField] private GameObject brickPrefabs;
    //Thuoc tinh"
    public int brick_count { get; set; }
    [SerializeField] public BrickColor player_number;
    public int floor_number = 1;
    private PlatformController floor;
    private BrickColor objectColor;
    Stack<GameObject> collectedBricks;

    private void Awake()
    {
    }
    private void Start()
    {
        collectedBricks = new Stack<GameObject>();
    }
    public void AddBrick(Character character, Brick _brick)
    {
        character.brick_count += 1;
        _brick.Start_ChangeColor(BrickColor.Null);
        _brick.ResetColorAfterTime(1);
        Vector3 brickPos = character.transform.GetChild(1).position;
        GameObject go = Instantiate(brickPrefabs, new Vector3(brickPos.x, brickPos.y + character.brick_count * Variable.BRICKHEIGHT, brickPos.z), Quaternion.identity, character.transform.GetChild(1));
        collectedBricks.Push(go);

    }

    public void ReleaseBrick(Character character, Step step)
    {
        int brickNumberNow = character.brick_count;
        step.Start_ChangeColor(character.player_number);
        character.brick_count -= 1;
        Destroy(collectedBricks.Pop());
    }

    public void ChangeFloor()
    {

    }
}
