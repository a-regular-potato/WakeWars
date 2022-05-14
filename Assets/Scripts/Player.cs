using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public int fuel, maxFuel;
    public List<Ship> fleet;

    private Ship _shipSelection;
    private Module _moduleSelection;
    
    public enum TurnState
    {
        Waiting,
        Running,
        Complete
    };

    private TurnState _turnState;
    
    // grid manager
    public GridManager manager;
    
    // ui components
    public TMP_Text fuelIndicator;

    private NotificationManager _notifyManager;
    
    // Start is called before the first frame update
    void Start()
    {
        _notifyManager = FindObjectOfType<NotificationManager>();
        
        // StartCoroutine(testFuelChange());
        fuelIndicator.text = $"Fuel: {fuel}/{maxFuel}";
        
        // PLAYER SELECTS TO MOVE
            // manager.onGridSelect += TriggerPlayerMove;
        // PLAYER SELECTS TO ATTACK
            // manager.onGridSelect += TriggerplayerAttack;

            
        if (manager != null)
            // manager.onGridSelect += TriggerPlayerAttack;
            manager.onGridSelect += TriggerPlayerMove;
        
        _notifyManager.Enqueue("It's Player 1's turn");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void TriggerPlayerMove(Vector3 coords)
    {
        this.fleet[0].SetDestination(coords);
    }

    void TriggerPlayerAttack(Vector3 coords)
    {
        _notifyManager.Enqueue("That is not a valid target.");
    }
    //
    // IEnumerator testFuelChange()
    // {
    //     yield return new WaitForSeconds(5f);
    //     ChangeFuel(-3);
    // }

    void ChangeFuel(int fuelAmount)
    {
        fuel = Mathf.Clamp(fuel + fuelAmount, 0, maxFuel);
        fuelIndicator.text = $"Fuel: {fuel}/{maxFuel}";
    }

    public void StepState()
    {
        _turnState++;
        if (this._turnState > TurnState.Complete)
        {
            _turnState = TurnState.Waiting;
        }
    }
}
