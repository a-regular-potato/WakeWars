using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NotificationManager : MonoBehaviour
{
    public GameObject notifyUI;
    private readonly Queue<string> _queue = new();

    private TMP_Text _notifyTextOut;
    private Animator _notifyAnim;
    private static readonly int Notify1 = Animator.StringToHash("Notify");
    private bool _showing = false;

    // Start is called before the first frame update
    void Start()
    {
        _notifyTextOut = notifyUI.GetComponent<TMP_Text>();
        _notifyAnim = notifyUI.GetComponent<Animator>();
        
        InvokeRepeating(nameof(Notify), 0f, .5f);
    }

    void Notify()
    {
        if (_showing) return;
        
        if (_queue.Count > 0)
        {
            _showing = true;
            
            _notifyTextOut.text = _queue.Dequeue();
            _notifyAnim.SetTrigger(Notify1);

            StartCoroutine(StopShowing());
        }
    }

    public void Enqueue(string notification)
    {
        this._queue.Enqueue(notification);
    }

    IEnumerator StopShowing()
    {
        yield return new WaitForSeconds(3f);
        _showing = false;
    }
}
