
using UnityEngine.UI;
using UnityEngine;

public class BossAi : MonoBehaviour
{
    public float speed;
    private Transform target;
    public GameObject player;
    PlayerHealth playerHealth;
    public float randomNumber;
    public GameObject BallGlow;
    public Slider healthBar;
    public GameObject Ball;

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

        if (Vector2.Distance(transform.position, target.position) > 10 && Vector2.Distance(transform.position, target.position) < 40)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
        if (Vector2.Distance(transform.position, target.position) < 20)
        {
            if (timer >= betweenAttacks && health > 0)
            {

                attack();
            }
        }


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
        if (playerHealth.currentHealth > 0)
        {
            randomNumber = Random.Range(0, 10);
            if (randomNumber % 2 == 0)
            {

                    GameObject BallInstance = Instantiate(Ball, transform.position, transform.rotation);
                    Rigidbody2D BallRigidbody = BallInstance.GetComponent<Rigidbody2D>();
                   // if (rotationSide == 1)
                   // {
                        BallRigidbody.AddForce(new Vector2(-80, 0), ForceMode2D.Impulse);

                  //  }
                   // else { BallRigidbody.AddForce(new Vector2(80, 0), ForceMode2D.Impulse); }

                    Destroy(BallInstance, 0.5f);

                }
            timer = 0;
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Topce")
        {
            health -= 40;
            collision.gameObject.tag = "Untagged";
        }
    }
}
