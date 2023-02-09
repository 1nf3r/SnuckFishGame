using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MapCollider : MonoBehaviour
{
    void OnTriggerEnter(Collider other){  //When player collides with the fish decrease the number to create another fish
        if(other.tag == "Player"){
            SceneManager.LoadScene(2);
        }
    }
}
