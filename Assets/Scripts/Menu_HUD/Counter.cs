using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Counter : MonoBehaviour
{
   [SerializeField]
   public GameObject textSecondsDisplay;
   public int seconds = 0;
   public bool takingAway = false;

   [SerializeField]
   public GameObject textMultiplierDisplay;


    void Start(){
        textSecondsDisplay.GetComponent<TextMeshProUGUI>().text =  "" + seconds;
        //Initialize amount with value 2
        textMultiplierDisplay.GetComponent<TextMeshProUGUI>().text =  "X" + (ScoreManager.SharedInstance.Amount = 2);  
    }

    void Update(){
        if(takingAway == false || seconds < 0){
            StartCoroutine(TimerTake());
            //When amount value change on the other scripts it will update this counter
            textMultiplierDisplay.GetComponent<TextMeshProUGUI>().text =  "X" + ScoreManager.SharedInstance.Amount; 
        }
        if(ScoreManager.SharedInstance.Amount == 20){
            SceneManager.LoadScene(5);
        }
        
    }

    //Coroutine to count the seconds
   IEnumerator TimerTake(){
       takingAway = true;
       yield return new WaitForSeconds(1);
       seconds += 1;
       textSecondsDisplay.GetComponent<TextMeshProUGUI>().text = "Sec:" +  seconds;
       takingAway = false;
   }
    
}