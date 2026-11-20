using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{

    Vector2 moveInput;
    
    [SerializeField] float maxSpeed;
    [SerializeField] float currentSpeed;

    private Animator animator;
    private Rigidbody2D rb; 

    // Start is called once before the first execution of Update after the MonoBehavi   our is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        currentSpeed = maxSpeed;
    }

    public bool controlEnabled { get; set; } = true;
    // Update is called once per frame
    void Update()
    {
        if (controlEnabled)
        {
            rb.linearVelocity = moveInput * currentSpeed;

        }
    }

    public void Move(InputAction.CallbackContext context)
    {


        if (context.canceled)
        {
            animator.SetFloat("LastHorizontal", moveInput.x);
            animator.SetFloat("LastVertical", moveInput.y);
            animator.SetBool("IsWalking", false);
            currentSpeed = 0;
            moveInput = new Vector2(0, 0);
        }

        if (context.performed)
        {
            animator.SetFloat("Horizontal", moveInput.x);
            animator.SetFloat("Vertical", moveInput.y);
            animator.SetBool("IsWalking", true);
            currentSpeed = maxSpeed;
        }
        

        moveInput = context.ReadValue<Vector2>();

    }

    public void SetBool(bool value)
    {
        controlEnabled = value;
    }


}
