using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IndicatorS : MonoBehaviour
{
    private const float startpos = 3f; // ��������� ���� ������ ��� ���������� (����� ������ ���� ������ Jumper.lim)
    public float force; // ���� ������
    public Jumper player; // �����
    private Image Ind; // ���������
    void Start()
    {
        player = GameObject.FindObjectOfType<Jumper>(); //��������� ������ �� ����� � ����������
        Ind = GetComponent<Image>(); // ��������� ���������� �� ����� � ����������
    }

    void Update()
    {
        Color myColor = new Color(2.0f * (force / 3), 2.0f * (1 - (force / 3)), 0); // ��������� ����� (�������� ���� �� ��������� https://stackoverflow.com/questions/6394304/algorithm-how-do-i-fade-from-red-to-green-via-yellow-using-rgb-values)
        force = player.Timecount; // ������������� ���� ������
        Ind.fillAmount = force / startpos; //��������� ��������� ���������� 
        Ind.color = myColor; // ��������� �����
    }
}
