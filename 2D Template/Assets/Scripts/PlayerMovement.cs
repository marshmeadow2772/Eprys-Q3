using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float normalSpeed = 3f;
    public float boostedSpeed = 4.5f;  // After 3 seconds
    public float sprintSpeed = 6f;     // While holding Shift or gamepad button
    private float moveTimer = 0f;

    private Vector3 target;
    private bool moving;
    private Vector2 lastDirection;

    void Start()
    {
        target = transform.position;
    }

    void Update()
    {
        if (moving)
        {
            float currentSpeed = GetCurrentSpeed();
            transform.position = Vector3.MoveTowards(transform.position, target, currentSpeed * Time.deltaTime);

            if (Vector3.Distance(transform.position, target) < 0.01f)
            {
                transform.position = target;
                moving = false;
            }
        }
        else
        {
            Vector2 dir = GetInput();

            if (dir != Vector2.zero)
            {
                if (dir != lastDirection)
                {
                    moveTimer = 0f;  // Reset timer if direction changes
                }

                Move(dir.normalized);
                lastDirection = dir;
            }
        }
    }

    Vector2 GetInput()
    {
        Vector2 dir = Vector2.zero;

        // Keyboard input
        if (Input.GetKey(KeyCode.W)) dir.y += 1;
        if (Input.GetKey(KeyCode.S)) dir.y -= 1;
        if (Input.GetKey(KeyCode.A)) dir.x -= 1;
        if (Input.GetKey(KeyCode.D)) dir.x += 1;

        // Gamepad input (D-Pad & Left Stick)
        dir.x += Input.GetAxisRaw("Horizontal");
        dir.y += Input.GetAxisRaw("Vertical");

        // Clamp so diagonals aren't faster
        if (dir.sqrMagnitude > 1) dir = dir.normalized;

        return dir;
    }

    void Move(Vector2 dir)
    {
        target = transform.position + new Vector3(dir.x, dir.y, 0);
        moving = true;
        moveTimer += Time.deltaTime;  // Start counting time moving in same direction
    }

    float GetCurrentSpeed()
    {
        // Sprint if Shift is held or B button on gamepad
        bool isSprinting = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)
                        || Input.GetButton("Fire1") || Input.GetButton("Fire3"); // Example: "B" or "A" on Xbox controller

        if (isSprinting)
        {
            return sprintSpeed;
        }

        return moveTimer >= 3f ? boostedSpeed : normalSpeed;
    }
}
