using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Player2 : MonoBehaviour
{
    private int scoreCounter;
    private int healthCounter = 100;
    public Text scoreText;
    public Text healthText;
    public Camera myCamera;
    public AudioClip pickSound;
    public Vector3 jump;
    public float jumpForce = 5.0f;
     public double timeRemaining = 120000;

    void FixedUpdate(){
        float moveHorizontal = Input.GetAxis("Horizontal");
        
        Vector3 movement = new Vector3();
        movement.x = moveHorizontal;
        

        Rigidbody rb = this.GetComponent<Rigidbody>();
        rb.AddForce(movement*1000*Time.deltaTime);

    }
   void Update()
   {
       if(scoreCounter==3){
            GameObject wallToDestroy = GameObject.Find("block");
            Destroy(wallToDestroy);
        }
         if(scoreCounter==4){
            GameObject wallToDestroy = GameObject.Find("block 3");
            Destroy(wallToDestroy);
        }
        if(scoreCounter==6){
            GameObject wallToDestroy = GameObject.Find("block 2");
            Destroy(wallToDestroy);
        }
        if(scoreCounter==7){
            GameObject wallToDestroy = GameObject.Find("block 4");
            Destroy(wallToDestroy);
        }
        if (timeRemaining > 0)
        {
        timeRemaining -= 0.0001;
        }
        else
        {
            healthText.text = "YOU LOSE";
            scoreText.text = "Game Over";
            Time.timeScale = 0;
            Debug.Log("Time has run out!");
        }
   }
    void OnTriggerEnter(Collider x){
        if(x.tag=="pickup"){
            x.gameObject.SetActive(false);
            scoreCounter++;
            scoreText.text = "Score: " + scoreCounter;
            AudioSource s = myCamera.GetComponent<AudioSource>();
            s.PlayOneShot(pickSound);
        }
        if (x.tag == "Up")
        {
        jump = new Vector3(0.0f, 0.0f, 3.0f);
        this.GetComponent<Rigidbody>().AddForce(jump * jumpForce, ForceMode.Impulse);
        }
        
        if(scoreCounter==10){
            scoreText.text = "YOU WIN ";
             Time.timeScale = 0; 
        }
        
        if(x.tag=="hit"){
            healthCounter=healthCounter-40;
            healthText.text = "health: " + healthCounter;
            if(healthCounter<0){
            healthText.text = "YOU LOSE";
            scoreText.text = "Game Over";
            Time.timeScale = 0; }
        }
    }
            
}
