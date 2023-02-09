using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
  public static ScoreManager SharedInstance;

    [SerializeField]
    [Tooltip("Quantitat de punts de la partida actual")]
    private int amount;
    public int Amount
    {
        get => amount;
        set => amount = value;
    }

    private void Awake()
    {
        if(SharedInstance == null)
        {
            SharedInstance = this;
        }
        else
        {
            Debug.LogWarning("ScoreManager duplicat, ha de ser destruit");
            Destroy(gameObject);
        }
    }
}
