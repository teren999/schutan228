using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // Ссылка на объект, за которым следует камера
    public float smoothSpeed = 0.125f; // Скорость следования камеры

    private Vector3 offset; // Смещение камеры относительно персонажа

    void Start()
    {
        offset = transform.position - target.position;
    }

    void FixedUpdate()
    {
        if (target != null)
        {
            Vector3 desiredPosition = target.position + offset;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothedPosition;
        }
    }
}
