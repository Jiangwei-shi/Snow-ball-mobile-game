using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetScale : MonoBehaviour
{
    public float timer = 0f;
    public float meltTime = 6f;
    public float minSize = 0.00005f;

    public bool isMinSize = false; 
    // Start is called before the first frame update
    void Start()
    {
        if (isMinSize  == false)
        {
            //StartCoroutine(Melt());
        }
    }

    // Update is called once per frame
    void Update()
    {  
    } 

    private IEnumerator Melt() {
        Vector3 startScale = transform.localScale;
        Vector3 minScale = new Vector3(minSize, minSize, minSize);

        Vector3 currentScale = transform.localScale;
        do 
        {
            StartCoroutine(TransformScale(currentScale));
            currentScale = transform.localScale;
            yield return null;
        } while(currentScale.magnitude > minScale.magnitude);

        isMinSize = true;
    }

    private IEnumerator TransformScale(Vector3 currentScale)
    {
        yield return new WaitForSeconds(2);
        transform.localScale = new Vector3(currentScale.x * 0.9f, currentScale.y * 0.9f, currentScale.z * 0.9f);
    }
}
