using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonPlay : MonoBehaviour
{
    private void OnMouseDown()
    {
        SceneManager.LoadScene(1);
    }
}
