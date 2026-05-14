using UnityEngine;

public class GlowPulse : MonoBehaviour
{
    public Renderer glowRenderer;

    public float minIntensity = 1f;
    public float maxIntensity = 5f;

    public float pulseSpeed = 2f;

    private Material glowMaterial;

    void Start()
    {
        glowMaterial = glowRenderer.material;
    }

    void Update()
    {
        float emission = Mathf.Lerp(
            minIntensity,
            maxIntensity,
            Mathf.PingPong(Time.time * pulseSpeed, 1)
        );

        Color baseColor = Color.yellow;

        glowMaterial.SetColor("_EmissionColor", baseColor * emission);
    }
}