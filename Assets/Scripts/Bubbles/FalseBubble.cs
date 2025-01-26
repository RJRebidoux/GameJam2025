using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FalseBubble : Bubble
{
    public float falseTime = 0f;

    void OnTriggerEnter2D()
    {
        StartCoroutine(Pop(falseTime));
    }
}
