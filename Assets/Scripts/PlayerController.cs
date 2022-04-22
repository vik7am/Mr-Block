using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rigidbody2d;
    GameUI gameUI;
    float movementSpeed;
    float horizontalSpeed;
    float verticalSpeed;
    float movementTime;
    public float speed;
    public float accelerationTime;
    public float acceleration;
    public string doorTag = "Door";
    public string enemyTag = "Enemy";

    void Awake() {
        rigidbody2d = GetComponent<Rigidbody2D>();
        gameUI = FindObjectOfType<GameUI>();
        movementSpeed = speed;
    }

    void Update()
    {
        if(gameUI.GamePaused()){
            horizontalSpeed = 0;
            verticalSpeed = 0;
            return;
        }
        horizontalSpeed = Input.GetAxis("Horizontal");
        verticalSpeed = Input.GetAxis("Vertical");
        PlayerInput();
        PlayerMovementTime();
        PlayerAcceleration();
    }

    void FixedUpdate() {
        if(Mathf.Abs(horizontalSpeed) > 0)
            rigidbody2d.velocity = new Vector2(horizontalSpeed * movementSpeed, 0);
        else if(Mathf.Abs(verticalSpeed) > 0)
            rigidbody2d.velocity = new Vector2(0, verticalSpeed * movementSpeed);
        else
            rigidbody2d.velocity = new Vector2(0, 0);
    }

    void PlayerInput(){
        if(Input.GetKey(KeyCode.Escape))
            gameUI.ShowPauseUI();
        
        if(Input.GetKey(KeyCode.Space))
            Brake();
    }

    void PlayerMovementTime(){
        if(horizontalSpeed == 0 && verticalSpeed == 0)
            movementTime = 0;
        else
            movementTime += Time.deltaTime;
    }

    void PlayerAcceleration(){
        if(movementTime >= accelerationTime)
            movementSpeed += acceleration * Time.deltaTime;
        else
            movementSpeed = speed;
    }

    void Brake(){
        horizontalSpeed = 0;
        verticalSpeed = 0;
    }

    void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == doorTag){
            gameUI.ShowWonUI();
        }
    }

    void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == enemyTag){
            gameUI.ShowLostUI();
        }
    }
}
