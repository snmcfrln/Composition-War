using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

[RequireComponent(typeof(Unit))]
public class Swordsman : MonoBehaviour{

    private Unit unit;
    private NavMeshAgent agent;
    public Collider[] targets;
    private Transform target;
    private float range = 13f;
    private bool targeted = false;



    // Use this for initialization
    void Start ()
    {
        unit = GetComponent<Unit>();
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update ()
    {
	    if(unit.isActive == true)
        {

        }
    }

    void FindTargets()
    {
        targets = Physics.OverlapSphere(transform.position, range);
    }

    void DetermineTarget()
    {
        targeted = false;
        for (int i = 0; i < targets.Length; i++)
        {
            if (targets[i].gameObject.tag == "Enemy")
            {
                targeted = true;
                if (target == transform)
                {
                    target = targets[i].transform;
                }
                else
                {
                    if (Vector3.Distance(targets[i].transform.position, transform.position) <= Vector3.Distance(target.transform.position, transform.position))
                    {
                        target = targets[i].transform;
                    }
                }
            }
        }
    }
}
