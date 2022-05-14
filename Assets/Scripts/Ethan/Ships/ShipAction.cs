using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class ShipAction : MonoBehaviour
{
    private float LerpValue;
    public float LerpSpeed = 0.001f;
    private Quaternion NewRot;

    public bool AllowPlacement;
    private bool DisablePlacement;
    private bool Attacking;
    private Module ChoseMod;
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
        var ray = Cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (AllowPlacement)
        {
            if (Physics.Raycast(ray, out hit))
            {
                if (!DisablePlacement)
                {
                    if(Pointer == null)
                    {
                        Pointer = Instantiate(PointerPrefab);
                    }
                    Pointer.transform.position = hit.point;
                    PointerInvalid = Physics.CheckSphere(Pointer.transform.position, 1f, Obsticles);
                }

                if(action == Action.Move)
                {
                    if (Input.GetMouseButtonDown(0))
                    {
                        if (!PointerInvalid)
                        {
                            AllowPlacement = false;
                            foreach(Clickable clickable in clickables)
                            {
                                if (clickable.Selected)
                                {
                                    clickable.SelectedObj.ship.agent.SetDestination(new Vector3(hit.point.x, clickable.SelectedObj.transform.position.y, hit.point.z));
                                }
                            }
                            Destroy(Pointer);
                        }
                        else
                        {
                            AManager.PlaySound("Invalid");
                        }
                    }
                }
                if (action == Action.Attack)
                {
                    if (!Attacking)
                    {
                        if (Input.GetMouseButtonDown(0))
                        {
                            foreach (Clickable clickable in clickables)
                            {
                                if (clickable.Selected)
                                {
                                    foreach(Module module in clickable.ship.attatchedModules)
                                    {                                        
                                        if(module.GetComponent<WeaponModule>() != null)
                                        {
                                            ChoseMod = hit.transform.gameObject.GetComponent<WeaponModule>();
                                            Attacking = true;
                                            LerpValue = 0f;
                                        }
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        if (Input.GetMouseButtonDown(0))
                        {
                            if (!PointerInvalid)
                            {
                                DisablePlacement = true;
                            }
                        }
                        if (DisablePlacement)
                        {
                            Vector3 relativePos = ChoseMod.transform.position - Pointer.transform.position;
                            NewRot = Quaternion.LookRotation(relativePos, Vector3.up);
                            NewRot = Quaternion.Euler(ChoseMod.transform.rotation.eulerAngles.x, NewRot.eulerAngles.y, ChoseMod.transform.rotation.eulerAngles.z);
                            LerpValue += LerpSpeed;
                            ChoseMod.transform.rotation = Quaternion.Slerp(ChoseMod.transform.rotation, NewRot, LerpValue);
                            if(LerpValue >= 1)
                            {
                                DisablePlacement = false;
                                AllowPlacement = false;
                                Attacking = false;
                                StartCoroutine(Explode());
                                ChoseMod.GetComponent<Animator>().Play("Shoot01");
                                ChoseMod.GetComponent<WeaponModule>().MuzzleFlash.Play();
                                AManager.PlaySound("shot");
                            }
                        }
                    }
                }
            }
        }
    }

    IEnumerator Explode()
    {
        yield return new WaitForSeconds(3);
        if (!PointerInvalid)
        {
            AManager.PlaySound("Miss");
        }
        else
        {
            AManager.PlaySound("Hit01");
        }
        Destroy(Pointer);
    }
}
