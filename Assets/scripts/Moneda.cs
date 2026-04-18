using UnityEngine;

public class Moneda : MonoBehaviour
{
    // Esta función se activa automáticamente cuando un objeto con Rigidbody entra en el "Trigger" (Collider fantasma)
    private void OnTriggerEnter2D(Collider2D choque)
    {
        // 1. Revisamos si el objeto que chocó con la moneda se llama "JuanCarlos"
        if (choque.gameObject.name == "JuanCarlos")
        {
 
            GestorBaseDatos banco = Object.FindFirstObjectByType<GestorBaseDatos>();
            
            if (banco != null)
            {
                banco.RecogerMoneda(1);
                Destroy(gameObject); // La moneda desaparece de la pantalla
            }
            else
            {
                Debug.LogWarning("¡Ups! JuanCarlos tocó la moneda, pero no encontré el objeto BaseDatos en la escena.");
            }
        }
    }
}