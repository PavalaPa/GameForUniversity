using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Lev1ButtonContinue : MonoBehaviour
{
    private void OnMouseDown()
    {
        SceneManager.LoadScene(4);
    }
}
