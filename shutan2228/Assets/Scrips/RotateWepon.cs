
using UnityEngine;

public class RotateWepon : MonoBehaviour
{
     // Указываем объекту, который должен быть повернут в сторону мыши
    public Transform targetObject;

    void Update()
    {
        // Проверяем, что объект для поворота задан
        if (targetObject == null)
        {
            Debug.LogError("Target object is not set!");
            return;
        }

        // Получаем позицию мыши в мировых координатах
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0f; // Задаем z координату мыши так, чтобы она находилась на плоскости экрана

        // Вычисляем направление от объекта к указателю мыши
        Vector3 direction = mousePosition - targetObject.position;
        direction.Normalize(); // Нормализуем вектор направления, чтобы получить единичный вектор

        // Вычисляем угол поворота от текущего направления объекта к направлению мыши
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // Поворачиваем объект в сторону мыши
        targetObject.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

       
    }
}
