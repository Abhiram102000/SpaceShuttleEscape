using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text displayText = null;
    public float time;
    
    public void DisplayTime(float timeToDisplay)
    {
        if (displayText != null)
        {
            timeToDisplay += Time.deltaTime;

            float minutes = Mathf.FloorToInt(timeToDisplay / 60);
            float seconds = Mathf.FloorToInt(timeToDisplay % 60);

            displayText.text = "TIME: " + string.Format("{0:00}:{1:00}", minutes, seconds);
        }
    }

    public void GameOver()
    {
        if (GameManager.instance != null)
        {
            GameManager.instance.GameOver();
        }
    }

    private void Update()
    {       
            if (time > 0)
            {
                time -= Time.deltaTime;
                DisplayTime(time);
            }
            else
            {
                Destroy(GameObject.FindGameObjectWithTag("Player"));
                GameOver();
            }
       
        GameManager.UpdateUIElements();
    }
}
