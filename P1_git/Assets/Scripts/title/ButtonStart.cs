using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class ButtonStart : MonoBehaviour
{
    //private UnityEvent startButtonPress;
    // Start is called before the first frame update
    void Start()
    {
        //startButtonPress.AddListener(StartButt);
    }
    
    public void StartButt()
    {
        SceneManager.LoadScene(1);
    }
}
