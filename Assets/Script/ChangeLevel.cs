using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
using UnityEngine.Events;

public class ChangeLevel : MonoBehaviour
{
    public GameObject mask;
    public UnityEvent ChangeEvent = new UnityEvent();
    public string levelName;
    public float delayChangeTime = 2f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SwitchLevel() {
        
        SceneManager.LoadScene(levelName);
    }

    private void OnTriggerStay2D(Collider2D co)
    {
        if (co.gameObject.tag == "Player") {
            if (Input.GetButtonDown("Enter")) {
                StartCoroutine("EnterIenumerator", delayChangeTime);
            }
        }   
    }
    IEnumerator EnterIenumerator(float delay)
    {
        ChangeEvent.Invoke();
        yield return new WaitForSeconds(delay);
        SwitchLevel();
    }
}
