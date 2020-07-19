using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
using UnityEngine.Events;

public class ChangeLevel : MonoBehaviour
{
    //public DOTweenAnimation mask;
    //public UnityEvent ChangeEvent = new UnityEvent();
    //public UnityEvent FinishEvent = new UnityEvent();
    public string levelName;
    public float delayChangeTime = 2f;
    public GameObject tip;

    private bool inTrigger = false;
    //public Vector3 positionV3;
    //public GameObject camColse, camOpen;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (inTrigger) {
            if (Input.GetButtonDown("Enter"))
            {
                SwitchLevel();
            }
        }
    }

    public void SwitchLevel() {
        StartCoroutine("EnterIenumerator", delayChangeTime);
        
    }

    private void OnTriggerEnter2D(Collider2D co)
    {
        tip.SetActive(true);
        if (co.gameObject.tag == "Player")
        {
            inTrigger = true;
        }
    }

    private void OnTriggerExit2D(Collider2D co)
    {
        tip.SetActive(false);
        if (co.gameObject.tag == "Player")
        {
            inTrigger = false;
        }
    }

    IEnumerator EnterIenumerator(float delay)
    {
        GameObject.FindWithTag("maskAni").GetComponent<DOTweenAnimation>().DOPlayBackwards();
        GameObject.FindWithTag("Player").SendMessage("MoveOrNot", false);
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(levelName);
    }

    //public void ChangePosition() {
    //    GameObject.FindWithTag("Player").transform.position = positionV3;
    //    camColse.SetActive(false);
    //    camOpen.SetActive(true);
    //}
}
