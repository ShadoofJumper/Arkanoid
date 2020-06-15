using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyedBlock : Block
{
    [SerializeField] private int    health = 1;
    [SerializeField] Animator       blockAnimator;
    [SerializeField] BoxCollider    blockCollider;


    public void GetDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Destroy();
        }
        else if(blockAnimator!=null)
        {
            blockAnimator.SetTrigger("Hit");
        }
    }

    private void Destroy()
    {
        MainManager.inst.GameManager.CurrentBlockLive--;
        MainManager.inst.GameManager.AddCoin(1);
        if (blockAnimator != null)
        {
            blockAnimator.SetTrigger("Die");
            blockCollider.enabled = false;
            StartCoroutine(DestroyWithDelay(0.3f));
        }
        else
        {
            DestroyAction();
        }
    }

    IEnumerator DestroyWithDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        DestroyAction();
    }

    protected virtual void DestroyAction()
    {
        //show animation
        Destroy(gameObject);
    }

}
