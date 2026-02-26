using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;


public class Delivery : MonoBehaviour
{
    [SerializeField] float destroySpeed = 0.1f;
    bool hasPackage;
    [SerializeField] AudioSource pickUp;
    [SerializeField] AudioSource turnIn;
    [SerializeField] TMP_Text packageText;

  void Start()
    {
        packageText.gameObject.SetActive(false);
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        // if (the tag is package)
        // then (print picked up package to console)
        if(collision.CompareTag("Package") && !hasPackage)
        {
            Debug.Log("Picked up package");
            hasPackage = true;
            GetComponent<ParticleSystem>() .Play();
            Destroy(collision.gameObject, destroySpeed);
            pickUp.Play();
            packageText.gameObject.SetActive(true);
        }

        if(collision.CompareTag("Customer") && hasPackage)
        {
            Debug.Log("Delivered package");
            hasPackage = false;
            GetComponent<ParticleSystem>() .Stop();
            Destroy(collision.gameObject);
            turnIn.Play();
            packageText.gameObject.SetActive(false);
        }
        
    }
}
