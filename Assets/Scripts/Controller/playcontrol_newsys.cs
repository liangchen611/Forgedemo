using UnityEngine;
using UnityEngine.InputSystem; // 新输入系统的命名空间

public class playcontrol_newsys : MonoBehaviour
{
    public float movspeed = 5.0f;
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private Vector2 moveInput;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        var keyboard = Keyboard.current;
        float x = 0f;
        if (keyboard != null)
        {
            if (keyboard.aKey.isPressed || keyboard.leftArrowKey.isPressed)
            {
                x = -1.0f;
            }
            else if (keyboard.sKey.isPressed || keyboard.rightArrowKey.isPressed)
            {
                x= 1.0f;
            }

        }

        moveInput = new Vector2(x, 0);

        if (x != 0)
            sr.flipX = x < 0;
    }

    private void FixedUpdate()
    {
        if (rb != null)
        {
            rb.linearVelocity = new Vector2(moveInput.x * movspeed, rb.linearVelocity.y);
        }
    }
}
