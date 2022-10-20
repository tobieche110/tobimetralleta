using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public int gameScene;

    public void StartGames(){
        SceneManager.LoadScene(gameScene);
    }

    private void Update() {
        if(Input.GetKeyDown(KeyCode.Return)){
            SceneManager.LoadScene(gameScene);
        }
        gruntScript.totalEnemies = 4;
    }
}
