using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBodyHorizontal : MonoBehaviour
{
    [SerializeField] private Rigidbody targetRg;
    [Range(0.0f, 5.0f)]
    [SerializeField] private float  moveRange;
    [SerializeField] private float  speed    = 1.0f;
    [SerializeField] private bool   startMoveRight = true;
    private int moveK = 1;
    private Vector3 targetPosition;

    void Start()
    {
        moveK = startMoveRight ? 1 : -1;
        targetPosition = targetRg.position + Vector3.right * moveRange * moveK;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        MoveBody();
    }

    private void MoveBody()
    {
        Vector3 destination = targetRg.position + Vector3.right * moveK * speed * Time.deltaTime;
        targetRg.MovePosition(destination);
        if (Vector3.Distance(targetRg.position, targetPosition) < 0.1f)
        {
            moveK *= -1;
            targetPosition = targetRg.position + Vector3.right * moveRange * 2 * moveK;
        }
    }
}
