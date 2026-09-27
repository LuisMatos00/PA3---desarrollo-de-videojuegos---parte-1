using UnityEngine;

public class CicloDiaNoche : MonoBehaviour
{
    [Range(0.0f, 24f)] public float Hora = 12;   // Hora actual (0–24)
    public float DuracionDelDiaEnMinutos = 1;    // Duración de un día completo en minutos
    public Light sol;                             // Luz direccional (Sol/Luna)
    public Material skyboxDia;                    // Skybox de día
    public Material skyboxNoche;                  // Skybox de noche

    private void Update()
    {
        AvanzarTiempo();
        RotacionSol();
        CambiarIluminacion();
        CambiarSkybox();
    }

    void AvanzarTiempo()
    {
        // Avanza la hora automáticamente según la duración del día
        Hora += Time.deltaTime * (24 / (60 * DuracionDelDiaEnMinutos));
        if (Hora >= 24) Hora = 0;
    }

    void RotacionSol()
    {
        float SolX = 15 * Hora; // 24h * 15° = 360°
        sol.transform.localEulerAngles = new Vector3(SolX, 0, 0);
    }

    void CambiarIluminacion()
    {
        if (Hora > 6 && Hora < 18)
        {
            sol.intensity = 1.5f; // Día más brillante
            sol.shadows = LightShadows.Soft; // Activa sombras suaves
            sol.color = Color.white;
        }
        else
        {
            sol.intensity = 0.3f; // Noche tenue
            sol.shadows = LightShadows.Soft;
            sol.color = new Color(0.5f, 0.5f, 1f); // Azul tenue
        }
    }

    void CambiarSkybox()
    {
        if (Hora > 6 && Hora < 18)
            RenderSettings.skybox = skyboxDia;
        else
            RenderSettings.skybox = skyboxNoche;
    }
}