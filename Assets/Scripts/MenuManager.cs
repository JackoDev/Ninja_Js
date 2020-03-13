using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public static MenuManager sharedInstance;
    public Canvas menuCanvas, playCanvas, gameOverCanvas ;

    private void Awake()
    {
        if (sharedInstance == null)
        {
            sharedInstance = this;
        }
    }

    public void ShowMainMenu()
    {
        menuCanvas.enabled = true;
    }
    public void ShowPlayMenu()
    {
        playCanvas.enabled = true;
    }
    public void ShowGameOverMenu()
    {
        gameOverCanvas.enabled = true;
    }
    public void HideMainMenu()
    {
        menuCanvas.enabled = false;
    }
    public void HidePlayMenu()
    {
        playCanvas.enabled = false;
    }

    public void HideGameOverMenu()
    {
        gameOverCanvas.enabled = false;
    }
    public void ExitGame()
    {
    #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
    #else
        Application.Quit();
    #endif
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
