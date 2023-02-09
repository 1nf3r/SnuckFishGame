using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishSpawn : MonoBehaviour
{
    
    [SerializeField]
    private GameObject fish;
    private GameObject realFish;

    int xPos;
    int zPos;
    private int fishCount = 0;
    public int FishCount {
        get=> fishCount;
        set=> fishCount = value;
    }

    // Start is called before the first frame update
    void Start()
    {
        realFish = Instantiate(fish, new Vector3(xPos, 1.3f, zPos), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
       if(fishCount <= 0){          //When the player collides with fish and decrease the value this function will create another fish
        StartCoroutine(FishGroup());
       }
    }
    
     IEnumerator FishGroup() {  //Spawn a fish randomly 
        if (fishCount <= 0) { //If fish exist, it destroy before create another one
            if(fish != null){
                Destroy(fish);
            }
            xPos = Random.Range(-44,1);
            zPos = Random.Range(30,47);
            Vector3 randomPosition = new Vector3(xPos, 1.3f, zPos);
            realFish.transform.position = randomPosition;
            fishCount++;
            yield return new WaitForSeconds(1f);
        }
    }
}
