
using UnityEngine.UI;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public float speed;
    private Transform target;
    public GameObject player;
    PlayerHealth playerHealth;
    public float randomNumber;
    public GameObject BallGlow;
    public Slider healthBar;

// Sound
AudioSource enemyAudioSource;
    public AudioClip attackClip;


    public float health = 100;
    public float timer;

    // Attack stuff

    public int attackDamage = 20;
    public float betweenAttacks = 3f;


    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        target = player.GetComponent<Transform>();
        playerHealth = player.GetComponent<PlayerHealth>();
        enemyAudioSource = GetComponent<AudioSource>();

    }


    void Update()
    {
        healthBar.value = health;

        timer += Time.deltaTime;

        // Start Following player
        if(Vector2.Distance(transform.position, target.position) > 2 && Vector2.Distance(transform.position, target.position) < 20)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
        if (Vector2.Distance(transform.position, target.position) < 5)
        {
            if (timer >= betweenAttacks && health > 0)
            {

                attack();
            }
        }


        /*if (Vector2.Distance(transform.position, target.position) > 2 && Vector2.Distance(transform.position, target.position) < 7)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }*/

        if (health <= 0)
        {
            Destroy(gameObject);
            float BallNumber = Random.Range(0, 5);
            if (BallNumber == 1)
            {
                Instantiate(BallGlow, transform.position, Quaternion.identity);
            }
            if (BallNumber == 2)
            {
                Instantiate(BallGlow, transform.position, Quaternion.identity);
                Instantiate(BallGlow, transform.position, Quaternion.identity);
            }
            if (BallNumber == 3)
            {
                Instantiate(BallGlow, transform.position, Quaternion.identity);
                Instantiate(BallGlow, transform.position, Quaternion.identity);
                Instantiate(BallGlow, transform.position, Quaternion.identity);
            }
            if (BallNumber == 4)
            {
                Instantiate(BallGlow, transform.position, Quaternion.identity);
                Instantiate(BallGlow, transform.position, Quaternion.identity);
                Instantiate(BallGlow, transform.position, Quaternion.identity);
                Instantiate(BallGlow, transform.position, Quaternion.identity);
            }
            if (BallNumber == 5)
            {
                Instantiate(BallGlow, transform.position, Quaternion.identity);
                Instantiate(BallGlow, transform.position, Quaternion.identity);
                Instantiate(BallGlow, transform.position, Quaternion.identity);
                Instantiate(BallGlow, transform.position, Quaternion.identity);
                Instantiate(BallGlow, transform.position, Quaternion.identity);
            }
            
        }
        

    }

    void attack()
    {
        if(playerHealth.currentHealth > 0)
        {
            randomNumber = Random.Range(0, 25);
            enemyAudioSource.clip = attackClip;
            enemyAudioSource.Play();
            if (randomNumber % 2 == 0)
            {
                playerHealth.TakeDamage(attackDamage);
                
            }
            timer = 0;
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Topce")
        {
            health -= 40;
            collision.gameObject.tag = "Untagged";
        }
    }
}
