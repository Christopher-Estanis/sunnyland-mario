using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class PlayerController : MonoBehaviour
{
  // Propriedade Rigdbody do player, contendo propriedades de fisica do player
   public Rigidbody2D rb;
  
  // Propriedade Animator do player, contendo propriedades dos sprites do player
  public Animator anim;

  // Propriedade chrries para contagem de cerejas  
  public int cherries = 0;
  
  // Start is called before the first frame update
  void Start() {
    anim = GetComponent<Animator>();
  }

  
  // Este é um metododo do MonoBehaviour, o qual é chamado a cada frame renderizado em tela
  private void Update() {
    /*
      Uma condição que utiliza a função Input.GetKey(), o qual verifica se a tecla informada foi precionada
      KeyCode.A é a tecla verificada - A 
    */
    if (Input.GetKey(KeyCode.A)) {
      /* 
        Passa uma velocidade ao RigedBody do player, fazendo que se desloque para o X e Y do plano cartesiano
        Sendo X horizontalmente e Y verticalmente
        Neste caso passando -4, fazendo o player ir para a esquerda
      */
      rb.velocity = new Vector2(-4, rb.velocity.y);

      // Altera lado em que a sprite do player está virada 
      transform.localScale = new Vector2(1, 1); 
      
      // Altera a animação de "running" para verdadeiro (1 - Esquerda)
      anim.SetBool("running", true);
    }
    else if (Input.GetKey(KeyCode.D)) {
      // Neste caso passando 4, fazendo o player ir para a direita
      rb.velocity = new Vector2(4, rb.velocity.y);
      // Altera lado em que a sprite do player está virada (-1 - Direita)
      transform.localScale = new Vector2(-1, 1);
      // Altera a animação de "running" para verdadeiro
      anim.SetBool("running", true);
    }
    else {
      // Altera a animação de "running" para falso
      anim.SetBool("running", false);
    }

    if (Input.GetKeyDown(KeyCode.Space)) {
      // FaZ com que o player vá para cima, continuando com sua velocidade horizontal
      rb.velocity = new Vector2(rb.velocity.x, 5f);
    }
  }

  // Metodo chamado quando à uma colisão entre o player e outro rigedBody
  void OnCollisionEnter2D(Collision2D other) {
    // Verifica se o objeto colidido tem uma tag chamada "Enemy"
    if(other.gameObject.tag == "Enemy") {
      // Envia o player para a cena "GameOver"
      SceneManager.LoadScene("GameOver");
    }
  }

  // Metodo chamado quando à uma colisão entre o player e outro rigedBody com a propriedade "trigger" setada
  void OnTriggerEnter2D(Collider2D collision) {
    // Verifica se o objeto colidido tem uma tag chamada "Collectable"
    if(collision.gameObject.tag == "Collectable") {
      // Destroi o objeto colidido
      Destroy(collision.gameObject);
      // Adiciona mais 1 na propriedade cherries
      cherries += 1;
    }
  }
}
