using UnityEngine;

public class bolacontrole : MonoBehaviour
{
    private Rigidbody2D rb;

    [SerializeField]
    private float velocidade = 8f;

    [SerializeField]
    private float aumentoVelocidade = 0.5f;

    [SerializeField]
    private float velocidadeMaxima = 25f;

    //===================Metodos====================

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        //Iniciar a bola em um lado aleatorio
        float x = Random.value > 0.5f ? 1f : -1f;
        float y = Random.Range(-0.5f, 0.5f);

        rb.linearVelocity = new Vector2(x, y).normalized * velocidade;

    }

    private void FixedUpdate()
    {
        //Matem uma velocidade constante
        rb.linearVelocity =
            rb.linearVelocity.normalized * velocidade;

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("player")
           || collision.gameObject.CompareTag("Enemy"))
        {
            velocidade += aumentoVelocidade;

            if (velocidade > velocidadeMaxima)
            {

                velocidade = velocidadeMaxima;
            }

            //Descobrir o ponto de impacto da bolinha 
            float impactoY = transform.position.y - collision.transform.position.y;

            //definir direcao da bolina
            float direcaoX = collision.gameObject.CompareTag("player") ? 1f : -1f;

            //nova direcao da bolinha 
            Vector2 novaDirecao = new Vector2(direcaoX, impactoY).normalized;

            //aplicar nova velocidade a bolinha
            rb.linearVelocity = novaDirecao * velocidade;



        }

    }

}