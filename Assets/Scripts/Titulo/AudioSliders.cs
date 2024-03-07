using UnityEngine;
using UnityEngine.UI;

public class AudioSliders : MonoBehaviour
{
    [SerializeField] private Slider slider;

    private void Start()
    {
        slider = GetComponent<Slider>();
    }

    private void Update()
    {
        Debug.Log("WTF");
        if (GameManager.Instance.reiniciando == true)
        {
            Debug.Log("Entrado");
            //Resetea el gameObject slider
            slider.value = 0.5f;
        }
    }
}
