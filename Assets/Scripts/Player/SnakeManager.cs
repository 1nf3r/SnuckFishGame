using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeManager : MonoBehaviour
{

    [SerializeField]
    float distanceBetween = .5f; //Distance between snakeBody and snakeHead

    [SerializeField]
    float speed = 5; //Player speed

    [SerializeField]
    List<GameObject> bodyParts = new List<GameObject>();  //Prefab snakeBody
    public static List<GameObject> snakeBody = new List<GameObject>();  //Prefab snakeHead
    public Vector3 positionHead;
    public Vector3 PositionHead {
        get => positionHead;
        set => positionHead = value;
    } 

    float countUp = 0;
    //Initialize the player movement and direction
    float horizontal = -1;
    float vertical = 0;


    // Start is called before the first frame update
    void Start()
    {
        CreateBodyParts();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        ManageSnakeBody();
        SnakeMovement();
        UpdatePosition();
        positionHead = snakeBody[0].transform.position;
        // ChangeSnakeRotation();
    }


    void SnakeMovement(){
        float space = speed * Time.deltaTime;
        Vector3 dir = new Vector3( horizontal, 0, vertical); //Snake position
        snakeBody[0].transform.Translate(dir.normalized * space ); //Set the position to the snake
        snakeBody[0].GetComponent<Rigidbody>().velocity = dir * 2.5f; //Set a constant velocity to snake
        snakeBody[0].GetComponent<Animator>().SetBool("Run", true); //Activate the player animation

        if(snakeBody.Count > 1){
            for(int i = 1; i < snakeBody.Count; i++){
                //Update the position of each snakeBody
                MarkerManager markM = snakeBody[i - 1].GetComponent<MarkerManager>();
                snakeBody[i].transform.position = markM.markerList[0].position;
                snakeBody[i].transform.rotation = markM.markerList[0].rotation;
                snakeBody[i].GetComponent<Animator>().SetBool("Run", true); //Activate the player animation
                markM.markerList.RemoveAt(0);
            }
        }
    }

    void CreateBodyParts(){
        //Head Component
        if(snakeBody.Count == 0){
            //Instantiate snakeHead
            GameObject temp1 = Instantiate(bodyParts[0], transform.position, transform.rotation, transform);
            if(!temp1.GetComponent<MarkerManager>()){
                temp1.AddComponent<MarkerManager>();
            }
            if(!temp1.GetComponent<Rigidbody>()){
                temp1.AddComponent<Rigidbody>();
            }
            if(!temp1.GetComponent<Animator>()){
                temp1.AddComponent<Animator>();
            }
            //Add snakeHead to nakeList and remove the gameObject
            snakeBody.Add(temp1);
            bodyParts.RemoveAt(0);
        }
        //Body Component
        MarkerManager markM = snakeBody[snakeBody.Count - 1].GetComponent<MarkerManager>();
        if(countUp == 0){
            markM.ClearMarkerList();
        }
        countUp += Time.deltaTime;
        //When time its greater or equal than distance between game objects it creates another body part
        if(countUp >= distanceBetween){ 
        GameObject temp = Instantiate(bodyParts[0], markM.markerList[0].position,markM.markerList[0].rotation, transform);

        if(!temp.GetComponent<MarkerManager>()){
            temp.AddComponent<MarkerManager>();
        }
        if(!temp.GetComponent<Animator>()){
            temp.AddComponent<Animator>();
        }
        
        snakeBody.Add(temp);
        bodyParts.RemoveAt(0);
        //Clean the positions list
        temp.GetComponent<MarkerManager>().ClearMarkerList();
        //Reset Count up when snakebody is added
        countUp = 0;
        }
    }

    //Update player position only run if player change the direction
    void UpdatePosition(){
        if(Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0){
            horizontal = - (Input.GetAxis("Horizontal"));
            vertical = - (Input.GetAxis("Vertical"));
        }
    }

    //Manage body when a snakeBody its destroyed tbe other parts will reassemble
    void ManageSnakeBody(){
        if(bodyParts.Count > 0){
            CreateBodyParts();
        }
        for(int i = 0; i < snakeBody.Count; i++){
            if(snakeBody[i] == null) {
                snakeBody.RemoveAt(i);
                i = i - 1;
            }
        }
        //Its destroys if there aren't a snake
        if(snakeBody.Count == 0){
            Destroy(this);
        }
    }

    //Add snakebody each time the player collides with a fish
    public void AddBodyParts(GameObject obj){
        bodyParts.Add(obj);
    }
}
 