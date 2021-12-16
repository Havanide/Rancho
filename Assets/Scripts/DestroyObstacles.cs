using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObstacles : MonoBehaviour
{
    public float destroyBound = -10f;

    void Update()
    {
        if (transform.position.z < destroyBound)
        {
            if (transform.parent.gameObject)
            {
                Destroy(transform.parent.gameObject);
            }
            Destroy(gameObject);
        }
    }
}
