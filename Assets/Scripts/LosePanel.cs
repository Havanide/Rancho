using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LosePanel : MonoBehaviour
{

    [SerializeField] Text recordText;

    private void Start()
    {
        int lastRunMeters = PlayerPrefs.GetInt("lastRunMeters");
        int recordMeters = PlayerPrefs.GetInt("recordMeters");

        if (lastRunMeters > recordMeters)
        {
            recordMeters = lastRunMeters;
            PlayerPrefs.SetInt("recordMeters", recordMeters);
            recordText.text = recordMeters.ToString();
        }
        else
        {
            recordText.text = recordMeters.ToString();
        }
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(0);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(1);
    }
}
