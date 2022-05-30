using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Pistol : MonoBehaviour
{
    public GameObject bullet;
    public InputActionReference shootReference = null;
    Transform gunBarell;
    Animation shotAnimation;

    private void Start()
    {
        gunBarell = GameObject.Find("Barrel").GetComponent<Transform>();
        shotAnimation = GetComponent<Animation>();

    }

    private void Awake()
    {
        shootReference.action.started += Shoot;
    }


    private void OnDestroy()
    {
        shootReference.action.started -= Shoot;
    }

    private void Shoot(InputAction.CallbackContext context)
    {
        Instantiate(bullet, gunBarell.position, gunBarell.rotation);
        shotAnimation.Play();
    }
}
