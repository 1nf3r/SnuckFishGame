using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SnakeBodyColider : MonoBehaviour
{
    void OnTriggerEnter(Collider other){  //When player collides with the body lose the game
        if(other.tag == "Player"){
           SceneManager.LoadScene(2);
        }
    }
}
