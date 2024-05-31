using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Lev2Buttom : MonoBehaviour
{
    private void OnMouseDown()
    {
        SceneManager.LoadScene(5);
    }
}
