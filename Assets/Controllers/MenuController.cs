using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
  // variavel cena, utilizada para informar qual a cena o usuário irá quando clicar em "Play" 
    public string cena;

    public void StartGame() {
      // Envia o player para a cena do jogo
      // Está cena é variavel pois o player pode voltar em uma fase especifica
      SceneManager.LoadScene(cena);
    }

    public void QuitGame() {
      // Faz com que o player saia do jogo
      UnityEditor.EditorApplication.isPlaying = false;
    }
}
