using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyedBlock : Block
{
    [SerializeField] private int health = 1;

    public void GetDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
            Destroy();
    }

    private void Destroy()
    {

        DestroyAction();
    }

    protected virtual void DestroyAction()
    {
        //show animation
        Destroy(gameObject);
    }

}
