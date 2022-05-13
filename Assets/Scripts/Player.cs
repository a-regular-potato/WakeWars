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
    
    // grid manager
    public GridManager manager;
    
    // ui components
    public TMP_Text fuelIndicator;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(testFuelChange());
        fuelIndicator.text = $"Fuel: {fuel}/{maxFuel}";
        
        if (manager != null)
            manager.onGridSelect += TriggerPlayerMove;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void TriggerPlayerMove(Vector3 coords)
    {
        this.fleet[0].SetDestination(coords);
    }

    IEnumerator testFuelChange()
    {
        yield return new WaitForSeconds(5f);
        ChangeFuel(-3);
    }

    void ChangeFuel(int fuelAmount)
    {
        fuel = Mathf.Clamp(fuel + fuelAmount, 0, maxFuel);
        fuelIndicator.text = $"Fuel: {fuel}/{maxFuel}";
    }
}
