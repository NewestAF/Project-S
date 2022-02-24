using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    #region Stat
    
    [SerializeField] private float walkSpeed;
    [SerializeField] private float runSpeed;

    #endregion

    #region Condition

    private bool isRunning;

    #endregion
    

    private new Rigidbody rigidbody;
    

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }
    void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        RotateCharacter();
    }

    private void Move()
    {
        CheckIsRunning();
        
        float moveDirX = Input.GetAxisRaw("Horizontal");
        float moveDirZ = Input.GetAxisRaw("Vertical");

        Transform trans = transform;

        Vector3 moveHorizontal = trans.right * moveDirX;
        Vector3 moveVertical = trans.forward * moveDirZ;

        Vector3 velocity = (moveHorizontal + moveVertical).normalized * walkSpeed;

        rigidbody.MovePosition(trans.position + velocity * Time.deltaTime);

    }

    private void CheckIsRunning()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            
        }
        
    }

    private void RotateCharacter()
    {
        float yRotation = Input.GetAxisRaw("Mouse X");
        Vector3 characterRotationY = new Vector3(0f, yRotation, 0f) * 10;
        
        rigidbody.MoveRotation(rigidbody.rotation * Quaternion.Euler(characterRotationY));
    }

    
}
