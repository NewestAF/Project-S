using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    #region Stat
    
    [SerializeField] private float walkSpeed;
    [SerializeField] private float runSpeed;
    [SerializeField] private float jumpForce;
    [SerializeField] private float crouchSpeed;
    [SerializeField] private float crouchPosY;

    #endregion

    #region Condition

    private bool isRunning = false;
    private bool isGround = true;
    

    #endregion
    

    private new Rigidbody rigidbody;
    private CapsuleCollider capsuleCollider;
    

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        capsuleCollider = GetComponent<CapsuleCollider>();
    }
    void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckIsGround();
        TryJump();
        Move();
        RotateCharacter();
    }

    private void Move()
    {
        
        CheckIsRunning();

        float actualSpeed = isRunning ? runSpeed : walkSpeed;
        
        float moveDirX = Input.GetAxisRaw("Horizontal");
        float moveDirZ = Input.GetAxisRaw("Vertical");

        Transform trans = transform;

        Vector3 moveHorizontal = trans.right * moveDirX;
        Vector3 moveVertical = trans.forward * moveDirZ;

        Vector3 velocity = (moveHorizontal + moveVertical).normalized * actualSpeed;

        rigidbody.MovePosition(trans.position + velocity * Time.deltaTime);

    }

    private void CheckIsRunning()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            isRunning = true;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            isRunning = false;
        }
        
    }

    private void CheckIsGround()
    {
        isGround = Physics.Raycast(transform.position, Vector3.down, capsuleCollider.bounds.extents.y + 0.1f);
    }

    private void TryJump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGround)
        {
            DoJump();
        }
    }

    private void DoJump()
    {
        rigidbody.velocity = transform.up * jumpForce;
    }

    private void RotateCharacter()
    {
        float yRotation = Input.GetAxisRaw("Mouse X");
        Vector3 characterRotationY = new Vector3(0f, yRotation, 0f) * 10;
        
        rigidbody.MoveRotation(rigidbody.rotation * Quaternion.Euler(characterRotationY));
    }

    
}
