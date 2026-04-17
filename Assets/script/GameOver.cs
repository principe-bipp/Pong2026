using TMPro;
using UnityEngine;
using System.Collections;
public class GameOver : MonoBehaviour
{

    public TextMeshProUGUI textoGame;
    public string textoVitoria;
    public float tempoParaReiniciar = 3f;

    private void OnCollisionEnter2D(Collision2D collision)
    {

        textoGame.text = $"Pong win {textoVitoria} !";
        textoGame.gameObject.SetActive(true);

        Destroy(collision.gameObject);
        StartCoroutine(ReiniciarDepoisDeTempo());
    }
    IEnumerator ReiniciarDepoisDeTempo()
    {
        yield return new WaitForSeconds(tempoParaReiniciar);
        UnityEditor.EditorApplication.isPlaying = false;


    }
    


}
