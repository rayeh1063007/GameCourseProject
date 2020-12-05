using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class EndText : MonoBehaviour
{
    public GameManager gameManager;
    public Text Titles;
    //文件流,用于读取文本
    StreamReader sr;
    //文本中的字幕的行数
    int lineCount = 0;
    public Button EndButton;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Display());
    }
    IEnumerator Display()
    {
        sr = new StreamReader(Application.dataPath + "/Endtext.txt");
        StreamReader srLine = new StreamReader(Application.dataPath + "/Endtext.txt");
        while (srLine.ReadLine() != null)
        {
            lineCount++;
        }
        //关闭并释放流
        srLine.Close();
        srLine.Dispose();
        for (int i = 0; i < lineCount; i++)
        {
            string tempText = sr.ReadLine();
            Titles.text = tempText.Split('$')[0];
            Debug.Log(Titles.text);
            //也就是
            float tempTime;
            //将文中的那个$3中的3读取出来
            if (float.TryParse(tempText.Split('$')[1], out tempTime))
            {
                //协程等待
                yield return new WaitForSeconds(tempTime);
            }
        }
        EndButton.gameObject.SetActive(true);
        //关闭并释放流
        sr.Close();
        sr.Dispose();
    }
    // Update is called once per frame
    void Update()
    {

    }
}
