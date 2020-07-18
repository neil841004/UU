using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    static GameManager instance;

    public UnityEvent StartEvent = new UnityEvent();

    // Start is called before the first frame update

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        else if (this != instance) {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        Debug.Log("B");
        StartEvent.Invoke();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
