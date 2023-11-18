using System;
using UnityEngine;
using UnityEngine.AI;

public class CarolerPlayer : MonoBehaviour
{
    public bool isPlayer;
    public Transform Destination;
    public Vector3 target;
    public NavMeshAgent agent;
    public Animator animator; // Reference to the Animator component

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        animator = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        if (VictoryController.IsPlayerVictorious)
        {
            HandlePlayerVictory();
            return;
        }

        SetTargetPosition();
        SetAgentPosition();
        UpdateAnimator();

        if (Input.GetKeyDown(KeyCode.G))
        {
            Debug.Log(this.transform.position.ToString() + ":me. " + target.ToString() + ": destination");
        }
    }

    void SetTargetPosition()
    {
        if (Input.GetMouseButtonDown(0))
        {
            target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
    }
    void SetAgentPosition()
    {
        agent.SetDestination(new Vector3(target.x, target.y, transform.position.z));
    }

    void UpdateAnimator()
    {
        Vector3 direction = (target - transform.position).normalized;
        float horizontal = direction.x;
        float vertical = direction.y;

        if (Math.Abs(horizontal) > Math.Abs(vertical))
        {
            if (horizontal > 0)
            {
                animator.SetBool("Up", false);
                animator.SetBool("Down", false);
                animator.SetBool("Left", false);
                animator.SetBool("Right", true);
            }
            else
            {
                animator.SetBool("Up", false);
                animator.SetBool("Down", false);
                animator.SetBool("Left", true);
                animator.SetBool("Right", false);
            }

        }
        else if (Math.Abs(horizontal) < Math.Abs(vertical))
        {
            if (vertical > 0)
            {
                animator.SetBool("Up", true);
                animator.SetBool("Down", false);
                animator.SetBool("Left", false);
                animator.SetBool("Right", false);
            }
            else
            {
                animator.SetBool("Up", false);
                animator.SetBool("Down", true);
                animator.SetBool("Left", false);
                animator.SetBool("Right", false);
            }
        }
        else
        {
            animator.SetBool("Up", false);
            animator.SetBool("Down", true);
            animator.SetBool("Left", false);
            animator.SetBool("Right", false);
        }

        if (Input.GetKeyDown(KeyCode.R)) { Debug.Log(horizontal); }
        // Set the parameters in the Animator
        animator.SetFloat("Horizontal", horizontal);
        animator.SetFloat("Vertical", vertical);
        animator.SetFloat("Speed", agent.velocity.magnitude);
    }

    private void HandlePlayerVictory()
    {
        animator.SetBool("Up", false);
        animator.SetBool("Down", true);
        animator.SetBool("Left", false);
        animator.SetBool("Right", false);
        animator.SetFloat("Speed", 0f);
    }
}
