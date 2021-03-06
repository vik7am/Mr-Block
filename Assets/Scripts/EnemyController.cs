using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public PlayerController player;
    public Rigidbody2D rigidbody2d;
    public GameUI gameUI;
    float movementSpeed;
    bool playerVisible;
    public float speed;
    public float followSpeed; 
    public bool patrollingEnemy;
    public bool chasingEnemy;
    public bool horizontalPatroll;
    public string wallTag = "Wall";
    public string playerTag = "Player";

    void Awake()
    {
        movementSpeed = speed;
    }

    void Update(){
        if(gameUI.GamePaused())
            return;
        if(chasingEnemy)
            ChasePlayer();
    }

    void FixedUpdate()
    {
        if(gameUI.GamePaused()){
            Stop();
            return;
        }
        if(patrollingEnemy)
            Patroll();
    }

    void Patroll(){
        if(chasingEnemy && playerVisible)
            return;
        if(horizontalPatroll)
            rigidbody2d.velocity = new Vector2(movementSpeed, 0);
        else
            rigidbody2d.velocity = new Vector2(0, movementSpeed);
    }

    void ChasePlayer(){
        if(playerVisible)
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, followSpeed * Time.deltaTime);
    }

    void Flip(){
        movementSpeed = -movementSpeed;
    }

    void Stop(){
        rigidbody2d.velocity = new Vector2(0, 0);
    }

    void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == wallTag)
            Flip();
    }

    void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == playerTag){
            playerVisible = true;
            Stop();
        }
    }

    void OnTriggerExit2D(Collider2D other) {
        if(other.tag == playerTag)
            playerVisible = false;
    }
}
