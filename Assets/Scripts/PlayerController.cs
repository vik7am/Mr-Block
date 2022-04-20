using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rigidbody2d;
    public GameObject wonGamePannel;
    public GameObject LostGamePannel;
    public float speed;
    //float time = 0f;
    float defaultSpeed;
    bool isGameOver;

    private void Start() {
        defaultSpeed = speed;
    }

    void Update()
    {
        if(isGameOver){
            return;
        }
        
        if(Input.GetAxis("Horizontal") > 0) {
            transform.Translate(new Vector2(speed * Time.deltaTime, 0f));
        }
        else if(Input.GetAxis("Horizontal") < 0) {
            transform.Translate(new Vector2(-speed * Time.deltaTime, 0f));
        }
        else if(Input.GetAxis("Vertical") > 0) {
            transform.Translate(new Vector2(0f, speed * Time.deltaTime));
        }
        else if(Input.GetAxis("Vertical") < 0) {
            transform.Translate(new Vector2(0f, -speed * Time.deltaTime));
        }
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Door"){
            Debug.Log("Level Completed");
            wonGamePannel.SetActive(true);
            isGameOver = true;
            //rigidbody2d.velocity = new Vector2(0f, 0f);
        }
        else if(other.tag == "Enemy"){
            Debug.Log("Game Over");
            LostGamePannel.SetActive(true);
            isGameOver = true;
            //rigidbody2d.velocity = new Vector2(0f, 0f);
        }
    }

    public void RestartGame(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    /*void Update()
    {
        if(isGameOver){
            return;
        }
        if(Input.GetKey("space")){
            rigidbody2d.velocity = new Vector2(0f, 0f);
            speed = defaultSpeed;
            return;
        }
        if(Input.GetAxis("Horizontal") > 0) {
            rigidbody2d.velocity = new Vector2(speed, 0f);
        }
        else if(Input.GetAxis("Horizontal") < 0) {
            rigidbody2d.velocity = new Vector2(-speed, 0f);
        }
        else if(Input.GetAxis("Vertical") > 0) {
            rigidbody2d.velocity = new Vector2(0f, speed);
        }
        else if(Input.GetAxis("Vertical") < 0) {
            rigidbody2d.velocity = new Vector2(0f, -speed);
        }
        else if(Input.GetAxis("Horizontal") == 0 && Input.GetAxis("Vertical") == 0) {
            rigidbody2d.velocity = new Vector2(0f, 0f);
        }
        
        if(Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0){
            time += Time.deltaTime;
        }
        else{
            time = 0f;
            speed = defaultSpeed;
        }

        if(time > 1){
            speed += 1 * Time.deltaTime;
        }
    }*/
}
