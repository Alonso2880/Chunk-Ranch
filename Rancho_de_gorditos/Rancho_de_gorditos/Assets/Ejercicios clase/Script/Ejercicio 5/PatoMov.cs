using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float rotationSpeed = 100f;
    public float jumpForce = 5f;

    public Transform playerCamera;
    private Rigidbody rb;
    private bool isGrounded = true;


    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        HandleMovement();
        HandleRotation();
        HandleJump();
    }

    void HandleMovement()
    {
        float moveZ = Input.GetAxis("Horizontal"); // A/D → movimiento en eje Z local
        float moveY = Input.GetAxis("Vertical");   // W/S → movimiento en eje Y local

        // Movimiento relativo a la orientación del jugador
        Vector3 move = transform.up * moveY + transform.forward * moveZ;
        transform.position += move * moveSpeed * Time.deltaTime;
    }

    void HandleRotation()
    {
        float mouseX = Input.GetAxis("Mouse X");

        // Rotar sobre el eje X del jugador con el movimiento lateral del ratón
        float rotationAmount = mouseX * rotationSpeed * Time.deltaTime;
        transform.Rotate(rotationAmount, 0f, 0f, Space.Self);
    }
    void HandleJump()
    {
        // Salta al pulsar el botón de salto si esta en contacto con el suelo
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        // Se considera en el suelo si colisiona con algo etiquetado como "Suelo"
        if (collision.gameObject.CompareTag("Suelo"))
        {
            isGrounded = true;
        }
    }

    
}
