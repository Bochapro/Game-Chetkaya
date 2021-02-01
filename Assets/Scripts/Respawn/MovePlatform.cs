using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlatform : MonoBehaviour
{
    public GameObject thePlatform;
    public Transform generationPoint;

    private float platformWidth;

    private void Start()
    {
        platformWidth = thePlatform.GetComponent<BoxCollider2D>().size.x + 18.0F;
            
    }
    private void Update()
    {
        if (transform.position.x < generationPoint.position.x)
        {
            transform.position = new Vector3(transform.position.x + platformWidth, transform.position.y, transform.position.z);
            Instantiate(thePlatform, transform.position, transform.rotation);
        }
    }

}
