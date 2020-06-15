using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Platform : MonoBehaviour
{
    private Vector3 startPos;
    private Rigidbody rg;

    private void Start()
    {
        startPos = transform.position;
        rg = GetComponent<Rigidbody>();
    }

    private void Update()
    {
    }

    public void MoveHorizontal(float newPosX)
    {
        Vector3 newPos = startPos + Vector3.right * newPosX;
        rg.MovePosition(newPos);
    }
}
