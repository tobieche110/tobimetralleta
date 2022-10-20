using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class gruntScript : MonoBehaviour
{   
    public static int totalEnemies = 4;
    private int Health = 3;
    public GameObject BulletPrefab;
    public GameObject John;
    private float LastShoot;
    private Animator Animator;

    //Sounds
    public AudioClip death;
    
    private void Start() {
        
    }

    private void Update() {

        if (John == null) return;

        Vector3 direction = John.transform.position - transform.position;

        if (direction.x >= 0.0f) transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        else transform.localScale = new Vector3(-1.0f,1.0f,1.0f);

        float distance = Mathf.Abs(John.transform.position.x - transform.position.x);

        if (distance < 1.0f && Time.time > LastShoot + 0.75f){
            Shoot();
            LastShoot = Time.time;
        }
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
        if (Health == 0){
            Camera.main.GetComponent<AudioSource>().PlayOneShot(death);
            //Animator.SetTrigger("Death");
            totalEnemies = totalEnemies - 1;
            if (totalEnemies == 0){
                SceneManager.LoadScene(3);
            }
            Debug.Log(totalEnemies);
            Destroy(gameObject);
        }
    }
}
