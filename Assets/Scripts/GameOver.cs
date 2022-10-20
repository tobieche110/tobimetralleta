using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public int gameScene;
    
    private void Start() {
        Debug.Log(johnMovement.finalPoints);
    }
    private void Update() {

        if (Input.GetKeyDown(KeyCode.Space)){
            SceneManager.LoadScene(gameScene);
        }
    }
}
