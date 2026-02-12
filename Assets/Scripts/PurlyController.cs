// using UnityEngine;

// public class PurlyController : MonoBehaviour
// {
//     public float moveSpeed = 5f;
//     public float rotateSpeed = 200f;

//     void Update()
//     {
//         float move = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
//         float rotate = -Input.GetAxis("Horizontal") * rotateSpeed * Time.deltaTime;

//         transform.Translate(0, move, 0);
//         transform.Rotate(0, 0, rotate);
//     }
// }

using UnityEngine;
using UnityEngine.InputSystem;

public class PurlyController : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed = 4f;

    [Header("Rotation (turn on feet)")]
    public float rotationSpeed = 540f;

    [Tooltip("Try 0, 90, 180, or 270 until directions match.")]
    public float yawOffsetDegrees = 0f;

    [Tooltip("Flip the computed angle if left/right or up/down is reversed.")]
    public bool invertAngle = false;

    [Header("Depth")]
    public float lockedZ = -2f;

    void Start()
    {
        // Lock Z so you never drift into/out of camera depth
        Vector3 p = transform.position;
        p.z = lockedZ;
        transform.position = p;

        // Start upright
        transform.rotation = Quaternion.Euler(0f, 0f, 0f);
    }

    void Update()
    {
        // Input (New Input System)
        Vector2 input = Vector2.zero;
        var kb = Keyboard.current;

        if (kb != null)
        {
            if (kb.aKey.isPressed || kb.leftArrowKey.isPressed)  input.x -= 1f;
            if (kb.dKey.isPressed || kb.rightArrowKey.isPressed) input.x += 1f;
            if (kb.wKey.isPressed || kb.upArrowKey.isPressed)    input.y += 1f;
            if (kb.sKey.isPressed || kb.downArrowKey.isPressed)  input.y -= 1f;
        }

        if (input.sqrMagnitude > 1f) input.Normalize();

        // Move on X/Y only
        Vector3 move = new Vector3(input.x, input.y, 0f);
        transform.position += move * moveSpeed * Time.deltaTime;

        // Lock Z
        Vector3 pos = transform.position;
        pos.z = lockedZ;
        transform.position = pos;

        // Rotate on Y only (on feet)
        if (move.sqrMagnitude > 0.0001f)
        {
            // Compute angle from movement direction
            float angle = Mathf.Atan2(move.y, move.x) * Mathf.Rad2Deg;

            // Optional flip
            if (invertAngle) angle = -angle;

            // Apply offset to match your model's "front"
            float targetY = angle + yawOffsetDegrees;

            Quaternion targetRot = Quaternion.Euler(0f, targetY, 0f);
            transform.rotation = Quaternion.RotateTowards(
                transform.rotation,
                targetRot,
                rotationSpeed * Time.deltaTime
            );
        }

        // Force upright: no X/Z tilt
        Vector3 e = transform.eulerAngles;
        transform.rotation = Quaternion.Euler(0f, e.y, 0f);
    }
}


