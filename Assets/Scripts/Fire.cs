using UnityEngine;

public class Fire : MonoBehaviour
{
    PlayerMovement playerMovement;
    public float minSize = 0.005f;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        // Check that the object we collided with is the player.
        if (other.gameObject.name != "Player") {
            return;
        }

        Vibrator.Vibrate();
        // Add the volume of the snowball.
        Vector3 currentScale = other.gameObject.transform.localScale;
        Vector3 minScale = new Vector3(minSize, minSize, minSize);

        Debug.Log("currentScale"+currentScale);

        if (currentScale.magnitude <= minScale.magnitude) 
        {
            playerMovement.Die();
            Debug.Log("Player dies.");
        }

        other.gameObject.transform.localScale = new Vector3(0.9f * currentScale.x,
         0.9f * currentScale.y, 0.9f * currentScale.z);

        // Destroy this snowflake object.
        Destroy(gameObject);
    }

    void Start()
    {
         playerMovement = GameObject.FindObjectOfType<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
