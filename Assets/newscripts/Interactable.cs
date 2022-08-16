using UnityEngine;
using System.Collections;

public class Interactable : MonoBehaviour

{   [HideInInspector]
    public UnityEngine.AI.NavMeshAgent playerAgent;
    private bool hasInteracted;

    public virtual void MoveToInteraction(UnityEngine.AI.NavMeshAgent playerAgent)
    {
        hasInteracted = false;
        this.playerAgent = playerAgent;
        playerAgent.destination = this.transform.position;
        playerAgent.stoppingDistance = 2f;

    }

    void Update()
    {
        
        if (!hasInteracted && playerAgent != null && !playerAgent.pathPending)
        {
            if (playerAgent.remainingDistance <= playerAgent.stoppingDistance)
            {
                Interact();
                hasInteracted = true;
            }
               

        }
        
    }

    public virtual void Interact()
    {
        Debug.Log("Interacting with base class.");
    }
}
