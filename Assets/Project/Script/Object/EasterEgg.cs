using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EasterEgg : MonoBehaviour
{
    NavMeshAgent navMeshAgent;
    NavMeshPath path;

    public float timerForNewPath;

    bool validPath;
    bool inCoRoutine;

    Vector3 target;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        path = new NavMeshPath();
    }

    void Update()
    {
        if (!inCoRoutine)
            StartCoroutine(DoSomething());
    }
    Vector3 getNewRandomPosition ()
    {
        float x = Random.Range(-20, 20);
        float y = 2;
        float z = Random.Range(-10, 10);
       //float z = Random.Range(-20, 20);

        Vector3 pos = new Vector3(x, y, z);
        return pos;
    }
    IEnumerator DoSomething ()
    {
        inCoRoutine = true;

        yield return new WaitForSeconds(timerForNewPath);
        GetNewPath();
        validPath = navMeshAgent.CalculatePath(target, path);

        if (!validPath) Debug.Log("Found an invalid Path");

        while (!validPath)
        {
            yield return new WaitForSeconds(0.1f);
            GetNewPath();
            validPath = navMeshAgent.CalculatePath(target, path);
        }
        inCoRoutine = false;
    }

    void GetNewPath ()
    {
        target = getNewRandomPosition();
        navMeshAgent.SetDestination(target);
    }
}
