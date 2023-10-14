using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
  private PlayerInputs controls; //lets the script and attached player access the new input system
  public float moveSpeed = 7f; 
  private Vector3 velocity; 
 public float gravity = -9.81f; 
  private Vector2 move; 
 public float jumpHeight =2.4f;
  private CharacterController controller;

  public Transform ground;
  public float fromGround = 0.4f; 
  public LayerMask groundLayer; 
  private bool isGrounded; 

  void Awake() //player input functions
  {
    controls = new PlayerInputs();
    controller = GetComponent<CharacterController>(); 
  }

  private void OnEnable()
  {
    controls.Enable(); 
  }

  private void OnDisable()
  {
    controls.Disable(); 
  }

  private void Gravity()
  {
    isGrounded = Physics.CheckSphere(ground.position, fromGround, groundLayer); //checks if groundwd
    if(isGrounded && velocity.y <0)
    {
        velocity.y = -2f;
    }

        velocity.y += gravity * Time.deltaTime; 
        controller.Move(velocity * Time.deltaTime); 
  }

  private void PlayerMovement()
  {
    move = controls.KeyboardMovement.Movement.ReadValue<Vector2>();

    Vector3 movement = (move.y * transform.forward) + (move.x * transform.right); 
    controller.Move(movement * moveSpeed * Time.deltaTime); 
  }

private void JOOMP()//Joomp = MeSpeak for jump (:
{
 if(controls.KeyboardMovement.Jump.triggered){
    velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity); 
 }
}
    // Update is called once per frame
    void Update()
    {
        Gravity();
        PlayerMovement(); 
        JOOMP(); 
    }
}
