using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlatformGenerator : MonoBehaviour
{
    public GameObject splatform; // Префаб платформы 
    public GameObject player; // Игрок
    public AudioSource AS;
    public AudioClip AC;
    public Jumper players; // Скрипт игрока
    public Text textscore; // Текст счёта
    public float maxscore = 25; // Максимальное количество очков полученное за один прыжок
    private bool spawned = false; // логическая переменная для проверки спавна платформы в платформе

    private void Start()
    {
        players = GameObject.FindObjectOfType<Jumper>(); //получение скрипта игрока из сцены 
        player = GameObject.Find("Player"); // получение игрока из сцены
    }
    float Genx() // генерация координаты x на которой заспавнится платформа
    {
        
        float randomx = gameObject.transform.position.x + Random.Range(5f, 7f);
        return randomx;
    }
    float Geny() // генерация координаты y на которой заспавнится платформа
    {
        int chance = Random.Range(1, 3); // генерирует число от 1 до 2 (включительно) для рандомной генерации новой платформы в зависимости от расположения старой
        float randomy = 0;
        //Debug.Log(chance);
        if (chance == 1) // 50 % на спавн новой платформы с большей координатой по y чем старая
        {
            randomy = gameObject.transform.position.y + Random.Range(2f, 4f);
            //Debug.Log("1");
        }
        else if(chance == 2) // 50 % на спавн новой платформы с меньшей координатой по y чем старая
        {
            randomy = gameObject.transform.position.y - Random.Range(2f, 4f);
            //Debug.Log("2");
        }
        //Debug.Log(randomy);
        return randomy;
    }

    private void OnCollisionEnter2D(Collision2D collision) // Приземление игрока на платформу
    {
        AS.PlayOneShot(AC);
        //players.isgrounded = true; // включение возможности прыгнуть
        players.death = gameObject.transform.position.y - 10; // Обновление смертельной y координаты
        if(spawned == false) // проверка спавна платформы в платформе
        {
            Vector3 pos = new Vector3(Genx(), Geny(), 0);
            Instantiate(splatform, pos, Quaternion.identity);
            score();
        }
        spawned = true;
    }

    public void score() // Конвертация внутриигровых данных в счёт
    {
        float summ = 0;
        float raz = Mathf.Abs(player.transform.position.x - gameObject.transform.position.x);// вычисление разницы между координатой игрока и центра платформы по x
        float fscore = maxscore - Mathf.Round(raz * 10); // Конвертация разницы в целое число и получение кол-во очков заработаных за приземление(максимально кол-во очков регулируется переменной maxscore)
        summ = float.Parse(textscore.text); // Получение текущего значение в текстовом поле со счётом
        summ += fscore; // Прибавление очков полученных за этот прыжок к предидущему значению в поле со счётом
        textscore.text = summ.ToString(); // занесение нового кол-ва очков в поле со счётом
    }
}
