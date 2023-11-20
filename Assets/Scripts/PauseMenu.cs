using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseMenu : MonoBehaviour
{
    public static bool _gameIsPaused = false;
    public GameObject _pauseMenuUI;
    public TongueGrapple _tongueGrapple;
    public GameObject _player;
    void Start()
    {
        _pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        _gameIsPaused = false;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (_gameIsPaused)
            {
                Resume();
                Debug.Log("Resume");
                _tongueGrapple.isPaused = false;
               // Cursor.lockState = CursorLockMode.Locked;
                //Cursor.visible = false;
            }
            else
            {
                _tongueGrapple.isPaused = true;
                Pause();
                Debug.Log("Pause");
                //Cursor.lockState = CursorLockMode.None;
                //Cursor.visible = true;
            }
        }
    }
    public void Resume()
    {
        _pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        _gameIsPaused = false;
        SpringJoint[] joints = _player.GetComponents<SpringJoint>();
        foreach(SpringJoint joint in joints)
        Destroy(joint); 
        _tongueGrapple.TongueRetract();
    }
    void Pause()
    {
        _pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        _gameIsPaused = true;
        //Cursor.lockState = CursorLockMode.None;
    }
    public void LoadMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void QuitGame()
    {
        Debug.Log("Quitting game...");
        Application.Quit();
    }
}