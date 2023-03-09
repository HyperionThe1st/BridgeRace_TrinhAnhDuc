using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayInstruction : Character
{
    [SerializeField] private Character _char;
    [SerializeField] private Player _player;

    private Vector3 raycastDirection;
    private BrickColor playerNumber = BrickColor.Black;
    public bool isRun = true;
    // Start is called before the first frame update
    void Awake()
    {
        raycastDirection = _char.transform.forward;
    }

    // Update is called once per frame
    void Update()
    {
        //RaycastInfrontPlayer(raycastDirection);
    }

    private void OnTriggerEnter(Collider other)
    {
        switch (other.tag)
        {
            case Variable.NOCOLORBRICK:
                {
                    Brick brick = other.GetComponent<Brick>();
                    if (brick != null)
                    {
                        //Material brickMaterial = BrickManager.Instance.GetBrickMaterial(brick);
                        //BrickColor temp = BrickManager.Instance.MaterialNumber(brickMaterial);
                        //int brickNumber = BrickManager.Instance.GetColorNumber(temp);
                        //_brickClass.ChangeSpecificBrick(brick, BrickColor.Null);
                        //Debug.Log(playerNumber + " and " + numbTemp);
                        BrickColor numbTemp = brick._brickColor;
                        if (playerNumber == numbTemp)
                        {
                            AddBrick(_char, brick);
                            int count = _char.brick_count;
                        }
                    }
                    break;
                }
            case Variable.PLAYER:
                {
                    //Va cham
                    break;
                }
            case Variable.BRIDGESTEP:
                {
                    Step step = other.GetComponent<Step>();
                    BoxCollider bcl = step.GetComponent<BoxCollider>();
                    if (step._brickColor != player_number && _char.brick_count > 0)
                    {
                        ReleaseBrick(_char, step);

                    }
                    else if (step._brickColor != player_number && _char.brick_count == 0)
                    {
                        _player.Stop();
                    }
                    else if (step._brickColor==player_number)
                    {
                        _player.NotStop();
                    }
                    break;
                }
        }
    }
    public void ObjectCompaction(Character player1, Character player)
    {
    }
    GameObject RaycastInfrontPlayer(Vector3 RayCastDirection)
    {
        Vector3 startingPoint = transform.position + new Vector3(0, 0.5f, 0);
        RaycastHit hit;
        if (Physics.Raycast(
                startingPoint,
                RayCastDirection,
                out hit,
                100f))
        {
            return hit.transform.gameObject;
        }
        else
        {
            return null;
        }
    }
    public bool GetState()
    {
        return isRun;
    }

}
