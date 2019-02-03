using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{

    // Nesho brojki tuka
    public int startingHealth = 200;
    public int currentHealth;
    public Slider HealthBar;

    public Color flashColour = new Color(1f, 0f, 0f, 0.1f);
    AudioSource playerAudio;
    public AudioClip deathClip;

    // Nesho Referenci do objekti tuka
    Movement playerMovement;
    public CameraShake camera;

    // Nesho proverki
    bool dead;
    bool damaged;
    float timer;

    public float regainTime = 0.2f;
    public int healthRegenValue = 1;


    void Awake()
    {
        playerMovement = GetComponent<Movement>();
        playerAudio = GetComponent<AudioSource>();

        currentHealth = startingHealth;
        camera = GetComponent<CameraShake>();
    }

    // Update is called once per frame
    void Update()
    {
        if (damaged){
            //todo
            // falat animacii i stvar
        }
        else
        {
            //todo
            // falat animacii za regen
        }

        damaged = false;


        // Health Regenaration
        if(currentHealth < startingHealth && !dead)
        {
            if(timer > regainTime)
            {
                currentHealth += healthRegenValue;
                HealthBar.value = currentHealth;
                timer = 0;
            }

            timer += Time.deltaTime;

        }

    }

    public void TakeDamage(int ammount)
    {
        damaged = true;

        currentHealth -= ammount;

        HealthBar.value = currentHealth;

        //camera.TriggerShake();

        if(currentHealth <= 0)
        {
            Death();
        }

    }

    void Death()
    {
        dead = true;
        playerAudio.clip = deathClip;
        playerAudio.Play();
        SceneManager.LoadScene("DeathScene", LoadSceneMode.Single);

        playerMovement.movementDisabled = true;
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "TopceHuman")
        {
            TakeDamage(40);
            collision.gameObject.tag = "Untagged";
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Health")
        {
            currentHealth += 50;
            if (currentHealth > startingHealth) { currentHealth = startingHealth; };
            HealthBar.value = currentHealth;
            Destroy(other.gameObject);

        }
    }
}
