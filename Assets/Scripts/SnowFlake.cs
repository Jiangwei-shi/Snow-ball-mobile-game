using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowFlake : MonoBehaviour
{
    public float turnSpeed = 90f;

    private void OnTriggerEnter(Collider other)
    {
        // Check that the object we collided with is the player.
        if (other.gameObject.name != "Player") {
            return;
        }

        // Add the volume of the snowball.
        Vector3 currentScale = other.gameObject.transform.localScale;
        other.gameObject.transform.localScale = new Vector3(1.05f * currentScale.x,
         1.05f * currentScale.y, 1.05f * currentScale.z);

        // Destroy this snowflake object.
        Destroy(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, turnSpeed * Time.deltaTime);
    }
}
