using System.Collections.Generic;
using UnityEngine;

public class Sombra : MonoBehaviour
{
    [Header("Configurações de Perseguição")]
    public float velocidadePerseguir = 7f;
    public float suavizacaoMovimento = 0.1f;
    public float tempoIniciar = 1.5f;
    
    private Transform alvo;
    private Rigidbody2D rb;
    public Player playerScript;
    private Vector2 movimento;
    private Vector2 velocidadeRef;
    private Queue<Vector3> positionQueue = new();

    void Start()
    {
      
    }

    void FixedUpdate()
    {
        positionQueue.Enqueue(playerScript.transform.position);
        if (tempoIniciar <= 0)
        {
            var position = positionQueue.Dequeue();
            transform.position = position;
        }
        tempoIniciar -= Time.deltaTime;
    }
    
  
}