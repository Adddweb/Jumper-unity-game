using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Jumper : MonoBehaviour
{
    public GameObject Deathcam;
    public GameObject Monet;
    public GameObject PauseButton;
    public AudioSource AS;
    private Rigidbody2D rb; // рб персонажа
    public float multiplyup; // множитель силы прыжка вверх
    public float multiplyright; // множитель силы прыжка вправо
    public float lim = 3f; // лимит силы прыжка
    public float Timecount; // разница во времени от начала нажатия на экран до конца (сила прыжка)
    public float death; // координата места смерти по y
    private bool MD; // логическая переменная для измерения времени удержания экрана
    //public bool isgrounded; // логическая переменная для проверки приземлён ли игрок
    void Start()
    {
        AS = gameObject.GetComponent<AudioSource>();
        AS.volume = PlayerPrefs.GetFloat("sounds");
        Time.timeScale = 1f;
        death = -1000;
        rb = gameObject.GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        //if(isgrounded == true) // проверка на приземление игрока
        //{
        if (Input.GetMouseButtonDown(0)) // Нажатие на экран и начало отсчёта
        {
            MD = true;
            //Debug.Log("Touch down");
        }
        else if (Input.GetMouseButtonUp(0)) // Конец отсчёта
        {
             MD = false;
             //Debug.Log("Touch up");
             //Debug.Log(Timecount);
             Vector2 force = new Vector2(Timecount * multiplyright, Timecount * multiplyup);
             rb.AddForce(force);
             Timecount = 0; 
                //isgrounded = false; // Отключение прыжка на время полёта
        }
        //}
        if (MD == true) // Отсчёт времени удержания экрана
        {
            if(Timecount >= lim) //проверка на лимит
            {
                Timecount = lim;
            }
            else
            {
                Timecount += Time.deltaTime; 
            }
        }
        if(gameObject.transform.position.y <= death) // смерть
        {
            //SceneManager.LoadSceneAsync("Game");
            Time.timeScale = 0f;
            PauseButton.SetActive(false);
            Deathcam.SetActive(true);

        }
    }
}
