using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [SerializeField]
    private float playerMaxHealth;
    public float playerHealth;



    private void Start()
    {
        playerHealth = playerMaxHealth;
    }
}
