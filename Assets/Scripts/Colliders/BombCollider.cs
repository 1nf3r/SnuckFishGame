using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BombCollider : MonoBehaviour
{
   void OnTriggerEnter(Collider other){
        if(other.tag == "Player"){
           SceneManager.LoadScene(2);
        }
    }
}
