using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potion : MonoBehaviour
{
    private float fallSpeed;
    private float freezePower;
    private float freezeDelay;
    private int bonusCoins;
    private int bonusLives;
    private PlayerController playerController;

    private void Start()
    {
        playerController = MainManager.inst.PlayerController;
    }

    public void InitializePotion(PotionSettings potionSettings)
    {
        GetComponent<MeshRenderer>().material.color = potionSettings.Color;
        this.freezePower    = potionSettings.FreezePower;
        this.freezeDelay    = potionSettings.FreezeDelay;
        this.bonusCoins     = potionSettings.BonusCoins;
        this.bonusLives     = potionSettings.BonusLives;
        this.fallSpeed      = potionSettings.FallSpeed;
    }

    private void Update()
    {
        Fall();
    }


    private void Fall()
    {
        transform.position += Vector3.down * fallSpeed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            AddBonus();
            // do stuff
            if (freezePower != 0)
                FrozePlatform();
            DestroyPotion();
        }
    }

    private void AddBonus()
    {
        Debug.Log($"Add bonus: {bonusCoins}, {bonusLives}");
        if(bonusCoins!=0)
            MainManager.inst.GameManager.AddCoin(bonusCoins);
        if(bonusLives != 0)
            MainManager.inst.GameManager.AddLives(bonusLives);
    }

    private void FrozePlatform()
    {
        playerController.FreezeMovement(freezePower, 1.0f);
    }

    private void DestroyPotion()
    {
        Destroy(gameObject);
    }

}
