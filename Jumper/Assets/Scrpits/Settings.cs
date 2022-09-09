using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{

    public GameObject Menu;
    public Slider Sl;
    public AudioSource AS;

    private void Start()
    {
        Sl.value = PlayerPrefs.GetFloat("sounds");
    }
    public void OnCancel()
    {
        AS.volume = PlayerPrefs.GetFloat("sounds");
        gameObject.SetActive(false);
        Menu.SetActive(true);
    }

    public void OnChanging()
    {
        float value = Sl.value;
        PlayerPrefs.SetFloat("sounds", value);
        float test = PlayerPrefs.GetFloat("sounds");
        //Debug.Log(test);
    }

}
