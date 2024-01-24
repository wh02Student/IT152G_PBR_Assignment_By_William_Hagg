using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerController : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 5f;
    [SerializeField] private float lookSpeed = 100f;
    [SerializeField] private Rigidbody rigidbody;
    [SerializeField] private Transform camera;

    private Vector2 move;
    private Vector2 look;

    private float verticalLookAngle;
    private float horizontalLookAngle;

    void Update()
    {
        verticalLookAngle += look.y * lookSpeed * Time.deltaTime;
        horizontalLookAngle += look.x * lookSpeed * Time.deltaTime;
        verticalLookAngle = Mathf.Clamp(verticalLookAngle, -90f, 90f);
        camera.rotation = Quaternion.Euler(-verticalLookAngle, horizontalLookAngle, 0);
        
        rigidbody.velocity = Quaternion.Euler(0, horizontalLookAngle, 0) * new Vector3(move.x * movementSpeed, rigidbody.velocity.y, move.y * movementSpeed);
    }

    // This method can be used through the UnityEvent in PlayerInput
    public void OnMove(InputAction.CallbackContext context)
    {
        move = context.ReadValue<Vector2>().normalized;
    }

    public void OnLook(InputAction.CallbackContext context)
    {
        look = context.ReadValue<Vector2>().normalized;
    }
}
