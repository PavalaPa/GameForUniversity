using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Lev4Buttom : MonoBehaviour
{
    private void OnMouseDown()
    {
        SceneManager.LoadScene(10);
    }
}
