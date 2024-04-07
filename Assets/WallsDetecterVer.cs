using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallsDetecterVer : MonoBehaviour
{
    public GameObject newObjectPrefab;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("blocks"))
        {   
            Debug.Log("blabla");
            ReplaceChildren();
        }
    }

    void ReplaceChildren()
    {
        // Проходимся по всем дочерним объектам и заменяем их на новые объекты
        for (int i = 0; i < transform.childCount; i++)
        {
            Transform child = transform.GetChild(i);

            // Получаем позицию и поворот текущего дочернего объекта
            Vector3 position = child.position;
            Quaternion rotation = child.rotation;

            // Создаем новый объект на месте старого
            GameObject newObject = Instantiate(newObjectPrefab, position, rotation);

            // Копируем компоненты с текущего дочернего объекта на новый (необязательно)
            //CopyComponents(child.gameObject, newObject);

            // Уничтожаем старый дочерний объект
            Destroy(child.gameObject);
        }
    }

    void CopyComponents(GameObject oldObject, GameObject newObject)
    {
        // Получаем все компоненты текущего объекта
        Component[] components = oldObject.GetComponents<Component>();

        // Копируем компоненты на новый объект
        foreach (Component comp in components)
        {
            // Проверяем, не является ли компонентом трансформация
            if (!(comp is Transform))
            {
                // Копируем компоненты, кроме Transform, на новый объект
                UnityEditorInternal.ComponentUtility.CopyComponent(comp);
                UnityEditorInternal.ComponentUtility.PasteComponentAsNew(newObject);
            }
        }
    }
}
