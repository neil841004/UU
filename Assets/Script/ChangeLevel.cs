using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeLevel : MonoBehaviour
{
    public string levelName;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SwitchLevel() {
        SceneManager.LoadScene(levelName);
    }

    private void OnTriggerStay2D(Collider2D co)
    {
        if (co.gameObject.tag == "Player") {
            SwitchLevel();
        }   
    }
}
