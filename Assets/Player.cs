using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Configurações de Movimento")]
    public float moveSpeed = 5f;
    public float jumpTime = 0.1f;
    public float jumpForce = 5f;
    private float jumpRemainingTime = 0f;
    bool isJump;

    private Rigidbody2D rb;
    private Vector2 movementInput;

    [Header("Histórico de Posições")]
    public List<Vector2> positionHistory = new List<Vector2>();
    public List<float> timeHistory = new List<float>();
    public float recordTime = 5f;
    public float recordInterval = 0.1f;
    private float lastRecordTime = 0f;

    void Start()
    {
    rb = GetComponent<Rigidbody2D>();    
    }

    void Update()
    {
      movementInput.x = Input.GetAxisRaw("Horizontal");
      isJump = Input.GetButtonDown("Jump");
      if (isJump == true){
        jumpRemainingTime = jumpTime;
      }
      if (Time.time - lastRecordTime >= recordInterval) {
        positionHistory.Add(transform.position);
        timeHistory.Add(Time.time);
        lastRecordTime = Time.time;
        CleanupOldRecords();
      } 
      if (jumpRemainingTime > 0){
        jumpRemainingTime -= Time.deltaTime;
      }
    }
    void CleanupOldRecords()
    {
        while (timeHistory.Count > 0 && Time.time - timeHistory[0] > recordTime)
        {
            timeHistory.RemoveAt(0);
            positionHistory.RemoveAt(0);
            
        }
    }
    void FixedUpdate()
    {
        Vector2 frameVelocity = default;

        if (jumpRemainingTime > 0) {
        Vector2 verticalForce = new Vector2(0,1);
        frameVelocity += (verticalForce * jumpForce);  

        }



        
            frameVelocity += movementInput.normalized * moveSpeed;
       rb.velocity = frameVelocity;     

    }
}
