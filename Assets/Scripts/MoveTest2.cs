using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveTest2 : MonoBehaviour
{
    public float Speed = 7f;
    public AudioSource audioSource;
    public AudioClip blow2SFX;
    

    public Animator Anim;
    public EdgeCollider2D edge;

    private Rigidbody2D rb2d;

    private void Awake() {
        rb2d = GetComponent<Rigidbody2D>();
    }
    private void Start() {
        Anim = GetComponent<Animator>();
        edge.GetComponent<EdgeCollider2D>().enabled = false;
    }
    private void Update() {
        if(Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.LeftArrow)){
                Anim.SetBool("isWalking2", true);
        }
        else{
                 Anim.SetBool("isWalking2", false);
        }
        if(Input.GetKey(KeyCode.M)){
            Anim.SetTrigger("Attack2");
            audioSource.clip = blow2SFX;
            audioSource.Play();
        }
    }
    private void FixedUpdate() {
        if(Input.GetKey(KeyCode.RightArrow)){
            transform.Translate(new Vector3(-1, 0, 0) * Time.fixedDeltaTime * Speed);
            } 
        if(Input.GetKey(KeyCode.LeftArrow)){
            transform.Translate(new Vector3(1, 0, 0) * Time.fixedDeltaTime * Speed);
        }
        
        edge.GetComponent<EdgeCollider2D>().enabled = false;
        if(Anim.GetCurrentAnimatorStateInfo(0).IsName("Attack2")){
            edge.GetComponent<EdgeCollider2D>().enabled = true;
        }
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.name == "P1SumAt" && GetComponent<BoxCollider2D>()){
            Debug.Log("Collide");
        }
    }
    
}
