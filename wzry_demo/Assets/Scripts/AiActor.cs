using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class AiActor : MonoBehaviour
{
    private NavMeshAgent agent;
    private Transform[] targetTrans;
    private int NextTarget = 0;
    private Animator anim;
    // Start is called before the first frame update
    private void OnEnable()
    {
        anim = transform.GetComponent<Animator>();
    }

    public void InitData(Transform[] targetTran)
    {
        targetTrans = targetTran;
        agent = transform.GetComponent<NavMeshAgent>();
        startMove();
    }

    private void startMove()
    {
        if(NextTarget>= targetTrans.Length)
        {
            isStop(true);
            return;
        }
        if (targetTrans[NextTarget])
        {
            isStop(false);
            agent.destination = targetTrans[NextTarget].position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (NextTarget >= targetTrans.Length)
        {
            isStop(true);
            return;
        }
        if (targetTrans[NextTarget])
        { 
            //print(transform.name+"--距离---" + Vector3.Distance(transform.position, targetTrans[NextTarget].position));
            if (Vector3.Distance(transform.position, targetTrans[NextTarget].position) < 1f)
            {
                NextTarget++;
                startMove();
            }
        }
    }

    public void isStop(bool state)
    {
        agent.isStopped = state;
        anim.SetBool("run", !state);
    }
}
