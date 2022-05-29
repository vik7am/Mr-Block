using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rigidbody2d;
    public GameUI gameUI;
    public float movementSpeed;
    float horizontalSpeed;
    float verticalSpeed;
    float movementTime;
    public float speed;
    public float accelerationTime;
    public float acceleration;
    public string doorTag = "Door";
    public string enemyTag = "Enemy";
    public string stoneTag = "Stone";

    void Awake() {
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
            gameUI.ShowUI(Panel.PAUSE);
        
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
            gameUI.ShowUI(Panel.WON);
            
        }
    }

    void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == enemyTag){
            gameUI.ShowUI(Panel.LOST);
        }
        else if(other.gameObject.tag == stoneTag){
            movementTime = 0;
        }
    }
}
