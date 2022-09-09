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
    private Rigidbody2D rb; // �� ���������
    public float multiplyup; // ��������� ���� ������ �����
    public float multiplyright; // ��������� ���� ������ ������
    public float lim = 3f; // ����� ���� ������
    public float Timecount; // ������� �� ������� �� ������ ������� �� ����� �� ����� (���� ������)
    public float death; // ���������� ����� ������ �� y
    private bool MD; // ���������� ���������� ��� ��������� ������� ��������� ������
    //public bool isgrounded; // ���������� ���������� ��� �������� �������� �� �����
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
        //if(isgrounded == true) // �������� �� ����������� ������
        //{
        if (Input.GetMouseButtonDown(0)) // ������� �� ����� � ������ �������
        {
            MD = true;
            //Debug.Log("Touch down");
        }
        else if (Input.GetMouseButtonUp(0)) // ����� �������
        {
             MD = false;
             //Debug.Log("Touch up");
             //Debug.Log(Timecount);
             Vector2 force = new Vector2(Timecount * multiplyright, Timecount * multiplyup);
             rb.AddForce(force);
             Timecount = 0; 
                //isgrounded = false; // ���������� ������ �� ����� �����
        }
        //}
        if (MD == true) // ������ ������� ��������� ������
        {
            if(Timecount >= lim) //�������� �� �����
            {
                Timecount = lim;
            }
            else
            {
                Timecount += Time.deltaTime; 
            }
        }
        if(gameObject.transform.position.y <= death) // ������
        {
            //SceneManager.LoadSceneAsync("Game");
            Time.timeScale = 0f;
            PauseButton.SetActive(false);
            Deathcam.SetActive(true);

        }
    }
}
