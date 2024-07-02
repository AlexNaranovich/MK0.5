using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveTest : MonoBehaviour
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
        if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)){
                Anim.SetBool("isWalking", true);
                
        }
        else{
                 Anim.SetBool("isWalking", false);
                 
        }
        if(Input.GetKey(KeyCode.Z)){
            Anim.SetTrigger("Attack1");
           
            audioSource.clip = blow2SFX;
            audioSource.Play();
        }
    }
    private void FixedUpdate() {
        if(Input.GetKey(KeyCode.D)){
            
            
            transform.Translate(new Vector3(1, 0, 0) * Time.fixedDeltaTime * Speed);
        
        }
        if(Input.GetKey(KeyCode.A)){
            
               
                transform.Translate(new Vector3(-1, 0, 0) * Time.fixedDeltaTime * Speed);
        }
        edge.GetComponent<EdgeCollider2D>().enabled = false;
        if(Anim.GetCurrentAnimatorStateInfo(0).IsName("Attack1")){
             edge.GetComponent<EdgeCollider2D>().enabled = true;
        }
            
        
        
    }
    
    
   /* private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.name == "P2SumAt" && GetComponent<BoxCollider2D>() && Input.GetKeyUp(KeyCode.Z)){
            Debug.Log("Collide");
        }
        
        
    }*/
    
}
