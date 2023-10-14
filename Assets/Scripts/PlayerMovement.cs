using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5;

    public Rigidbody rb;

    public float horizontalMultiplier = 2; 

    float horizontalInput;

    bool isAlive = true;

    public GameObject GameLoss;

    [SerializeField] float jumpForce = 400f;

    [SerializeField] LayerMask groundMask;

     private void Awake()
    {
        //SwipeDetection.OnSwipe += SwipeDetection_OnSwipe;
    }

    private void SwipeDetection_OnSwipe(SwipeData data)
    {
        Debug.Log("Swipe in Dirction: " + data.Direction);
        if (data.Direction == SwipeDirection.Up)
        {
           

            float height = GetComponent<Collider>().bounds.size.y;
            bool isGrounded = Physics.Raycast(transform.position, Vector3.down, (height / 2) + 0.1f, groundMask);

            if (isGrounded) 
            {
                rb.velocity = new Vector3(0, 27, 0);
            }
            // If we are, jump.
            //rb.AddForce(Vector3.up * jumpForce);
            
            //Jump();
        }

        if (data.Direction == SwipeDirection.Left)
        {
            horizontalInput = Input.GetAxis("Horizontal");
            horizontalInput--;
        }

        if (data.Direction == SwipeDirection.Right)
        {
            horizontalInput = Input.GetAxis("Horizontal");
            horizontalInput++;
        }
    }

    public void FixedUpdate()
    {
        if (!isAlive) 
            return;

        Vector3 forwardMove = transform.forward * speed * Time.fixedDeltaTime;
        Vector3 horizontalMove = transform.right * horizontalInput * speed * Time.fixedDeltaTime * horizontalMultiplier;
        rb.MovePosition(rb.position + forwardMove + horizontalMove);

        if (transform.position.y < 0) 
        {
            Die();
        }
    }

    void Start()
    {
        //SwipeDetection.OnSwipe += SwipeDetection_OnSwipe;
    }

    void OnEnable() {
        SwipeDetection.OnSwipe += SwipeDetection_OnSwipe;
    }
    void OnDisable() {
        SwipeDetection.OnSwipe -= SwipeDetection_OnSwipe;
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        // if (Input.GetKeyDown(KeyCode.Space)) 
        // {
        //   Jump();  
        // }

        // if (Input.GetMouseButton(0))
        // {
        //     if (Input.mousePosition.x > Screen.width / 2)
        //         horizontalInput = 1;
        //     else
        //         horizontalInput = -1;
        // }
    }

    public void Die ()
    {
        isAlive = false;
        // Restart the game;
        //Vibrator.Vibrate();
        GameLoss.SetActive(true);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        //Invoke("Restart", 2);
    }

    // private void Restart() 
    // {
    //     SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    // }

    void Jump()
    {
        // Check whether we are currently in the air.
        float height = GetComponent<Collider>().bounds.size.y;
        bool isGrounded = Physics.Raycast(transform.position, Vector3.down, (height / 2) + 0.1f, groundMask);

        //Vibrator.Vibrate();
        // If we are, jump.
        rb.AddForce(Vector3.up * jumpForce);
        Debug.Log("rb: "+ rb);
    }
}
