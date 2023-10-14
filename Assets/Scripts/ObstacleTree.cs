using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleTree : MonoBehaviour
{
    PlayerMovement playerMovement;
    // Start is called before the first frame update
    void Start()
    {
        playerMovement = GameObject.FindObjectOfType<PlayerMovement>();
    }
    

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player") {
            playerMovement.Die();
        }
        // Kill the player
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
