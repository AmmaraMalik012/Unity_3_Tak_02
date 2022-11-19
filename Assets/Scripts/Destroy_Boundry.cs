using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy_Boundry : MonoBehaviour
{
    private float topBound = 17;
    void Update()
    {
        if(transform.position.y > topBound)
        {
            Destroy(gameObject);
        }
    }
}
