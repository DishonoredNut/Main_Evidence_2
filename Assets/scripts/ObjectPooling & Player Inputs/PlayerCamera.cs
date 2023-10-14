using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCamera : MonoBehaviour
{
  private PlayerInputs controls; 
  public float mouseSensitivity = 100f;  
  private Vector2 mouseLook; 
  public float RotationX = 0f; 
 private Transform playerBody; 


void Update() //accesses look functiom
{
    Look();
}
 void Awake () //looks on startup
 {
    playerBody = transform.parent;
    controls = new PlayerInputs(); //This'll allow me to make use of the new input system
    Cursor.lockState = CursorLockMode.Locked; 
 }

 private void Look() //Setup for mouselook
 {
    mouseLook = controls.KeyboardMovement.Look.ReadValue<Vector2>(); 

    float mouseX = mouseLook.x * mouseSensitivity * Time.deltaTime; 
    float mouseY = mouseLook.y * mouseSensitivity * Time.deltaTime;

    RotationX -= mouseY;
    RotationX = Mathf.Clamp(RotationX, -90f, 90f); //limits to 90 degrees up and down.
    transform.localRotation = Quaternion.Euler(RotationX, 0, 0);
    playerBody.Rotate(Vector3.up*mouseX); 
 }
  private void OnEnable()
  {
    controls.Enable(); 
  }
  private void OnDisable()
  {
    controls.Disable();
  }
}
