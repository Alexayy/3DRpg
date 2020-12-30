using System;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public float radius = 3f;
    public Transform interactionTransform;

    private bool isFocused = false;
    private Transform player;

    private bool hasInteracted;

    public virtual void Interact()
    {
        // This method is ment to be overriden
        Debug.Log("Interacting with: " + transform.name);
    }

    private void Update()
    {
        if (isFocused && !hasInteracted)
        {
            float distance = Vector3.Distance(player.position, interactionTransform.position);
            if (distance <= radius)
            {
                hasInteracted = true;
                Debug.Log("I N T E R A C T");
            } 
        }
    }

    public void OnFocused(Transform playerTransform)
    {
        isFocused = true;
        player = playerTransform;
        hasInteracted = false;
    }

    public void OnDefocused()
    {
        isFocused = false;
        player = player.transform;
        hasInteracted = false;
    }
    
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(interactionTransform.position, radius);
    }
}
