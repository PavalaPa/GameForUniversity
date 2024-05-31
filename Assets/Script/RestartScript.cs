using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartScript : MonoBehaviour
{
    private void OnMouseDown()
    {
        RestartScene();
    }

    public void RestartScene()
    {
        // Загружаем текущую сцену, что приведет к ее перезапуску
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }
}


