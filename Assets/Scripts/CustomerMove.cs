using UnityEngine;

public class CustomerMove : MonoBehaviour
{
    public Transform targetPoint;
    public float moveSpeed = 1f;
    public DialogueManager dialogueManager;

    private bool arrived = false;

    void Update()
    {
        if (arrived)
            return;

        transform.position = Vector3.MoveTowards(
            transform.position,
            targetPoint.position,
            moveSpeed * Time.deltaTime
        );

        if (Vector3.Distance(transform.position, targetPoint.position) < 0.05f)
        {
            arrived = true;
            dialogueManager.StartDialogue();
        }
    }
}