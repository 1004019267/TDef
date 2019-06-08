using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyMove : MonoBehaviour {
    NavMeshAgent agent;
    Move move;
    int wayIndex = 0;
	// Use this for initialization
	void Start () {
        this.gameObject.layer = LayerMask.NameToLayer("Enemy");
        move = GameObject.FindObjectOfType<Move>();
        agent = this.GetComponent<NavMeshAgent>();
        agent.SetDestination(move.GetPoint(wayIndex));
	}
	
	// Update is called once per frame
	void Update () {
        if (ReachTarget())
        {
            wayIndex++;
            if (wayIndex>=move.points.Length)
            {
                Debug.Log("到达");
            }
            else
            {
                agent.SetDestination(move.GetPoint(wayIndex));
            }
        }
	}
    bool ReachTarget()
    {
        if (agent.isActiveAndEnabled)
        {
            if (!agent.pathPending&&agent.remainingDistance<=agent.stoppingDistance)
            {
                return true;
            }
        }
        return false;
    }
}
