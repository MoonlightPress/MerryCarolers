using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CarolerPlayer : MonoBehaviour
{
    public bool isPlayer;
    public Transform Destination;
    public Vector3 target;
    NavMeshAgent agent;
    // Start is called before the first frame update
    void Start()
    {
         agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }
    // Update is called once per frame
    void Update()
    {
    SetTargetPosition();
        SetAgentPosition();
        if(Input.GetKeyDown(KeyCode.G)) { Debug.Log(this.transform.position.ToString() +":me. "+ target.ToString() +": destination" ); }
    }

    void SetTargetPosition()
    {
        if(Input.GetMouseButtonDown(0))
        {
            target = Camera.main.ScreenToWorldPoint( Input.mousePosition );
        }
    }
    void SetAgentPosition()
    {
        agent.SetDestination(new Vector3(target.x, target.y, transform.position.z));
    }

}
