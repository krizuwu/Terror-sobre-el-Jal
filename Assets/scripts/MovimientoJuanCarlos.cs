using UnityEngine;

public class MovimientoJuanCarlos : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private Animator anim;
    
    public float velocidad = 5f;
    public float fuerzaSalto = 250f; // La fuerza con la que saltará 
    private float horizontal;
    private bool enElSuelo;

    public GameObject prefabBala;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        // 1. Movimiento Horizontal
        horizontal = Input.GetAxisRaw("Horizontal");

        if (horizontal != 0)
        {
            anim.SetBool("running", true);
            if (horizontal < 0) transform.localScale = new Vector3(-1, 1, 1);
            else if (horizontal > 0) transform.localScale = new Vector3(1, 1, 1);
        }
        else
        {
            anim.SetBool("running", false);
        }

        // 2. Disparo (Barra Espaciadora)
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Vector2 direccionDisparo = (transform.localScale.x == 1) ? Vector2.right : Vector2.left;
            Vector3 separacion = new Vector3(direccionDisparo.x * 1.5f, 0, 0); 
            Vector3 posicionAparicion = transform.position + separacion;

            GameObject nuevaBala = Instantiate(prefabBala, posicionAparicion, Quaternion.identity);
            nuevaBala.GetComponent<Bala>().AsignarDireccion(direccionDisparo);
        }

        // 3. Detectar el suelo (Rayo invisible hacia abajo)
     Debug.DrawRay(transform.position, Vector3.down * 1.0f, Color.red);
        if (Physics2D.Raycast(transform.position, Vector2.down, 1.0f))
        {
            enElSuelo = true;
        }
        else
        {
            enElSuelo = false;
        }

        // 4. Salto (Tecla W o Flecha Arriba)
        if ((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) && enElSuelo)
        {
            rb2d.AddForce(Vector2.up * fuerzaSalto);
        }
    }

    void FixedUpdate()
    {
        // Usamos rb2d.linearVelocity.y para no interrumpir el salto cuando caminamos
        rb2d.linearVelocity = new Vector2(horizontal * velocidad, rb2d.linearVelocity.y);
    }
}