using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public enum GameState {
        Starting,
        Running,
        Completed
    }

    public enum TurnState
    {
        Waiting,
        Executing,
        Complete
    };
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }
}
