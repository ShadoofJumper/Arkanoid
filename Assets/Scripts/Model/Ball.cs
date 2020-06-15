using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Ball : MonoBehaviour
{
    [SerializeField] private float  speed;
    [SerializeField] private int    damage;
    [SerializeField] private GameObject particleTrail;

    private Vector3         currentVelocity;
    private bool            isMove;
    private Material        material;
    private SphereCollider  collider;
    //save ball material colors
    private Color standartColor;
    private Color ghostColor;
    private float startSpeed;

    private void Start()
    {
        collider    = GetComponent<SphereCollider>();
        material    = GetComponent<MeshRenderer>().material;
        startSpeed  = speed;
        standartColor   = material.color;
        ghostColor      = standartColor;
        ghostColor.a    = 0.3f;
    }
    private void FixedUpdate()
    {
        Move();
    }

    // ------------ move logic ------------
    public void StartMove(Vector3 startVelocity)
    {
        currentVelocity = Vector3.up + startVelocity;
        isMove = true;
        particleTrail.SetActive(true);
    }

    public void StopMove()
    {
        currentVelocity = Vector3.zero;
        isMove = false;
        particleTrail.SetActive(false);
    }

    private void Move()
    {
        if (isMove)
        {
            transform.position += currentVelocity * speed * Time.deltaTime;
        }
    }

    // ------------ collide logic ----------
    private void OnCollisionEnter(Collision collision)
    {
        if (CheckFailZone(collision))
            MainManager.inst.GameManager.MissBall();

        //change ball move direction
        ChangeDirection(collision);
        //try hit block
        Block block = collision.gameObject.GetComponent<Block>();
        if (block != null)
        {
            HitBlock(block);
        }
    }
    private bool CheckFailZone(Collision collision)
    {
        return collision.collider.tag == "FailZone";
    }


    private void HitBlock(Block block)
    {
        DestroyedBlock destBlock = block as DestroyedBlock;
        if (destBlock != null)
        { 
            destBlock.GetDamage(damage);
        }
    }

    private void ChangeDirection(Collision collision)
    {
        Vector3 hitColliderNormal = collision.contacts[0].normal;
        Vector3 collideBodyVelocity = Vector3.zero;
        if (collision.rigidbody != null)
            collideBodyVelocity = collision.rigidbody.velocity;
        //get reflected velocity
        currentVelocity = Vector3.Reflect(currentVelocity, hitColliderNormal);
        //add half of collide body velocity to ball
        currentVelocity += collideBodyVelocity * 0.25f;
        currentVelocity = currentVelocity.normalized;
    }

    // ------------ Ghost logic -----------

    public void EnableGhost(float delay)
    {
        StartCoroutine(BallGhostProcess(delay));
    }

    IEnumerator BallGhostProcess(float delay)
    {
        SetGhostActive(true);
        yield return new WaitForSeconds(delay);
        SetGhostActive(false);
    }

    public void SetGhostActive(bool turnOn)
    {
        if (turnOn)
        {
            speed               = startSpeed * 0.4f;
            material.color      = ghostColor;
        }
        else
        {
            speed               = startSpeed;
            material.color      = standartColor;
        }
    }

}
