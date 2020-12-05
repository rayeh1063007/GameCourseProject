using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Start_Click()
    {
        SceneManager.LoadScene(1);
    }
    public void Exit_Click()
    {
        Application.Quit();
    }
}
