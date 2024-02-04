using UnityEngine;
using UnityEngine.SceneManagement;

public class CargaManager : MonoBehaviour
{
    private float timerEspera = 1.31f;

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
        //Cuando acaba el timer carga la escena y cuando esta ha
        //acabado de cargar te llave a la escena correspondiente
        timerEspera -= Time.deltaTime;

        if (timerEspera <= 0)
        {
            AsyncOperation carga = SceneManager.LoadSceneAsync(GameManager.Instance.escena);//Esta es la función que se encarga de cargar la escena de fondo
        }
    }

}