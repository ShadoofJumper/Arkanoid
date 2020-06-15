using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] private Color color;

    // Start is called before the first frame update
    void Start()
    {
        SetColor();
    }

    protected void SetColor()
    {
        GetComponent<MeshRenderer>().material.color = color;
    }
}
