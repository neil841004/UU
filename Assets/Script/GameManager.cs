using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public UnityEvent StartEvent = new UnityEvent();

    // Start is called before the first frame update
    void Start()
    {
        StartEvent.Invoke();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
