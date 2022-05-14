using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ShipData : MonoBehaviour
{
    public Module[] attatchedModules;

    public string ShipName;

    private string[] Title = {"ISS", "USS", "LR", "HMS", "CSS"};
    private string[] Name = { "ARTIMAS", "Renegade", "Curzon", "Supreme", "Disdain", "Disgust", "Flying Fish", "Rapscallion", "Valhalla" , "Subtle", "Enterprise"};
    public ShipType ShipType_;
    public enum ShipType
    {
        SCOUT_CARGO,
        SCOUT_CREW,
        DESTROYER,
        CRUISER,
        SUBMARINE,
        BARGE,
        BATTLESHIP,
        CARRIER,
    }
    public Renderer HighlightRend;

    public Animator[] animators;
    public NavMeshAgent agent;

    public Color SelectedColour;
    public Color DeSelectedColour;

    private void Awake()
    {
        ShipName = Title[Random.Range(0, Title.Length - 1)] + " " + Name[Random.Range(0, Name.Length - 1)];
    }

    [HideInInspector]
    public bool Moving()
    {
        if(agent.velocity == Vector3.zero)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    private void Update()
    {
        if (Moving())
        {
            foreach (Animator animator in animators)
            {
                animator.SetBool("Spinning", true);
            }
        }
        else
        {
            foreach (Animator animator in animators)
            {
                animator.SetBool("Spinning", false);
            }
        }
    }
}
