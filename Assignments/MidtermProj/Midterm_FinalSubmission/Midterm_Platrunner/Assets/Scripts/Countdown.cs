using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Countdown : MonoBehaviour
{

    public Text countdownText;
    public float remainingTime = 5;

    private PowerUpCollect powerUpCollect; // referencing an instance of PowerUpCollect class
    private PlayerRespawn playerRespawn; // referencing an instance of PlayerRespawn class

    public bool timeUp = false;

    void Start ()
    {
        countdownText.text = "";
        
        powerUpCollect = GetComponent<PowerUpCollect>();
        playerRespawn = GetComponent<PlayerRespawn>();
    }

    void Update()
    {
        if (powerUpCollect.powerUpUsed == true)
        {
            Debug.Log("PowerUpUsed.");

            int minutes  = Mathf.FloorToInt(remainingTime / 60);
            int seconds = Mathf.FloorToInt(remainingTime % 60);
            countdownText.text = string.Format("{0:00}:{1:00}", minutes, seconds);

            if (remainingTime > 0)
            {
                remainingTime -= Time.deltaTime;
            }
            else if (remainingTime < 0)
            {
                remainingTime = 0;
                countdownText.text = "";

                timeUp = true;

            }



        }
        




    }
}
