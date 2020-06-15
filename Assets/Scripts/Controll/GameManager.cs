using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private int lives;
    [SerializeField] private int coins;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddCoin(int amount)
    {
        coins += amount;
    }

    public void AddLives(int amount)
    {
        lives += amount;
    }
}
