using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventTrigger : MonoBehaviour
{
    public UnityEvent EnterEvent = new UnityEvent();
    public UnityEvent StayEvent = new UnityEvent();
    public UnityEvent ExitEvent = new UnityEvent();

    public float enterDelay,exitDelay;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        StartCoroutine("EnterIenumerator", enterDelay);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        StayEvent.Invoke();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        StartCoroutine("ExitIenumerator", exitDelay);
    }

    IEnumerator EnterIenumerator(float delay) {

        yield return new WaitForSeconds(delay);
        EnterEvent.Invoke();
    }

    IEnumerator ExitIenumerator(float delay)
    {
        yield return new WaitForSeconds(delay);
        ExitEvent.Invoke();
    }
}
