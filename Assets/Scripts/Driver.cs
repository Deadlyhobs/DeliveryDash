using NUnit.Framework;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
public class Driver : MonoBehaviour
{
    [SerializeField] float steerSpeed = 200f;
    [SerializeField] float currentSpeed = 8f;
    [SerializeField] float boostSpeed = 15f;
    [SerializeField] float regularSpeed = 8f;

    [SerializeField] TMP_Text boosttext;
    

    [SerializeField] AudioSource wallHit;
    [SerializeField] AudioSource boostUp;

    void Start()
    {
        boosttext.gameObject.SetActive(false);
    }
    void Update()
    {
       
       float steer = 0f;
       float move = 0f;
       
       
       
       if(Keyboard.current.wKey.isPressed)
        {
           move = 1f;
        }

        else if(Keyboard.current.sKey.isPressed)
        {
            move = -1f;
        }

        if(Keyboard.current.aKey.isPressed)
        {
            steer = 1f;
        }

        else if(Keyboard.current.dKey.isPressed)
        {
            steer = -1f;
        }
       
       float steerAmount = steer * steerSpeed * Time.deltaTime;
       float moveAmount = move * currentSpeed * Time.deltaTime;
        
       transform.Rotate(0, 0, steerAmount);
       transform.Translate(0, moveAmount, 0);

    }

       private void OnTriggerEnter2D(Collider2D collision) 
       {
        
    if(collision.CompareTag("Boost"))
        {
          Debug.Log("Picked up boost");
          currentSpeed = boostSpeed; 
          boosttext.gameObject.SetActive(true); 
          Destroy(collision.gameObject);
          boostUp.Play();
        }
   
       }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("WorldCollision"))
        {
            currentSpeed = regularSpeed;
            boosttext.gameObject.SetActive(false);
            wallHit.Play();

        } 
    }


}
