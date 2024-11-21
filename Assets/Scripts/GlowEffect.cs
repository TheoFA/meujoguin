using UnityEngine;

public class GlowEffect : MonoBehaviour
{
    public Renderer glowRenderer; // Renderer do objeto que vai brilhar
    public Color glowColor = Color.yellow; // Cor do brilho
    public float minGlowIntensity = 1f; // Intensidade mínima do brilho
    public float maxGlowIntensity = 5f; // Intensidade máxima do brilho
    public float glowSpeed = 2f; // Velocidade do brilho

    private Material glowMaterial; // Material do objeto
    private float time;

    private void Start()
    {
        if (glowRenderer == null)
        {
            glowRenderer = GetComponent<Renderer>();
        }

        glowMaterial = glowRenderer.material;
        glowMaterial.EnableKeyword("_EMISSION");
    }

    private void Update()
    {
        time += Time.deltaTime * glowSpeed;
        float intensity = Mathf.Lerp(minGlowIntensity, maxGlowIntensity, Mathf.PingPong(time, 1f));
        glowMaterial.SetColor("_EmissionColor", glowColor * intensity);
    }
}
