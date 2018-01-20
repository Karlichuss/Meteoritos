using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InterfaceAwake : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        // Ponemos los contadores a cero
        GameManager.stonesDestroyed = 0;
        GameManager.stonesThrown = 0;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Click()
    {
        // Cargamos la escena del juego
        SceneManager.LoadScene("StoneGame");
    }
}