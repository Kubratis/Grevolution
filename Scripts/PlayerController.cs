using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float walkSpeed = 0.5f;
    public float runSpeed = 6f;
    public Transform camTransform; // Kameran�n transformu
    private Animator playerAnim;
    private float moveSpeed;
    private float walkSpeedMultiplier = 1f;

    void Start()
    {
        playerAnim = GetComponent<Animator>();
        // Kameran�n transformunu al
        if (Camera.main != null)
        {
            camTransform = Camera.main.transform;
        }
    }

    void Update()
    {
        // Yatay ve dikey hareket giri�lerini al
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Kameran�n y�n�ne g�re hareket vekt�r�n� olu�tur
        Vector3 moveDirection = camTransform.forward * verticalInput + camTransform.right * horizontalInput;
        moveDirection.y = 0f; // Y eksenindeki hareketi s�f�rla (yatayda hareket etmek i�in)

        // Hareketi normalle�tir ve h�zla �arp
        moveDirection.Normalize();
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime, Space.World);

        // Player karakterinin y�n�n� kameran�n y�n�ne do�ru d�nd�r
        if (moveDirection != Vector3.zero)
        {
            Quaternion newRotation = Quaternion.LookRotation(moveDirection);
            transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, Time.deltaTime * 10f);
        }

        // Y�r�me ve ko�ma animasyonlar�
        UpdateAnimation(moveDirection.magnitude);
    }

    void UpdateAnimation(float speed)
    {
        // Y�r�me ve ko�ma h�z�n� belirle
        moveSpeed = walkSpeed * walkSpeedMultiplier;
        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.W))
        {
            walkSpeedMultiplier = Mathf.Lerp(walkSpeedMultiplier, runSpeed / walkSpeed, Time.deltaTime * 5f);
        }
        else
        {
            walkSpeedMultiplier = Mathf.Lerp(walkSpeedMultiplier, 1f, Time.deltaTime * 5f);
        }

        // Y�r�me ve ko�ma animasyonlar�n� kontrol et
        playerAnim.SetFloat("hiz", speed * moveSpeed);
    }
}
