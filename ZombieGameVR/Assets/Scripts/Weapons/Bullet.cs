using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    float bulletSpeed, bulletDamage;
    Rigidbody bulletRigidbody;
    public GameObject shotSound;

    void Start()
    {
        bulletRigidbody = GetComponent<Rigidbody>();
        bulletRigidbody.velocity = transform.forward * bulletSpeed;

        Instantiate(shotSound);
}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Pistol" || other.gameObject.tag == "Player")
        {

        }
        else if (other.gameObject.tag == "Zombie")
        {
            var zombieScript = other.GetComponent<Zombie>();
            zombieScript.zombieHealth -= bulletDamage;
            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
            
    }
}
