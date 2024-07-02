using UnityEngine;
using UnityEngine.SceneManagement;

public class Test2 : MonoBehaviour
{

    private  int Counter;
    public GameObject Win2;
    public AudioSource audioSource;
    public AudioClip WinSFX;
    private void Start() {
       
    }
    private void Update() {
        Restart();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.name == "P1SumAt" && GetComponent<BoxCollider2D>()){
            Debug.Log("Collide");
            Counter++;
        }
    }
    private void Restart(){
        if(Counter >= 450){
            Win2.SetActive(true);
            audioSource.clip = WinSFX;
            audioSource.Play();
        }
    }
    public void RestartFull(){
        SceneManager.LoadScene("testScene");
    }
    
}
