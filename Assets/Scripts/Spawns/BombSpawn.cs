using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombSpawn : MonoBehaviour
{
    [SerializeField]
    private GameObject bomb;

    private GameObject spawnBomb;
    private GameObject spawnBomb1;
    int xPos;
    int zPos;
    int xPos1;
    int zPos1;
    int bombCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        xPos = Random.Range(-44,1);
        zPos = Random.Range(30,47);
        spawnBomb = Instantiate(bomb, new Vector3(xPos, 1.3f, zPos), Quaternion.identity);
        spawnBomb1 = Instantiate(bomb, new Vector3(xPos, 1.3f, zPos), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
       if(bombCount <= 0){
        StartCoroutine(bombGroup());
        bombCount++;
       }
    }
    
     IEnumerator bombGroup() {
        if (bombCount <= 0) {
            yield return new WaitForSeconds(3f);
            xPos = Random.Range(-44,1);
            zPos = Random.Range(30,47);
            xPos1 = Random.Range(-44,1);
            zPos1 = Random.Range(30,47);
            Vector3 randomPos1 = new Vector3(xPos, 1.3f, zPos);
            Vector3 randomPos2 = new Vector3(xPos1, 1.3f, zPos1);
            spawnBomb.transform.position = randomPos1;
            spawnBomb1.transform.position = randomPos2;
            bombCount--;
            
        }
    }
}
