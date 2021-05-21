using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class PlayerController : MonoBehaviour
{
  public Rigidbody2D rb;
  
  public Animator anim;
  
  public int cherries = 0;
  
  // Start is called before the first frame update
  void Start() {
    anim = GetComponent<Animator>();
  }
 
  private void Update() {
    if (Input.GetKey(KeyCode.A)) {
      rb.velocity = new Vector2(-4, rb.velocity.y);
      transform.localScale = new Vector2(1, 1);
      anim.SetBool("running", true);
    }
    else if (Input.GetKey(KeyCode.D)) {
      rb.velocity = new Vector2(4, rb.velocity.y);
      transform.localScale = new Vector2(-1, 1);
      anim.SetBool("running", true);
    }
    else {
      anim.SetBool("running", false);
    }

    if (Input.GetKeyDown(KeyCode.Space)) {
      rb.velocity = new Vector2(rb.velocity.x, 5f);
    }
  }

  void OnCollisionEnter2D(Collision2D other) {
    if(other.gameObject.tag == "Enemy") {
      SceneManager.LoadScene("GameOver");
    }
  }

  void OnTriggerEnter2D(Collider2D collision) {
    if(collision.gameObject.tag == "Collectable") {
      Destroy(collision.gameObject);
      cherries += 1;
    }
  }
}
