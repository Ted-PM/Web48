using UnityEngine;

public class ToggleMoveObject : MonoBehaviour
{
    public float moveDistance = 5f;  // Distance to move on the X-axis
    public float speed = 2f;         // Speed of movement (adjustable in the Inspector)

    private Vector3 startPosition;   // The starting position of the object
    private Vector3 targetPosition;  // The target position to move to

    private bool isAtTarget = false; // Flag to check if the object is currently at the target position

    void Start()
    {
        // Store the object's initial position and set the target position
        startPosition = transform.position;
        targetPosition = startPosition + new Vector3(moveDistance, 0, 0);
    }

    void Update()
    {
        // Check if the F key is pressed
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (isAtTarget)
            {
                // If the object is at the target position, move it back to the start position
                StartCoroutine(SmoothMove(startPosition));
            }
            else
            {
                // If the object is not at the target position, move it to the target position
                StartCoroutine(SmoothMove(targetPosition));
            }

            // Toggle the flag to track the current position
            isAtTarget = !isAtTarget;
        }
    }

    // Smoothly move the object towards the target position
    System.Collections.IEnumerator SmoothMove(Vector3 target)
    {
        // Record the initial position
        Vector3 initialPosition = transform.position;

        float timeElapsed = 0f;

        // Move the object towards the target position
        while (timeElapsed < 1f)
        {
            timeElapsed += Time.deltaTime * speed;  // Increase elapsed time based on speed
            transform.position = Vector3.Lerp(initialPosition, target, timeElapsed);  // Interpolate between start and target position
            yield return null;  // Wait until the next frame
        }

        // Ensure that the object ends up at the exact target position
        transform.position = target;
    }
}