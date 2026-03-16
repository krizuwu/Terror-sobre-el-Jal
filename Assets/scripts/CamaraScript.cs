using UnityEngine;

public class CamaraScript : MonoBehaviour
{
    // Esta es la cajita donde arrastraremos a JuanCarlos
    public Transform objetivo; 

    void Update()
    {
        // Si JuanCarlos existe en la escena, la cámara lo sigue
        if (objetivo != null)
        {
            // Copiamos su posición X y Y, pero dejamos la Z de la cámara intacta (-10) para no dejar de ver el juego
            transform.position = new Vector3(objetivo.position.x, objetivo.position.y, transform.position.z);
        }
    }
}