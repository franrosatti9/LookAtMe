using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IVel
{
    public float moveSmoothTime;
    public float gravity;
    public float jumpForce;
    public float walkSpeed;
    public float runSpeed;

    public Transform groundCheck;
    public LayerMask groundLayer;
    public Transform camera;
    public float sensitivity;

    private CharacterController _controller;
    private PlayerInventory _inventory;
    private Rigidbody _rb;
    private Vector3 _currentVelocity;
    private Vector3 _moveDampVelocity;

    private Vector2 rotation;
    private Vector3 _currentForceVelocity;

    private bool grounded;

    public PlayerInventory Inventory => _inventory;
    void Start()
    {
        _controller = GetComponent<CharacterController>();
        _inventory = GetComponent<PlayerInventory>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        var input = new Vector3(
            Input.GetAxisRaw("Horizontal"), 
            0, 
            Input.GetAxisRaw("Vertical")
        ).normalized;

        var mouseInput = new Vector2(
            Input.GetAxis("Mouse X"),
            Input.GetAxis("Mouse Y")
        );
            
        Vector3 dir = transform.TransformDirection(input);
        float currentSpeed = Input.GetKey(KeyCode.LeftShift) ? runSpeed : walkSpeed;

        _currentVelocity = Vector3.SmoothDamp(_currentVelocity, dir * currentSpeed, ref _moveDampVelocity, moveSmoothTime);

        _controller.Move((_currentVelocity * Time.deltaTime));

        if (Physics.Raycast(groundCheck.position, -transform.up, 0.1f, groundLayer))
        {
            _currentForceVelocity.y = -2;

            if (Input.GetKeyDown(KeyCode.Space))
            {
                _currentForceVelocity.y = jumpForce;
            }
        }
        else
        {
            _currentForceVelocity.y -= gravity * Time.deltaTime;
        }

        _controller.Move((_currentForceVelocity * Time.deltaTime));

        rotation.x -= mouseInput.y * sensitivity;
        rotation.y += mouseInput.x * sensitivity;

        rotation.x = Mathf.Clamp(rotation.x, -90f, 90f);

        transform.eulerAngles = new Vector3(0f, rotation.y, 0f);
        camera.localEulerAngles = new Vector3(rotation.x, 0f, 0f);
    }

    public void Jump()
    {
        if (grounded)
        {
            
        }
    }

    public float Vel => _currentVelocity.magnitude;
}
