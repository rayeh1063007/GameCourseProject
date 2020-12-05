using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject Player_Canves;
    public GameObject Movie_Canves;
    public GameObject Pasue_Canves;
    public GameObject End_Canves;
    public bool pasue = false;
    public bool Game_Start=false;
    public int AnemyNum = 20;
    public Text AnemyNumText;
    // Start is called before the first frame update
    void Start()
    {
        Game_Start = false;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Confined;
        AnemyNumText.text = "敵人剩餘 : " + AnemyNum;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(Game_Start)
            {
                if (!pasue)
                {
                    Cursor.visible = true;
                    Pasue_Canves.SetActive(true);
                    Player_Canves.SetActive(false);
                    Time.timeScale = 0;
                    pasue = true;
                }
                else
                {
                    Cursor.visible = false;
                    Pasue_Canves.SetActive(false);
                    Player_Canves.SetActive(true);
                    Time.timeScale = 1;
                    pasue = false;
                }
            }
            else
            {
                if (!pasue)
                {
                    Cursor.visible = true;
                    Pasue_Canves.SetActive(true);
                    Time.timeScale = 0;
                    pasue = true;
                }
                else
                {
                    Cursor.visible = false;
                    Pasue_Canves.SetActive(false);
                    Time.timeScale = 1;
                    pasue = false;
                }
            }
        }
        if(AnemyNum<=0 || Input.GetKeyDown(KeyCode.P))
        {
            Cursor.visible = true;
            //Game_Start = false;
            Pasue_Canves.SetActive(false);
            Movie_Canves.SetActive(false);
            Player_Canves.SetActive(false);
            End_Canves.SetActive(true);
        }
    }
    public void Start_Game()
    {
        print("Game STart");
        Movie_Canves.SetActive(false);
        Player_Canves.SetActive(true);
        Game_Start = true;
    }
    public void Anemy_Kill()
    {
        AnemyNum -= 1;
        AnemyNumText.text = "敵人剩餘 : " + AnemyNum;
    }
    public void Resume_Click()
    {
        Cursor.visible = false;
        if (Game_Start)
        {
            Pasue_Canves.SetActive(false);
            Player_Canves.SetActive(true);
            Time.timeScale = 1;
            pasue = false;
        }
        else
        {
            Pasue_Canves.SetActive(false);
            Time.timeScale = 1;
            pasue = false;
        }
    }
    public void Back_Click()
    {
        SceneManager.LoadScene(0);
    }
    public void Exit_Click()
    {
        Application.Quit();
    }
    public void End_Click()
    {
        Application.Quit();
    }
}
