using UnityEngine;
using UnityEngine.SceneManagement;

public class Alfombra : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Rita")
        {
            GameManager.Instance.escena = "Pueblo";
            GameManager.Instance.AmbientePlay(4);
            SceneManager.LoadScene("PantallaCarga");
        }
    }
}