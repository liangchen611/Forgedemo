using UnityEngine;
using UnityEngine.InputSystem; // 新输入系统的命名空间

public class playcontrol_newsys : MonoBehaviour
{
    // 1st moving
    public float movspeed = 5.0f;
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private Vector2 moveInput;

    //1st jump
    public float jumpforce = 10.0f;
    public LayerMask groundlayer;
    public Transform groundcheck;
    public float groundcheckradius = 0.1f;
    private bool isgrounded;

    //跳跃冷却时间
    private float lastjumptime = 0f;
    public float jumpcooldown = 0.1f;

    //检测地面状态
    private float coyoteTime = 0.1f;
    private float lastgroundtime = -1f;

    //动画器
    private Animator animator;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        var keyboard = Keyboard.current;
        float x = 0f;

        animator.SetFloat("speed", Mathf.Abs(moveInput.x));
        animator.SetBool("isgrounded", isgrounded);
        if (keyboard != null)
        {
            if (keyboard.aKey.isPressed || keyboard.leftArrowKey.isPressed)
            {
                x = -1.0f;
            }
            else if (keyboard.dKey.isPressed || keyboard.rightArrowKey.isPressed)
            {
                x= 1.0f;
            }

            //jumpcooldown：跃起后，记录当前跃起的时间，随着帧计算当前时间与跃起时间的时间差，如果小于跳跃冷却，则不可起跳
            //coyotetime：计算跳跃后的时间离最后跃起的时间的时间差，太短说明离起跳时点还很近，防止短时间内连续起跳
            if (keyboard.spaceKey.wasPressedThisFrame && 
                isgrounded == true && 
                Time.time-lastjumptime>jumpcooldown &&
                Time.time-lastgroundtime<=coyoteTime)
            {
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpforce);
                lastjumptime = Time.time;
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

        isgrounded = Physics2D.OverlapCircle(groundcheck.position, groundcheckradius, groundlayer);
        
        //在平面上，时刻更新最后时间
        if (isgrounded)
        {
            lastgroundtime = Time.time;
        }
    }

    void OnDrawGizmosSelected()
    {
        if (groundcheck != null)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(groundcheck.position, groundcheckradius);
        }
    }
}
