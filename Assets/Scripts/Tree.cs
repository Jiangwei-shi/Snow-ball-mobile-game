using UnityEngine;

public class Tree : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // Check that the object we collided with is the player.
        if (other.gameObject.name != "Player") {
            return;
        }

        // Add the volume of the snowball.
        Vector3 currentScale = other.gameObject.transform.localScale;
        other.gameObject.transform.localScale = new Vector3(0.9f * currentScale.x,
         0.9f * currentScale.y, 0.9f * currentScale.z);

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
        
    }
}
