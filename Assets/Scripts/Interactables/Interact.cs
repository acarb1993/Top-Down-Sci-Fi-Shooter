using UnityEngine;

public class Interact : MonoBehaviour
{
    public IInteractable Interactable { get; private set; }

    public void InteractWithTarget()
    {
        Interactable.OnInteract();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check for null is done at the input
        Interactable = collision.gameObject.GetComponent<IInteractable>();
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        // When exiting the trigger, the interactable should not be interactable anymore
        Interactable.OnOutOfRange();
        Interactable = null;
    }
}
