using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LevelStartLoading : MonoBehaviour
{
    public bool canMove = true;
    public UnityEvent StartEvent = new UnityEvent();

    // Start is called before the first frame update
    void Start()
    {
        StartEvent.Invoke();
        GameObject.FindWithTag("Player").SendMessage("MoveOrNot", canMove);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
