using UnityEngine;
using UnityEngine.SceneManagement;

public class CargaManager : MonoBehaviour
{
    private float timerEspera = 2.1f;

    private static CargaManager instance;
    public static CargaManager Instance
    {
        get { return instance; }
    }

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);

        //Si está sonando algún sonido, que no música a la hora de que empiece a
        //la pantalla de carga este sonido se para
        GameManager.Instance.SonidoStop();
    }

    private void Update()
    {
        //Hay un timer para cambiar de escena, ya que la barra es una animación,
        //lo que se hace es que este timer cuando llega a 0 la barra ya ha llegado
        //al máximo, asique cambiamos ya a la nueva escena
        timerEspera -= Time.deltaTime;

        if (timerEspera <= 0)
        {
            SceneManager.LoadScene(GameManager.Instance.escena);
        }
    }

}