using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField] private float walkSpeed;

    [SerializeField] private float runSpeed;

    [SerializeField] private float sightSensitivity;

    [SerializeField] private float cameraRotationLimit;

    [SerializeField] private Camera playerCamera;

    private Rigidbody _rigidbody;
    private float _currentCamaraRotationX = 0f;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }
    void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        RotateCamera();
        RotateCharacter();
    }

    private void Move()
    {
        float actualSpeed;

        if (Input.GetKey(KeyCode.LeftShift))
        {
            
        }
        
        float moveDirX = Input.GetAxisRaw("Horizontal");
        float moveDirZ = Input.GetAxisRaw("Vertical");

        Transform trans = transform;

        Vector3 moveHorizontal = trans.right * moveDirX;
        Vector3 moveVertical = trans.forward * moveDirZ;

        Vector3 velocity = (moveHorizontal + moveVertical).normalized * walkSpeed;

        _rigidbody.MovePosition(trans.position + velocity * Time.deltaTime);

    }

    private void RotateCharacter()
    {
        float yRotation = Input.GetAxisRaw("Mouse X");
        Vector3 characterRotationY = new Vector3(0f, yRotation, 0f) * sightSensitivity;
        
        _rigidbody.MoveRotation(_rigidbody.rotation * Quaternion.Euler(characterRotationY));
    }

    private void RotateCamera()
    {
        float xRotation = Input.GetAxisRaw("Mouse Y");
        float cameraRotationX = xRotation * sightSensitivity;

        _currentCamaraRotationX -= cameraRotationX;
        _currentCamaraRotationX = Mathf.Clamp(
            _currentCamaraRotationX, -cameraRotationLimit, cameraRotationLimit);

        playerCamera.transform.localEulerAngles = new Vector3(_currentCamaraRotationX, 0, 0);
    }
}
