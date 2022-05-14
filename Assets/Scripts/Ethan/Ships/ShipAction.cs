using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class ShipAction : MonoBehaviour
{
    public bool AllowPlacement;
    private Action action;
    public enum Action
    {
        Move,
        Attack,
        Modules,
        Close,
    }

    public GameObject Pointer;
    public GameObject PointerPrefab;
    public Camera Cam;
    private Clickable[] clickables; 

    public float PointerRotSpeed = 1f;
    bool PointerInvalid;
    public LayerMask Obsticles;
    public AudioManager AManager;

    private void Start()
    {
        clickables = FindObjectsOfType<Clickable>();
    }
    public void Move()
    {
        AllowPlacement = true;
        action = Action.Move;
    }
    public void Attack()
    {
        AllowPlacement = true;
        action = Action.Attack;
    }
    public void Modules()
    {
        AllowPlacement = true;
        action = Action.Attack;
    }
    public void Close()
    {
        foreach(Clickable clickable in clickables)
        {
            if (clickable.Selected)
            {
                clickable.DeselectAll();
            }
        }
    }
    private void Update()
    {
        if(Pointer != null)
        {
            Pointer.transform.Rotate(Pointer.transform.rotation.eulerAngles.x, PointerRotSpeed, Pointer.transform.rotation.eulerAngles.z);
        }        
        var ray = Cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (AllowPlacement)
        {
            if (Physics.Raycast(ray, out hit))
            {
                if (Pointer == null)
                {
                    Pointer = Instantiate(PointerPrefab, hit.point, PointerPrefab.transform.rotation);
                }
                else
                {
                    Pointer.transform.position = hit.point;
                    PointerInvalid = Physics.CheckSphere(Pointer.transform.position, 1f, Obsticles);
                    if (Input.GetMouseButtonDown(0))
                    {
                        if (!PointerInvalid)
                        {
                            if (action == Action.Move)
                            {
                                AllowPlacement = false;
                                foreach (Clickable clickable in clickables)
                                {
                                    if (clickable.Selected)
                                    {
                                        if (clickable.SelectedObj.GetComponent<ShipData>() != null)
                                        {
                                            clickable.SelectedObj.GetComponent<NavMeshAgent>().SetDestination(new Vector3(Pointer.transform.position.x, clickable.SelectedObj.transform.position.y, Pointer.transform.position.z));
                                        }
                                    }
                                }
                                Destroy(Pointer);
                            }
                            if(action == Action.Attack)
                            {
                                AllowPlacement = false;
                            }
                        }
                        else
                        {
                            AManager.PlaySound("Invalid");
                            Debug.Log("Invalid Location");
                        }
                    }
                }                
            }
        }
    }
}
