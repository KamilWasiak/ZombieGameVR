using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseballBat : MonoBehaviour
{
    [SerializeField]
    float baseballDamage;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Zombie")
        {
            var zombieScript = other.GetComponent<Zombie>();
            zombieScript.zombieHealth -= baseballDamage;
            Destroy(gameObject);
        }
    }
}
