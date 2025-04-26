using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunRotation : MonoBehaviour
{
    public float SpeedRotation;
    private static float _speedRotation;
    public Renderer targetRenderer; // Укажи рендерер объекта
    public Color emissionColor = Color.yellow; // Цвет свечения
    private Material _material;
    private void OnValidate()
    {
        _speedRotation = SpeedRotation;
    }
    void Start()
    {
        // Получаем материал
        _material = targetRenderer.material;
        _material.EnableKeyword("_EMISSION"); 
    }
    void FixedUpdate()
    {
        transform.Rotate(_speedRotation, 0, 0);
        float intensity = -2.5f + 2.5f * Mathf.Sin(transform.rotation.eulerAngles.x%360 * Mathf.Deg2Rad);
    }
}
