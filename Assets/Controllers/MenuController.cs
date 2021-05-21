using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    public string cena;

    void Start() {
        
    }

    void Update() {
        
    }

    public void StartGame() {
      SceneManager.LoadScene(cena);
    }

    public void QuitGame() {
      UnityEditor.EditorApplication.isPlaying = false;
    }
}
