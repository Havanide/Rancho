using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[ExecuteInEditMode()]
public class ProgressBar : MonoBehaviour
{
    public float minimum;
    public float maximum;
    public float current;
    public Image mask;
    public Button button;

    // Start is called before the first frame update
    void Start()
    {
        button.GetComponent<Button>();
        button.onClick.AddListener(IncreaseProgress);
    }

    // Update is called once per frame
    void Update()
    {
        GetCurrentFill();
        DecreaseProgress();
    }

    void GetCurrentFill()
    {
        float currentOffset = current - minimum;
        float maximumOffset = maximum - minimum;
        float fillAmount = currentOffset / maximumOffset;
        mask.fillAmount = fillAmount;
    }

    void IncreaseProgress()
    {
        if (current < 100) current += 10;
        else current = 100;

    }

    void DecreaseProgress()
    {
        if (current > 0) current -= 5 * Time.deltaTime;
    }
}
