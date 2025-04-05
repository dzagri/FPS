using System.Threading;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody))]
public class InputManager : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] float speed = 6f;
    [SerializeField] float sensitivity = 1f;
    [SerializeField] float jumpForce = 5f;
    [SerializeField] float groundDistance = 1.5f;
    [SerializeField] LayerMask groundMask;

    [Header("Actions")]
    [SerializeField] private InputActionReference move;
    [SerializeField] private InputActionReference jump;
    [SerializeField] private InputActionReference look;

    Rigidbody rb;
    Camera cam;
    float verticalRotation;
    readonly float minY = -85f;
    readonly float maxY = 85f;
    bool isGrounded;
    bool isJumping;
    Vector2 moveInput;
    Vector2 camInput;
    Vector3 movement;
    Vector3 camPosition;

    void OnEnable()
    {
        move.action.Enable();
        jump.action.Enable();
        look.action.Enable();
    }

    void OnDisable()
    {
        move.action.Disable();
        jump.action.Disable();
        look.action.Disable();
    }

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Start()
    {
        cam = Camera.main;
        rb.freezeRotation = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        CheckGround();
        Input();
    }

    private void LateUpdate()
    {
        Look();
    }

    private void FixedUpdate()
    {
        Move();
    }
    private void Input()
    {
        moveInput = move.action.ReadValue<Vector2>();

        if (isGrounded && jump.action.WasPerformedThisFrame())
        {
            isJumping = true;
        }

        camInput = look.action.ReadValue<Vector2>();
    }

    private void Move()
    {
        movement = transform.right * moveInput.x + transform.forward * moveInput.y;

        rb.velocity = new Vector3(movement.x * speed, rb.velocity.y, movement.z * speed);
        
        if(isJumping)
        {
            rb.velocity = new Vector3(transform.position.x, jumpForce, transform.position.y);
            isJumping = false;
        }

    }

    private void Look()
    {
        if(cam != null)
        {
            camPosition = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z);

            cam.transform.position = Vector3.Lerp(cam.transform.position, camPosition, Mathf.SmoothStep(0.0f, 1.0f, 0.75f));

            transform.Rotate(camInput.x * sensitivity * Vector3.up);

            verticalRotation -= camInput.y * sensitivity;
            verticalRotation = Mathf.Clamp(verticalRotation, minY, maxY);

            Quaternion targetRot = Quaternion.Euler(verticalRotation, transform.eulerAngles.y, 0f);
            cam.transform.rotation = Quaternion.Slerp(cam.transform.rotation, targetRot, Mathf.SmoothStep(0.0f, 1.0f, 0.25f));
            
        }
    }

    private void CheckGround()
    {
        isGrounded = Physics.Raycast(transform.position, Vector3.down, groundDistance, groundMask);
    }
}
