using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    [SerializeField] private Transform player;
    private Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - player.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //TODO сделать плавное перемещение камеры
        Vector3 newPosition = new Vector3(offset.x + player.position.x, transform.position.y, transform.position.z);
        transform.position = newPosition;
    }
}
