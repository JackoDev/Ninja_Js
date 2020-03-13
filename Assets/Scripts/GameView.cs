using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;   

public class GameView : MonoBehaviour
{
    public Text scoreText, orbsText, levelName;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.sharedInstance.currentGameState == GameState.inGame)
        {
            int orbs = GameManager.sharedInstance.collectedObjects;
            float score = 0;
            string nameLevel = "Level 0";

            orbsText.text = orbs.ToString();
            scoreText.text = "Score: " + score.ToString("f1");
            levelName.text = nameLevel;
        }
    }
}
