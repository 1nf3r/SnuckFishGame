using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddBodyDynamic : MonoBehaviour
{
    [SerializeField] 
    GameObject bodyPart;
    SnakeManager snakeM;
    int snakeLength;



    // Start is called before the first frame update
    void Start()
    {
        snakeM = GetComponent<SnakeManager>();
        snakeLength = 2;
    }

    // Update is called once per frame
    void Update()
    {
        if(snakeLength < ScoreManager.SharedInstance.Amount && snakeLength >= 2 ){
            snakeM.AddBodyParts(bodyPart);
            snakeLength++;
        }
    }
}
