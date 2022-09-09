using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameButtons : MonoBehaviour
{
    public GameObject pause;
    public GameObject settings;
    public AudioSource AS;
   // public GameObject Deathcam;
    public Slider Sl;
    void Start()
    {
        Sl.value = PlayerPrefs.GetFloat("sounds");
    }
    public void OnPause()
    {
        Time.timeScale = 0f;
        settings.SetActive(false);
        pause.SetActive(true);
    }
    public void OnReturn()
    {
        Time.timeScale = 1f;
        pause.SetActive(false);
    }
    public void OnRepeat()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Game");
    }
    public void OnMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }
    public void OnSettings()
    {
        Time.timeScale = 0f;
// Deathcam.SetActive(false);
        pause.SetActive(false);
        settings.SetActive(true);
    }
    public void OnCancel()
    {
        AS.volume = PlayerPrefs.GetFloat("sounds");
        Time.timeScale = 1f;
        settings.SetActive(false);
    }
    public void OnChanging()
    {
        float value = Sl.value;
        PlayerPrefs.SetFloat("sounds", value);
        float test = PlayerPrefs.GetFloat("sounds");
        //Debug.Log(test);
    }
}
