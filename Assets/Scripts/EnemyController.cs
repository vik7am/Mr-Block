using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public string wallTag = "Wall";
    public PlayerController player;
    public Rigidbody2D rb;
    public float speed;
    float movementSpeed;

    void Start()
    {
        movementSpeed = speed;
    }

    void FixedUpdate()
    {
        if(player.GameRunning())
            rb.velocity = new Vector2(0, movementSpeed);
        else
            rb.velocity = new Vector2(0, 0);
    }

    public void Flip(){
        movementSpeed = -movementSpeed;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == wallTag){
            Flip();
        }
    }
}
