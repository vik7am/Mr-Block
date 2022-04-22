using UnityEngine;

public class EnemyController : MonoBehaviour
{
    PlayerController player;
    Rigidbody2D rigidbody2d;
    GameUI gameUI;
    float movementSpeed;
    bool playerVisible;
    public float speed;
    public float followSpeed; 
    public bool patrollingEnemy;
    public bool chasingEnemy;
    public string wallTag = "Wall";
    public string playerTag = "Player";

    void Awake()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        player = FindObjectOfType<PlayerController>();
        gameUI = FindObjectOfType<GameUI>();
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
