using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishCollider : MonoBehaviour
{
    FishSpawn fishSp;
    public AudioSource coins;

    void OnTriggerEnter(Collider other){  //When player collides with the fish decrease the number to create another fish
        fishSp = GameObject.Find("FishSpawner").GetComponent<FishSpawn>();
        if(other.tag == "Player"){
            if(fishSp.FishCount >= 0){
                fishSp.FishCount--;
                coins.Play();
            }
            
            ScoreManager.SharedInstance.Amount += 1;
            Debug.Log(ScoreManager.SharedInstance.Amount);
        }
    }
}
