using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainLoop : MonoBehaviour
{
    // Array que recupera los 3 prefabs Stone
    public GameObject[] stones = new GameObject[3];
    // Fuerza de torsion de giro de las piedras
    public float torque = 0.5f;
    // Fuerza de lanzamiento de las piedras
    public float minAntiGravity = 20.0f, maxAntiGravity = 40.0f;
    // Fuerza lateral de lanzamiento de las piedras
    public float minLateralForce = -15.0f, maxLateralForce = 15.0f;
    // Tiempo de espera entre cada lanzamiento de una piedra
    public float minTimeBetweeenStone = 1f, maxTimeBetweeenStone = 3f;
    // Posicion X del lanzamiento de la piedra
    public float minX = -30.0f, maxX = 30.0f;
    // Posicion Z del lanzamiento de la piedra
    public float minZ = -5.0f, maxZ = 5.0f;
    // Permitir que se lancen piedras
    private bool enableStones = true;
    // Cantidad de piedras destruidas necesarias para que se acabe la partida
    public int amountStones = 20;

    private Rigidbody rigidbody;

    // Use this for initialization
    void Start()
    {
        StartCoroutine(ThrowStones());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator ThrowStones()
    {

        // Time.timeScale = 3;

        // Pausamos el hilo por 3 segundos
        yield return new WaitForSeconds(3.0f);

        // Mientras enableStones sea true
        while (enableStones)
        {
            // Instanciamos una nueva piedra
            GameObject stone = Instantiate(stones[Random.Range(0, stones.Length)]);

            // Le damos una trayectoria y rotacion aleatorias
            stone.transform.position = new Vector3(Random.Range(minX, maxX), -30, Random.Range(minZ, maxZ));
            stone.transform.rotation = Random.rotation;

            // La lanzamos al aire
            rigidbody = stone.GetComponent<Rigidbody>();
            rigidbody.AddTorque(Vector3.up * torque, ForceMode.Impulse);
            rigidbody.AddTorque(Vector3.right * torque, ForceMode.Impulse);
            rigidbody.AddTorque(Vector3.forward * torque, ForceMode.Impulse);

            rigidbody.AddForce(Vector3.up * Random.Range(minAntiGravity, maxAntiGravity), ForceMode.Impulse);
            rigidbody.AddForce(Vector3.right * Random.Range(minLateralForce, maxLateralForce), ForceMode.Impulse);

            // Incrementamos el contador de piedras lanzadas
            GameManager.stonesThrown++;

            // Si el numero de piedras lanzadas alcanza su limite
            if (GameManager.stonesThrown == amountStones)
            {
                // Dejamos de entrar en el bucle
                enableStones = false;
                // Pausamos el hilo por 6 segundos
                yield return new WaitForSeconds(6.0f);
            }
            else
            {
                // Pausamos el hilo por un tiempo aleatorio dentro de lo programado y volvemos a lanzar otra piedra
                yield return new WaitForSeconds(Random.Range(minTimeBetweeenStone, maxTimeBetweeenStone));
            }
        }

        // Cuando se sale del bucle, cargamos la escena Final
        SceneManager.LoadScene("Final");
    }
}