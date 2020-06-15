using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Text scoreText;
    [SerializeField] private Text livesText;
    [SerializeField] private Text warningText;
    [SerializeField] private GameObject endPanel;
    [SerializeField] private Text speedText;
    [SerializeField] private Button speedButton;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateScore(int score)
    {
        scoreText.text = "Score: "+ score;
    }

    public void UpdateLives(int lives)
    {
        livesText.text = "Lives: " + lives;
    }

    public void UpdateWarningText(string text)
    {
        warningText.text = text;
    }

    public void UpdateSpeedText(float gameSpeed)
    {
        speedText.text = "Speed up x"+ gameSpeed;
    }

    public void SetActiveSpeedButton(bool active)
    {
        speedButton.enabled = active;
    }

    public void ShowEndPanel(bool isShowPanel)
    {
        endPanel.SetActive(isShowPanel);
    }

}
