using UnityEngine;

public class Delivery : MonoBehaviour
{
    [SerializeField] float destroySpeed = 0.1f;
    bool hasPackage;


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
        }

        if(collision.CompareTag("Customer") && hasPackage)
        {
            Debug.Log("Delivered package");
            hasPackage = false;
            GetComponent<ParticleSystem>() .Stop();
        }
        
    }
}
