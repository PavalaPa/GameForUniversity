using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionObj : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("—толкновение!");
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        Debug.Log("ћ€у!");
    }
}
