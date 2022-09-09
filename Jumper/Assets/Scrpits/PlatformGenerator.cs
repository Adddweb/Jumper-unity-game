using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlatformGenerator : MonoBehaviour
{
    public GameObject splatform; // ������ ��������� 
    public GameObject player; // �����
    public AudioSource AS;
    public AudioClip AC;
    public Jumper players; // ������ ������
    public Text textscore; // ����� �����
    public float maxscore = 25; // ������������ ���������� ����� ���������� �� ���� ������
    private bool spawned = false; // ���������� ���������� ��� �������� ������ ��������� � ���������

    private void Start()
    {
        players = GameObject.FindObjectOfType<Jumper>(); //��������� ������� ������ �� ����� 
        player = GameObject.Find("Player"); // ��������� ������ �� �����
    }
    float Genx() // ��������� ���������� x �� ������� ����������� ���������
    {
        
        float randomx = gameObject.transform.position.x + Random.Range(5f, 7f);
        return randomx;
    }
    float Geny() // ��������� ���������� y �� ������� ����������� ���������
    {
        int chance = Random.Range(1, 3); // ���������� ����� �� 1 �� 2 (������������) ��� ��������� ��������� ����� ��������� � ����������� �� ������������ ������
        float randomy = 0;
        //Debug.Log(chance);
        if (chance == 1) // 50 % �� ����� ����� ��������� � ������� ����������� �� y ��� ������
        {
            randomy = gameObject.transform.position.y + Random.Range(2f, 4f);
            //Debug.Log("1");
        }
        else if(chance == 2) // 50 % �� ����� ����� ��������� � ������� ����������� �� y ��� ������
        {
            randomy = gameObject.transform.position.y - Random.Range(2f, 4f);
            //Debug.Log("2");
        }
        //Debug.Log(randomy);
        return randomy;
    }

    private void OnCollisionEnter2D(Collision2D collision) // ����������� ������ �� ���������
    {
        AS.PlayOneShot(AC);
        //players.isgrounded = true; // ��������� ����������� ��������
        players.death = gameObject.transform.position.y - 10; // ���������� ����������� y ����������
        if(spawned == false) // �������� ������ ��������� � ���������
        {
            Vector3 pos = new Vector3(Genx(), Geny(), 0);
            Instantiate(splatform, pos, Quaternion.identity);
            score();
        }
        spawned = true;
    }

    public void score() // ����������� ������������� ������ � ����
    {
        float summ = 0;
        float raz = Mathf.Abs(player.transform.position.x - gameObject.transform.position.x);// ���������� ������� ����� ����������� ������ � ������ ��������� �� x
        float fscore = maxscore - Mathf.Round(raz * 10); // ����������� ������� � ����� ����� � ��������� ���-�� ����� ����������� �� �����������(����������� ���-�� ����� ������������ ���������� maxscore)
        summ = float.Parse(textscore.text); // ��������� �������� �������� � ��������� ���� �� ������
        summ += fscore; // ����������� ����� ���������� �� ���� ������ � ����������� �������� � ���� �� ������
        textscore.text = summ.ToString(); // ��������� ������ ���-�� ����� � ���� �� ������
    }
}
