using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void Quit(){Application.Quit();}
    public void LoadScene(string _scene){SceneManager.LoadScene(_scene);}
}
