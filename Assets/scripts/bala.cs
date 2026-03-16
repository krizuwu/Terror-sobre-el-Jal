using UnityEngine;

public class Bala : MonoBehaviour
{
    [SerializeField] public float velocidad = 20f;
    private Rigidbody2D rb2d;
    private Vector2 direccion;

    // Awake conecta el cuerpo de la bala antes de que intente moverse
    void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        // Limpia la basura espacial y fuerza la capa visual al frente
        Destroy(gameObject, 1f);
        GetComponent<SpriteRenderer>().sortingOrder = 100;
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