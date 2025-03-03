using UnityEngine;
using UnityEngine.InputSystem;


[RequireComponent(typeof(Rigidbody))] //Script can only be applied to GO's with rgbd2D
public class LessonPC : MonoBehaviour
{
    public float movementSpeed;

    private Rigidbody2D _rb;
    private Vector2 _moveAmount;

   
    void Awake()
    {
        //Unity prefers _rb to rb, and this section will grasp onto the rigidbody
        _rb = GetComponent<Rigidbody2D>();
    }

   
    void Update()
    {
        //Apply the velocity to the Y axis
        _rb.linearVelocityY = _moveAmount.y * movementSpeed;

        //Apply the velocity to the X axis
        _rb.linearVelocityX = _moveAmount.x * movementSpeed;
    }

    //This function will read our movement input and apply it to apply to a variable inside the script
    public void HandleMovement(InputAction.CallbackContext ctx)
    {
       _moveAmount = ctx.ReadValue<Vector2>();


    }



}
