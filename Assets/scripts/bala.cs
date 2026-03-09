using UnityEngine;

public class Bala : MonoBehaviour
{
    public float velocidad = 10f;
    private Rigidbody2D rb2d;
    private Vector2 direccion;

    void Start()
    {
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        Destroy(gameObject, 1f); 
        GetComponent<SpriteRenderer>().sortingOrder = 100;
    }
    }

    void FixedUpdate()
    {
       rb2d.linearVelocity = direccion * velocidad;
    }

   
    public void AsignarDireccion(Vector2 nuevaDireccion)
    {
        direccion = nuevaDireccion;
    }
}