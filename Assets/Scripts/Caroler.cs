using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Caroler : MonoBehaviour
{
    public bool isActive = false;
    public Transform Destination;
    public Vector3 target;
    NavMeshAgent agent;

    // The immediate bump in merriment when a caroler starts following the player.
    public float merrimentIncreaseOnJoin = 1f;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;

        // Play audio on Start rather than Awake because
        // Awake scripts execute in a nondeterministic order,
        // getting our carols out of sync.
        GetComponent<AudioSource>().Play();
    }
    // Update is called once per frame
    void Update()
    {
        target = new Vector3 (Destination.position.x, Destination.position.y, transform.position.z);

        if (isActive)
        {
            SetAgentPosition();
        }
        
        if (Input.GetKeyDown(KeyCode.G))
        {
            Debug.Log(this.transform.position.ToString() + ":me. " + target.ToString() + ": destination");
        }
    }

 
    void SetAgentPosition()
    {
        agent.SetDestination(new Vector3(target.x, target.y, transform.position.z));
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.gameObject.name == "Player" && !isActive)
        {
            isActive = true;
            this.GetComponent<AudioSource>().mute = false;
            MerrimentController.IncreaseMerriment(merrimentIncreaseOnJoin);
        }
    }
}
