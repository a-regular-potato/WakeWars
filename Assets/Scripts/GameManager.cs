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

   

    public List<Player> players;
    
    
    // Start is called before the first frame update
    void Start()
    {
        foreach (Player player in players)
        {
            player.StepState();
        }
    }
    
}
