using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainManager : MonoBehaviour
{
    #region Singlton

    public static MainManager inst;

    private void Awake()
    {
        if (inst == null)
        {
            inst = this;
        }
        else
        {
            Debug.Log("Try create another instance of game manager!");
        }

    }
    #endregion

    [SerializeField] private SceneController    sceneController;
    [SerializeField] private GameManager        gameManager;
    [SerializeField] private UIManager          uIManager;
    [SerializeField] private PlayerController   playerController;

    public SceneController  SceneController     => sceneController;
    public GameManager      GameManager         => gameManager;
    public PlayerController PlayerController    => playerController;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {

    }

    public void RestartGame()
    {

    }

}
