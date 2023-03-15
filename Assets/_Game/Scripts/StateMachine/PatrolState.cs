using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.AI;

public class PatrolState : StateMachineBehaviour
{
    float timer;
    PlatformController platCTRL;
    List<Brick> listBricks = new List<Brick>();
    string currentFloor = "Floor1";
    NavMeshAgent agent;
    BrickColor botColor;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //Bot _bot = animator.GetComponentInParent<Bot>();
        Bot _bot = animator.GetComponent<Bot>();
        botColor = _bot.player_number;
        Debug.Log(botColor);
        agent = animator.GetComponent<NavMeshAgent>();
        timer = 0;
        getBrick();
        agent.SetDestination(listBricks[Random.Range(0, listBricks.Count)].transform.position);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        getBrick();
        if (agent.remainingDistance<=agent.stoppingDistance)
        {
            agent.SetDestination(listBricks[Random.Range(0, listBricks.Count)].transform.position);
        }
        timer += Time.deltaTime;
        if (timer > 10)
        {
            animator.SetBool(Variable.ISRUNNING, false);
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        agent.SetDestination(agent.transform.position);
        
    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}

    //void getBot()
    //{
    //    GameObject[] temp = GameObject.FindGameObjectsWithTag("Enemy");
    //    foreach (GameObject go in temp)
    //    {
    //        Bot _bot = go.transform.GetComponent<Bot>();
    //        if (_bot.player_number)
    //        {

    //        }
    //    }
    //}

    void getBrick()
    {
        listBricks.Clear();
        GameObject floorObject = GameObject.FindGameObjectWithTag(currentFloor);
        //GameObject floorObject = thisFloor;
        platCTRL = floorObject.GetComponent<PlatformController>();
        foreach (Transform t in floorObject.transform)
        {
            if (t.CompareTag(Variable.NOCOLORBRICK))
            {
                Brick temp = t.GetComponent<Brick>();
                if (temp._brickColor == botColor)
                {
                    listBricks.Add(temp);
                }
            }
        }
    }

    public void SetCurrentFloor(string temp)
    {
        currentFloor = temp;
    }
}
