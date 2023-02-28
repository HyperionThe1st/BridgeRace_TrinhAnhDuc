using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayInstruction : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    [SerializeField] private Renderer m_MeshRenderer;
    private Material m_Material;
    private Vector3 raycastDirection;
    private BrickManager brickMng;
    private GameObject _tempObject;


    // Start is called before the first frame update
    void Start()
    {
        m_Material = m_MeshRenderer.material;
        raycastDirection = _player.transform.forward;

    }

    // Update is called once per frame
    void Update()
    {
        RaycastInfrontPlayer(raycastDirection);
    }

    private void OnTriggerEnter(Collider other)
    {
        switch (other.tag)
        {
            case "NoColorBrick":
                {
                    Brick brick = other.GetComponent<Brick>();
                    if (brick != null)
                    {
                        Material brickMaterial = BrickManager.Instance.GetBrickMaterial(brick);
                        if (m_Material == brickMaterial)
                        {
                            Debug.Log("equal");
                        }
                    }
                    Destroy(other.gameObject);
                    break;
                }
            case "Enemy":
                {
                    //Va cham
                    break;
                }
            default:
                break;
        }
    }

    public void ObjectCompaction(GameObject other, GameObject player)
    {
        int first_player_brick = CountBrick(player);
        int second_player_brick = CountBrick(other);
        if (first_player_brick > second_player_brick)
        {
            // HitPlayer(other); (Xu li va cham --> Vang het gach)
        }
        else if (second_player_brick > first_player_brick)
        {

        }
        else
        {

        }

    }

    public int CountBrick(GameObject _gameobject)
    {
        int brick_count = 0;


        return brick_count;
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



    //public int checkBrick()
    //{

    //}

}
