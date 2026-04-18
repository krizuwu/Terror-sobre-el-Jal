using UnityEngine;
using Firebase.Firestore;
using Firebase.Extensions;
using System.Collections.Generic;

public class GestorBaseDatos : MonoBehaviour
{
    private FirebaseFirestore db;
    public int monedasActuales = 0;
    public int nivelActual = 1;

    void Start()
    {
        // Conectamos con Firestore al abrir el juego
        db = FirebaseFirestore.DefaultInstance;
        CargarProgreso();
    }

    
    public void RecogerMoneda(int cantidad)
    {
        monedasActuales += cantidad;
        GuardarProgreso();
    }


    public void GuardarProgreso()
    {
        DocumentReference docRef = db.Collection("Jugadores").Document("JuanCarlos");
        
        Dictionary<string, object> datosJugador = new Dictionary<string, object>
        {
            { "monedas", monedasActuales },
            { "nivelActual", nivelActual }
        };

        docRef.SetAsync(datosJugador).ContinueWithOnMainThread(task => {
            if (task.IsCompleted) {
                Debug.Log("¡Progreso de JuanCarlos guardado en la nube con éxito!");
            }
        });
    }

    // Carga las monedas desde la nube al abrir el juego
    public void CargarProgreso()
    {
        DocumentReference docRef = db.Collection("Jugadores").Document("JuanCarlos");
        
        docRef.GetSnapshotAsync().ContinueWithOnMainThread(task => {
            if (task.IsCompleted && task.Result.Exists) {
                DocumentSnapshot snapshot = task.Result;
                monedasActuales = snapshot.GetValue<int>("monedas");
                nivelActual = snapshot.GetValue<int>("nivelActual");
                Debug.Log("Progreso cargado desde Firebase. Monedas: " + monedasActuales);
            }
        });
    }
}
