using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Ball ball;
    [SerializeField] private Platform platform;

    private float   playgroundWidth;
    private float   currentPlatformPos;
    private bool    isBallOnPlatform;
    private Vector3 movementInput;
    private Vector3 startBallPos;
    //for freeze
    private Color startColor;
    private float startSpeed;
    //slow counter
    private int slowCounter;

    private void Start()
    {
        isBallOnPlatform    = true;
        playgroundWidth     = MainManager.inst.SceneController.SCREEN_WIDTH;
        startColor      = platform.GetComponent<MeshRenderer>().material.color;
        startSpeed      = speed;
        startBallPos    = ball.transform.localPosition;
    }

    void Update()
    {
        GetInput();
    }
    private void FixedUpdate()
    {
        MovePlatform();
    }

    private void GetInput()
    {
        // get platform position input
        movementInput       = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
        currentPlatformPos  += movementInput.x * Time.deltaTime * speed;
        currentPlatformPos  = Mathf.Clamp(currentPlatformPos, playgroundWidth / 2 * -1, playgroundWidth / 2);
        // get player shoot input

        // get info, is mouse over UI object
        if (Input.GetMouseButtonDown(0) 
            && isBallOnPlatform
            && !EventSystem.current.IsPointerOverGameObject()
            )
        {
            ShootBall();
        }
    }

    private void MovePlatform()
    {
        platform.MoveHorizontal(currentPlatformPos);
    }

    private void ShootBall()
    {
        ball.StartMove(movementInput);
        isBallOnPlatform = false;
        ball.transform.parent = null;
        ball.GetComponent<Rigidbody>().isKinematic = false;
    }

    public void ResetStage()
    {
        isBallOnPlatform                = true;
        ball.transform.parent           = transform;
        ball.transform.localPosition    = startBallPos;
        ball.GetComponent<Rigidbody>().isKinematic = true;
        ball.StopMove();
    }

    // ---------- Platform movement modify logic ----------
    public void FreezeMovement(float slowPower, float delay)
    {
        //change speed in coroutin
        StartCoroutine(SlowdownSpeed(slowPower, delay));

    }

    IEnumerator SlowdownSpeed(float slowPower, float delay)
    {
        TurnFreezeOn(slowPower);
        yield return new WaitForSeconds(delay);
        TurnFreezeOff();
    }

    private void TurnFreezeOn(float slowPower)
    {
        slowCounter += 1;
        platform.GetComponent<MeshRenderer>().material.color = Color.blue;
        speed = startSpeed * slowPower;
    }

    private void TurnFreezeOff()
    {
        slowCounter -= 1;
        if (slowCounter == 0)
        {
            speed = startSpeed;
            platform.GetComponent<MeshRenderer>().material.color = startColor;
        }
    }
}
