using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float sightSensitivity;

    [SerializeField] private float cameraRotationLimit;
    
    private float currentCamaraRotationX = 0f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RotateCamera();
    }
    
    private void RotateCamera()
    {
        float xRotation = Input.GetAxisRaw("Mouse Y");
        float cameraRotationX = xRotation * sightSensitivity;

        currentCamaraRotationX -= cameraRotationX;
        currentCamaraRotationX = Mathf.Clamp(
            currentCamaraRotationX, -cameraRotationLimit, cameraRotationLimit);

        transform.localEulerAngles = new Vector3(currentCamaraRotationX, 0, 0);
    }
    
}
