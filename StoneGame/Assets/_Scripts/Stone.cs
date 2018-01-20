using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stone : MonoBehaviour {

    public GameObject explosion;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        // Si la piedra sale de la zona de vision del jugador por debajo de cierta altura
		if (transform.position.y < -30)
        {
            // Destruimos esa piedra
            Destroy(gameObject);
        }
	}

    // Cuando se hace click sobre una piedra
    void OnMouseDown()
    {
        // Instanciamos la explosion
        Instantiate(explosion, transform.position, Quaternion.identity);
        // Destruimos esa piedra
        Destroy(gameObject);
        // Incrementamos la puntuacion
        GameManager.stonesDestroyed++;
    }
}
