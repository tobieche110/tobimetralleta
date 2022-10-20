using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class johnMovement : MonoBehaviour
{

    //sonidos
    public AudioClip landing;
    public AudioClip step;
    public AudioClip jump;
    public AudioClip hitSound;

    public int Health;
    public float Speed;
    public float JumpForce;
    public GameObject BulletPrefab;

    private bool Grounded;
    private bool justJumped = false;

    private Rigidbody2D Rigidbody2D;
    private Animator Animator;

    private float Horizontal;
    private float LastShoot;
    public int gameOverScene;

    //Health Script
    public Image[] healthSlots;

    //puntaje
    private float tiempo;
    private float lastTime;
    public static string finalPoints;

    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        Animator = GetComponent<Animator>();
        lastTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        Horizontal = Input.GetAxisRaw("Horizontal");

        if (Horizontal < 0.0f){
            transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
            //Camera.main.GetComponent<AudioSource>().PlayOneShot(step);
        } else if (Horizontal > 0.0f){
            transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
            //Camera.main.GetComponent<AudioSource>().PlayOneShot(step);
        }

        Animator.SetBool("Running", Horizontal != 0.0f);
        Animator.SetBool("Hit", false);

        //puntos
        tiempo = Time.time - lastTime;
        finalPoints = tiempo.ToString("F2");

        //Jump Raycast
        if (Physics2D.Raycast(transform.position,Vector3.down,0.1f)){
            Grounded = true;
            Animator.SetBool("Grounded", true);
            //Camera.main.GetComponent<AudioSource>().PlayOneShot(landing);
            
            if (justJumped == true){
                Camera.main.GetComponent<AudioSource>().PlayOneShot(landing);
                justJumped = false;
            }
        }
        else{
            Grounded = false;
            Animator.SetBool("Grounded", false);
        }

        //Jump
        if ((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) && Grounded){
            Jump();
            Camera.main.GetComponent<AudioSource>().PlayOneShot(jump);
            justJumped = true;
        }

        //Shoot
        if (Input.GetKey(KeyCode.Space) && Time.time > LastShoot + 0.10f){
            Shoot();
            LastShoot = Time.time;
        }

    }

    private void Jump(){
        Rigidbody2D.AddForce(Vector2.up*JumpForce);
    }

    private void FixedUpdate() {
        Rigidbody2D.velocity = new Vector2(Horizontal, Rigidbody2D.velocity.y);

    }

    private void Shoot(){

        Vector3 direction;
        if (transform.localScale.x == 1.0f) direction = Vector2.right;
        else direction = Vector2.left; 

        GameObject bullet = Instantiate(BulletPrefab, transform.position + direction * 0.1f, Quaternion.identity);
        bullet.GetComponent<bulletScript>().SetDirection(direction);
    }

    public void Hit(){
        Health = Health - 1;
        Animator.SetBool("Hit", true);
        Camera.main.GetComponent<AudioSource>().PlayOneShot(hitSound);
        LoseHealth();
        if (Health == 0) SceneManager.LoadScene(gameOverScene);
    }

    public void LoseHealth(){
        //Decrease value of Health and hide one healthSlot img
        healthSlots[Health].enabled = false;
    }
}
