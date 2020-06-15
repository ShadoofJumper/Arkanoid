using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockPotion : DestroyedBlock
{
    [SerializeField] private PotionSettings potionSettings;
    [SerializeField] private GameObject potionPrefab;

    protected override void DestroyAction()
    {
        //spawn potion
        CreatePotion();
        base.DestroyAction();
    }


    public void CreatePotion()
    {
        GameObject potionObject         = Instantiate(potionPrefab);
        Potion potion                   = potionObject.GetComponent<Potion>();
        potionObject.transform.position = transform.position;
        potion.InitializePotion(potionSettings);
    }
}
