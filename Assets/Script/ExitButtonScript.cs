using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitButtonScript : MonoBehaviour
{
    private void OnMouseDown()
    {
        ExitGame();
    }
    public void ExitGame()
    {
        // Завершаем приложение
        Application.Quit();
    }
}

