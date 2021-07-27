using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Threading;

public class PlayerController : MonoBehaviour
{
    public int maxLives = 1;
    public int currentLife;
    public TextMeshProUGUI livesText;

    void Start()
    {
        currentLife = maxLives;
        UpdateLivesText();
    }

    public void PlayerKilled()
    {
        currentLife--;
        if(currentLife < 1)
        {
            GameController.instance.EndGame();
        } else
        {
         
            Invoke("ResetPlayer", 3f);


        }
        UpdateLivesText();
        Player.instance.gameObject.SetActive(false);

    }

    public void UpdateLivesText()
    {
        livesText.text = currentLife.ToString();
    }

    public void ResetPlayer()
    {
        Player.instance.SpawnPlayer();
        Player.instance.isInvinsible = true;
        Invoke("MakeVulnerable", 2f);

    }

    public void MakeVulnerable()
    {
        Player.instance.isInvinsible = false;
    }

}
