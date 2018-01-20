using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InterfaceStone : MonoBehaviour {

    public Text textThrown;
    public Text textDestroyed;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Actualizamos la puntuacion con los valores de los contadores
        textThrown.text = string.Format("Number of Stones: {0}", GameManager.stonesThrown);
        textDestroyed.text = string.Format("Stones destroyed: {0}", GameManager.stonesDestroyed);
    }
}
