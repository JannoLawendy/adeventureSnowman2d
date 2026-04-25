using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float rotationSpeed = 300f;
    [SerializeField] private InputActionAsset inputActions;

    private InputAction move;
    private InputAction rotate;
    private Rigidbody2D rb;

    private Vector2 moveInput;
    private float rotateInput;
    private bool isDead = false;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

        if (inputActions == null)
        {
            Debug.LogError("Input Actions NOT assigned on PlayerController!");
            return;
        }

        InputActionMap playerMap = inputActions.FindActionMap("Player");

        if (playerMap == null)
        {
            Debug.LogError("Player action map not found!");
            return;
        }

        move = playerMap.FindAction("Move");
        rotate = playerMap.FindAction("Rotate");

        if (move == null) Debug.LogError("Move action not found!");
        if (rotate == null) Debug.LogError("Rotate action not found!");
    }

    private void OnEnable()
    {
        move?.Enable();
        rotate?.Enable();
    }

    private void OnDisable()
    {
        move?.Disable();
        rotate?.Disable();
    }

    private void Update()
    {
        if (isDead) return;

        if (move != null)
            moveInput = move.ReadValue<Vector2>();

        if (rotate != null)
            rotateInput = rotate.ReadValue<float>();

        if (Keyboard.current != null && Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene("LandingScene");
        }
    }

    private void FixedUpdate()
    {
        if (isDead) return;
        if (rb == null) return;

        rb.linearVelocity = moveInput * moveSpeed;

        float newRotation = rb.rotation - rotateInput * rotationSpeed * Time.fixedDeltaTime;
        rb.MoveRotation(newRotation);
    }

    public void Die()
    {
        isDead = true;
        if (rb != null)
        {
            rb.linearVelocity = Vector2.zero;
        }
    }

    public Vector3 GetCurrentPosition()
    {
        return transform.position;
    }

    public float GetMiddleSphereRotationY()
    {
        return transform.eulerAngles.y;
    }

    public void RestoreSavedState(Vector3 savedPosition, float savedMiddleSphereYRotation)
    {
        transform.position = savedPosition;

        Vector3 rotation = transform.eulerAngles;
        rotation.y = savedMiddleSphereYRotation;
        transform.eulerAngles = rotation;
    }
}