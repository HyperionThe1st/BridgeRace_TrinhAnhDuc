using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayInstruction : Character
{
    [SerializeField] private Character _player;  
    private Vector3 raycastDirection;
    private BrickColor playerNumber = BrickColor.Black;

    // Start is called before the first frame update
    void Awake()
    {
        raycastDirection = _player.transform.forward;
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
                            AddBrick(_player, brick);
                            int count = _player.brick_count;
                            Debug.Log(count);
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
                    //Brick brick = other.GetComponent<Brick>();

                    Player p = _player.GetComponent<Player>();
                    Step step = other.GetComponent<Step>();
                    if (step != null && _player.brick_count > 0)
                    {
                        step.Start_ChangeColor(BrickColor.Black);
                        _player.brick_count--;
                        Debug.Log(_player.brick_count);
                    }
                    else
                    {
                        Debug.Log("Stop");
                        
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
}
