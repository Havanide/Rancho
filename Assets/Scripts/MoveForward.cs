using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{

    public float speed = 5f;
    private const float MAXSPEED = 100;

    void Start()
    {
        SpeedIncrease();
    }

    void Update()
    {
        transform.Translate(-Vector3.forward * Time.deltaTime * speed);
    }

    private IEnumerator SpeedIncrease()
    {
        yield return new WaitForSeconds(20);
        if (speed < MAXSPEED)
        {
            speed += 1;
            StartCoroutine(SpeedIncrease());
        }
    }
}
