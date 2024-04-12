using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMove : MonoBehaviour
{
    public GameObject hero;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(hero.transform.position.x, hero.transform.position.y + 2f, transform.position.z);
    }

    public string stopTag = "Trigger1"; // Тег объекта, останавливающего камеру
    private bool stopCamera = false; // Флаг, указывающий, нужно ли останавливать камеру

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Проверяем, столкнулась ли камера с объектом, который должен останавливать её
        if (other.CompareTag(stopTag))
        {
            stopCamera = true; // Устанавливаем флаг остановки камеры
            Debug.Log("Camera stopped by trigger: " + other.gameObject.name); // Добавим отладочное сообщение
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        // Если объект, останавливающий камеру, вышел из области действия триггера, снимаем флаг остановки
        if (other.CompareTag(stopTag))
        {
            stopCamera = false;
            Debug.Log("Camera resumed movement."); // Добавим отладочное сообщение
        }
    }

    private void LateUpdate()
    {
        // Если флаг остановки камеры установлен, прерываем выполнение функции
        if (stopCamera)
        {
            Debug.Log("Camera movement stopped due to trigger.");
            return;
        }

        // Если камера не должна останавливаться, здесь можно добавить логику перемещения камеры
    }
}
