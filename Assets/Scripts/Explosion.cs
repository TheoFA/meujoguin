using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public float explosionDuration = 2f;  // Duração da explosão

    private void Start()
    {
        // Destroi o objeto de explosão após o tempo especificado
        Destroy(gameObject, explosionDuration);
    }
}

