using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    private CharacterController controller;
    [SerializeField] private float jumpForce;
    [SerializeField] private float gravity;
    [SerializeField] private float dashSpeed;
    [SerializeField] private GameObject panel;
    [SerializeField] private Text coinsText;
    [SerializeField] private MetersIncrease metersIncrease;
    private CapsuleCollider col;
    public int coins;
    private float lineToMove = 1f;
    public static float lineDistance = 4f;
    private float x, y;

    void Start()
    {
        Time.timeScale = 1;
        controller = GetComponent<CharacterController>();
        col = GetComponent<CapsuleCollider>();
        panel.SetActive(false);
        coins = PlayerPrefs.GetInt("coins");
        coinsText.text = coins.ToString();
    }

    private void Update()
    {
        if (SwipeController.swipeRight)
        {
            if (lineToMove < 2) lineToMove += lineDistance;
        }

        if (SwipeController.swipeLeft)
        {
            if (lineToMove > 0) lineToMove -= lineDistance;
        }

        if (SwipeController.swipeUp)
        {
            if (controller.isGrounded) Jump();
        }

        if (SwipeController.swipeDown)
        {
            StartCoroutine(Slide());
        }

        /*** Old movement
        Vector3 targetPosition = transform.position.x * transform.position.y * transform.up;
        if (lineToMove == 0) targetPosition += Vector3.left * lineDistance;
        else if (lineToMove == 2) targetPosition += Vector3.right * lineDistance;

        transform.position = targetPosition;
        ***/

        Vector3 moveVector = new Vector3(x - transform.position.x, y * Time.deltaTime, 0);
        x = Mathf.Lerp(x, lineToMove, dashSpeed * Time.deltaTime);
        controller.Move(moveVector);
    }

    private void FixedUpdate()
    {
        y += gravity * Time.fixedDeltaTime;
    }

    public void Jump()
    {
        y = jumpForce;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "coin")
        {
            coins++;
            PlayerPrefs.SetInt("coins", coins);
            coinsText.text = coins.ToString();
            Destroy(other.gameObject);
            Destroy(other.transform.parent.gameObject);
        }

        if (other.gameObject.tag == "obstacle")
        {
            panel.SetActive(true);
            int lastRunMeters = int.Parse(metersIncrease.scoreText.text.ToString());
            PlayerPrefs.SetInt("lastRunMeters", lastRunMeters);
            Time.timeScale = 0;
        }
    }

    private IEnumerator Slide()
    {
        transform.localEulerAngles = new Vector3(90, 0, 0);

        yield return new WaitForSeconds(1);

        transform.localEulerAngles = new Vector3(0, 0, 0);
    }
}
