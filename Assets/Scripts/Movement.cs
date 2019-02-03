using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Movement : MonoBehaviour
{
    public float speed = 10f;
    private float jumpCount = 0f;
    public float jumpSpeed = 18f;
    public float stamina = 5f;
    private bool IsRunning = false;
    private Rigidbody2D myScriptsRigidbody2D;
    public Slider StaminaBar;
    public GameObject enemy;
    EnemyAI EnemyScript;
    public Animator animator;
    private float healthEnemy;
    private Transform enemyDistance;
    public GameObject sr;
    SpriteRenderer srSprite;
    public float rotationSide = 1;
    //Appear StartScreen
    public GameObject StartScreen1;
    public GameObject StartScreen2;
    public GameObject StartScreen3;
    //Appear bar
    public GameObject Bar1;
    public GameObject Bar2;
    public GameObject Bar3;
    //WiFi Icon && ANTENAS
    public GameObject AntenaTekst;
    public GameObject CurrentAntena;
    private bool AntenaActive;
    public Sprite[] WiFi;
    public float ActiveAntenas = 0;
    public bool movementDisabled = false;
    //Launch Ball Attack
    public float Balls = 10;
    public Text text;
    public GameObject Ball;
    public float timerKey = 3f;
    public GameObject FinishText;
    //LIGHT
    public GameObject[] LightFlash;


    private void Awake()
    {
        enemyDistance = GameObject.FindGameObjectWithTag("Enemy").GetComponent<Transform>();
        srSprite = sr.GetComponent<SpriteRenderer>();
        print(srSprite);
    }

    void Start()
    {
        myScriptsRigidbody2D = GetComponent<Rigidbody2D>();
        StaminaBar.value = stamina;
    }
    private void FixedUpdate()
    {
        if (!movementDisabled)
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                rotationSide = 1;
                transform.position += Vector3.left * speed * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                rotationSide = 0;
                transform.position += Vector3.right * speed * Time.deltaTime;

            }
            if (Input.GetKeyDown(KeyCode.UpArrow) && jumpCount <= 1)
            {
                jumpCount++;
                myScriptsRigidbody2D.AddForce(new Vector2(0, jumpSpeed), ForceMode2D.Impulse);
                StartScreen1.SetActive(false);
                StartScreen2.SetActive(false);
                StartScreen3.SetActive(false);
                Bar1.SetActive(true);
                Bar2.SetActive(true);
                Bar3.SetActive(true);

            }

            if (Input.GetKey(KeyCode.LeftShift) && (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow)))
            {
                if (stamina > 0) { speed = 12f; }
                else { speed = 9f; }
                IsRunning = true;

            }
            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                speed = 9f;
                IsRunning = false;
            }
            if (Input.GetKeyUp(KeyCode.Space))
            {
                if (enemy != null)
                {
                    EnemyScript.health -= 30;
                }
            }
            if (IsRunning)
            {
                if (stamina >= 0) { stamina -= Time.deltaTime; }
            }
            if (IsRunning == false)
            {
                if (stamina <= 4) { stamina += Time.deltaTime / 4; }
            }
            animator.SetBool("running", IsRunning);
        }
    }
    void Update()
    {
        text.text = Balls.ToString();
        StaminaBar.value = stamina;

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.localEulerAngles = new Vector3(0, 0, 0);
            StartScreen1.SetActive(false);
            StartScreen2.SetActive(false);
            StartScreen3.SetActive(false);
            Bar1.SetActive(true);
            Bar2.SetActive(true);
            Bar3.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.localEulerAngles = new Vector3(0, -180, 0);
            StartScreen1.SetActive(false);
            StartScreen2.SetActive(false);
            StartScreen3.SetActive(false);
            Bar1.SetActive(true);
            Bar2.SetActive(true);
            Bar3.SetActive(true);
        }
        if (timerKey <= 2)
        {
            timerKey+=Time.deltaTime;
        } 
        if (Input.GetKeyDown(KeyCode.C))
        {
            
            if (Balls > 0 && timerKey >= 2)
            {
                timerKey = 0;
                Balls--;
                GameObject BallInstance = Instantiate(Ball, transform.position, transform.rotation);
                Rigidbody2D BallRigidbody = BallInstance.GetComponent<Rigidbody2D>();
                if (rotationSide == 1)
                {
                    BallRigidbody.AddForce(new Vector2(-80, 0), ForceMode2D.Impulse);
                }
                else { BallRigidbody.AddForce(new Vector2(80, 0), ForceMode2D.Impulse); }

                Destroy(BallInstance, 0.5f);
            }
        }

        if (Input.GetKeyDown(KeyCode.X) && AntenaActive == true)
        {
            ActiveAntenas++;
            if (ActiveAntenas == 0) { srSprite.sprite = WiFi[0]; }
            else if (ActiveAntenas == 1) { srSprite.sprite = WiFi[0]; LightFlash[0].SetActive(true); }
            else if (ActiveAntenas == 2) { srSprite.sprite = WiFi[1]; LightFlash[1].SetActive(true); }
            else if (ActiveAntenas == 3) { srSprite.sprite = WiFi[2]; LightFlash[2].SetActive(true); }
            else if (ActiveAntenas == 4) { srSprite.sprite = WiFi[3]; LightFlash[3].SetActive(true); }
            CurrentAntena.tag = "Untagged";
            CurrentAntena = null;
            AntenaTekst.SetActive(false);
            AntenaActive = false;
        }

    }
    void OnCollisionEnter2D()
    {
        jumpCount = 0;
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            enemy = other.gameObject;

            EnemyScript = other.GetComponent<EnemyAI>();
            print(EnemyScript.health);

        }
        if (other.gameObject.tag == "Antena")
        {
            CurrentAntena = other.gameObject;
            AntenaTekst.SetActive(true);
            AntenaActive = true;
        }
        if (other.gameObject.tag == "TopceGloe")
        {
            Balls++;
            Destroy(other.gameObject);

        }
        if (other.gameObject.tag == "Finish")
        {
            FinishText.SetActive(true);  

        }

    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Antena")
        {
            CurrentAntena = null;
            AntenaTekst.SetActive(false);
            AntenaActive = false;
        }
        if (other.gameObject.tag == "Enemy")
        {
            enemy = null;
            EnemyScript = null;

        }


    }
}
