using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject set;
    public Slider sl;

    private void Start()
    {
        PlayerPrefs.SetFloat("sounds", 0.2f);
        sl.value = PlayerPrefs.GetFloat("sounds");
    }
    public void OnMenuButtonDown()
    {
        SceneManager.LoadSceneAsync("Game");
    }
    public void OnSettingsButtonDown()
    {
        gameObject.SetActive(false);
        set.SetActive(true);
    }
}
