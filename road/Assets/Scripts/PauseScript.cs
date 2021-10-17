using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Manages pause state.
/// </summary>
public class PauseScript : MonoBehaviour
{
    [SerializeField] private float timer;
    
    [SerializeField]  private bool isPaused;
    
    [SerializeField]  private bool guiPause;

    public void Update()
    {
        Time.timeScale = timer;
        if (Input.GetKeyDown(KeyCode.Escape) && !isPaused)
        {
            isPaused = true;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && isPaused)
        {
            isPaused = false;
        }
        if (isPaused == true)
        {
            timer = 0;
            guiPause = true;

        }
        else if (isPaused == false)
        {
            timer = 1f;
            guiPause = false;
        }
    }

    public void OnGUI()
    {
        Cursor.visible = true;
        if (!guiPause)
        {
            if (GUI.Button(new Rect((float)(Screen.width) - 100f, 0, 100f, 40f), "Pause"))
            {
                isPaused = true;
                timer = 1;
            }
        }
        if (guiPause == true)
        {
        //    Cursor.visible = true;// включаем отображение курсора
            if (GUI.Button(new Rect((float)(Screen.width / 2) - 70f, (float)(Screen.height / 2) - 20f, 140f, 40f), "Continue"))
            {
                isPaused = false;
                timer = 0;
            }
        }
    }
}
