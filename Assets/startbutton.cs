using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class startbutton : MonoBehaviour
{
    public GameObject instructions;
    private bool firsttouch = true;

    public void Pressedbutton()
    {
        print("hello");
        if (firsttouch == true)
        {
            instructions.SetActive(true);
            firsttouch = false;
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
