using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] private Color color;

    // Start is called before the first frame update
    void Start()
    {
        SetColor(color);
    }

    public void SetColor()
    {
        GetComponent<MeshRenderer>().material.color = this.color;
    }

    public void SetColor(Color color)
    {
        this.color = color;
        GetComponent<MeshRenderer>().material.color = color;
    }
}
