using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rigidbody2d;
    public GameObject wonGamePannel;
    public GameObject LostGamePannel;
    public float defaultSpeed;
    public float accelerationTime;
    public float acceleration;
    float speed;
    bool isGameOver;
    float horizontalSpeed;
    float verticalSpeed;
    float movementTime;
    
    private void Start() {
        speed = defaultSpeed;
    }

    void Update()
    {
        if(isGameOver){
            horizontalSpeed = 0;
            verticalSpeed = 0;
            return;
        }
        horizontalSpeed = Input.GetAxis("Horizontal");
        verticalSpeed = Input.GetAxis("Vertical");
        if(Input.GetKey("space")){
            horizontalSpeed = 0;
            verticalSpeed = 0;
        }
        if(horizontalSpeed == 0 && verticalSpeed == 0)
            movementTime = 0;
        else
            movementTime += Time.deltaTime;
        if(movementTime >= accelerationTime)
            speed += acceleration * Time.deltaTime;
        else
            speed = defaultSpeed;
    }

    private void FixedUpdate() {
        if(Mathf.Abs(horizontalSpeed) > 0)
            rigidbody2d.velocity = new Vector2(horizontalSpeed * speed, 0);
        else if(Mathf.Abs(verticalSpeed) > 0)
            rigidbody2d.velocity = new Vector2(0, verticalSpeed * speed);
        else
            rigidbody2d.velocity = new Vector2(0, 0);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Door"){
            Debug.Log("Level Completed");
            wonGamePannel.SetActive(true);
            isGameOver = true;
        }
        else if(other.tag == "Enemy"){
            Debug.Log("Game Over");
            LostGamePannel.SetActive(true);
            isGameOver = true;
        }
    }

    public void RestartGame(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
