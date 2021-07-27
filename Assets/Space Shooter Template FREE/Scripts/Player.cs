using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// This script defines which sprite the 'Player" uses and its health.
/// </summary>

public class Player : MonoBehaviour
{
    public GameObject destructionFX;

    public static Player instance;

    public PlayerController playerController;

    public Vector3 defaultSpawn;

    public bool isInvinsible;

    void Start()
    {
        defaultSpawn = transform.position;
    }


    private void Awake()
    {
        if (instance == null) 
            instance = this;
    }

    public void SpawnPlayer()
    {
        gameObject.SetActive(true);
        transform.position = defaultSpawn;
    }
    //method for damage proceccing by 'Player'
    public void GetDamage(int damage)   
    {
        if(!isInvinsible)
        {
            Destruction();
        }
        
    }    

    //'Player's' destruction procedure
    void Destruction()
    {
        Instantiate(destructionFX, transform.position, Quaternion.identity); //generating destruction visual effect and destroying the 'Player' object
        playerController.PlayerKilled();

    }
}
















