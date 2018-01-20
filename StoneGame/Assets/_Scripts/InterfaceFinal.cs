using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InterfaceFinal : MonoBehaviour
{
    public Text textThrown;
    public Text textDestroyed;

    // Use this for initialization
    void Start()
    {
        // Mostramos la puntuacion final
        textThrown.text = string.Format("Number of Stones thrown: {0}", GameManager.stonesThrown.ToString());
        textDestroyed.text = string.Format("Number of Stones destroyed: {0}", GameManager.stonesDestroyed.ToString());
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnClick()
    {
        // Volvemos a poner los contadores a cero
        GameManager.stonesThrown = 0;
        GameManager.stonesDestroyed = 0;
        // Cargamos la escena del juego
        SceneManager.LoadScene("StoneGame");
    }

}
