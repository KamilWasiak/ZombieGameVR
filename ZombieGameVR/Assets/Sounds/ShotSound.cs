using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotSound : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DestroySound(1.0f));
    }


    private IEnumerator DestroySound(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        Destroy(gameObject);
    }
}
