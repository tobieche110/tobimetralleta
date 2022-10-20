using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletScript : MonoBehaviour
{
    public AudioClip ShootSound;
    public float Speed;
    private Rigidbody2D Rigidbody2D;
    private Vector2 Direction;

    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        Camera.main.GetComponent<AudioSource>().PlayOneShot(ShootSound);
    }

    private void FixedUpdate() {
        Rigidbody2D.velocity = Direction * Speed;    
    }

    public void SetDirection(Vector2 direction){
        Direction = direction;
    }

    public void DestroyBullet(){
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        johnMovement john = collision.collider.GetComponent<johnMovement>();
        gruntScript grunt = collision.collider.GetComponent<gruntScript>();

        if (john != null){
            john.Hit();
        }
        if (grunt != null){
            grunt.Hit();
        }
        DestroyBullet();
    }
}
