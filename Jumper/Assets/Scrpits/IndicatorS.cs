using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IndicatorS : MonoBehaviour
{
    private const float startpos = 3f; // множитель силы прыжка для индикатора (равен лимиту силы прыжка Jumper.lim)
    public float force; // сила прыжка
    public Jumper player; // игрок
    private Image Ind; // Индикатор
    void Start()
    {
        player = GameObject.FindObjectOfType<Jumper>(); //Занесение игрока из сцены в переменную
        Ind = GetComponent<Image>(); // Занесение индикатора из сцены в переменную
    }

    void Update()
    {
        Color myColor = new Color(2.0f * (force / 3), 2.0f * (1 - (force / 3)), 0); // Генерация цвета (алгоритм взял из интернета https://stackoverflow.com/questions/6394304/algorithm-how-do-i-fade-from-red-to-green-via-yellow-using-rgb-values)
        force = player.Timecount; // инициализация силы прыжка
        Ind.fillAmount = force / startpos; //изменение положения индикатора 
        Ind.color = myColor; // изменение цвета
    }
}
