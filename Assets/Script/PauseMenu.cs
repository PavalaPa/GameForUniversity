using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject pauseOverlay;

    private bool isPaused = false;

    public bool IsPaused()
    {
        return isPaused;
    }
    void Start()
    {
        // ��������� ���� ����� � ���������� ��� ������
        pauseMenu.SetActive(false);
        pauseOverlay.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    void PauseGame()
    {
        Time.timeScale = 0f; // ������������� �����
        isPaused = true;

        // �������� ���� ����� � ����������
        pauseMenu.SetActive(true);
        pauseOverlay.SetActive(true);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f; // ������������ �����
        isPaused = false;

        // ��������� ���� ����� � ����������
        pauseMenu.SetActive(false);
        pauseOverlay.SetActive(false);
    }


    public void LoadMenu()
    {
        Time.timeScale = 1f; // ������������ �����
        SceneManager.LoadScene(3); 
    }
}

