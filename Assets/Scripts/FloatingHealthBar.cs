using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FloatingHealthBar : MonoBehaviour
{
 [SerializeField] private Slider slider;
 [SerializeField] private Camera camera1;
 [SerializeField] private Transform target;
 [SerializeField] private Vector3 offset;

private void Start() {
     // Atribui automaticamente a câmera principal
        camera1 = Camera.main;

        if (camera1 == null)
        {
            Debug.LogError("Main Camera not found. Make sure a camera is tagged as 'MainCamera'.");
        }
}

 public void UpdateHealthBar(float currentValue, float maxValue)
 {
    slider.value = currentValue / maxValue;
 }
 private void Update() {
    transform.rotation = camera1.transform.rotation;
    transform.position = target.position + offset;
 }
}
