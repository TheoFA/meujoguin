using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextBubble : MonoBehaviour
{
 [SerializeField] private Camera camera1;
 [SerializeField] private Transform target;
 

private void Start() {
     // Atribui automaticamente a câmera principal
        camera1 = Camera.main;

        if (camera1 == null)
        {
            Debug.LogError("Main Camera not found. Make sure a camera is tagged as 'MainCamera'.");
        }
}
 private void Update() {
    transform.rotation = camera1.transform.rotation;
 }
}
