using UnityEngine;
using UnityEngine.Windows;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class BoxTest : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    
    private InputActions _input;
    private Vector3 _moveDirection;

    private void Start()
    {
        _input = new InputActions();
        _input.Enable();
        _input.Gameplay.Move.performed += OnMoveActionPerformed;
        _input.Gameplay.Move.canceled += OnMoveActionCancelled;

        Debug.LogError("START");
    }

    private void OnDestroy()
    {
        _input.Gameplay.Move.performed -= OnMoveActionPerformed;
        _input.Gameplay.Move.canceled -= OnMoveActionCancelled;
    }

    private void Update()
    {
        Move();
    }

    private void OnMoveActionPerformed(InputAction.CallbackContext context)
    {
        _moveDirection = context.ReadValue<Vector2>();

        Debug.LogError($"PERFORMED: {_moveDirection}");
    }

    private void OnMoveActionCancelled(InputAction.CallbackContext context)
    {
        _moveDirection = Vector2.zero;

        Debug.LogError($"CANCELLED: {_moveDirection}");
    }

    private void Move()
    {
        var direction = transform.forward * _moveDirection.y + transform.right * _moveDirection.x;
        transform.Translate(direction * Time.deltaTime, Space.World);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision detected with " + collision.gameObject.name);
    }
}
