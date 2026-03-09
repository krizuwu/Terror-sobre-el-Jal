using UnityEngine;

public class MovimientoJuanCarlos : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private Animator anim;
    public float velocidad = 5f;
    private float horizontal;
    public GameObject prefabBala;
    void Start()
    {
        // Conectamos el código con los componentes de JuanCarlos
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        // Detecta si presionas las flechas del teclado o las letras A y D
        horizontal = Input.GetAxisRaw("Horizontal");

        // Activa la animación si nos estamos moviendo (si horizontal no es 0)
        if (horizontal != 0)
        {
            anim.SetBool("running", true);
            
            // Gira a JuanCarlos hacia donde camina
            if (horizontal < 0) transform.localScale = new Vector3(-1, 1, 1);
            else if (horizontal > 0) transform.localScale = new Vector3(1, 1, 1);
        }
        else
        {
            // Lo pone en Idle si soltamos la tecla
            anim.SetBool("running", false);
        }


        if (Input.GetKeyDown(KeyCode.Space))
        { Vector2 direccionDisparo = (transform.localScale.x == 1) ? Vector2.right : Vector2.left;
          Vector3 separacion = new Vector3(direccionDisparo.x * 1.5f, 0, 0); 
          Vector3 posicionAparicion = transform.position + separacion;

  
            GameObject nuevaBala = Instantiate(prefabBala, posicionAparicion, Quaternion.identity);
            nuevaBala.GetComponent<Bala>().AsignarDireccion(direccionDisparo);
        }
    }

    void FixedUpdate()
    {
        // Le aplica la fuerza física para moverlo
        rb2d.linearVelocity = new Vector2(horizontal * velocidad, rb2d.linearVelocity.y);
    }
}