using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float walkSpeed = 0.5f;
    public float runSpeed = 6f;
    public Transform camTransform; // Kameranýn transformu
    private Animator playerAnim;
    private float moveSpeed;
    private float walkSpeedMultiplier = 1f;

    void Start()
    {
        playerAnim = GetComponent<Animator>();
        // Kameranýn transformunu al
        if (Camera.main != null)
        {
            camTransform = Camera.main.transform;
        }
    }

    void Update()
    {
        // Yatay ve dikey hareket giriþlerini al
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Kameranýn yönüne göre hareket vektörünü oluþtur
        Vector3 moveDirection = camTransform.forward * verticalInput + camTransform.right * horizontalInput;
        moveDirection.y = 0f; // Y eksenindeki hareketi sýfýrla (yatayda hareket etmek için)

        // Hareketi normalleþtir ve hýzla çarp
        moveDirection.Normalize();
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime, Space.World);

        // Player karakterinin yönünü kameranýn yönüne doðru döndür
        if (moveDirection != Vector3.zero)
        {
            Quaternion newRotation = Quaternion.LookRotation(moveDirection);
            transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, Time.deltaTime * 10f);
        }

        // Yürüme ve koþma animasyonlarý
        UpdateAnimation(moveDirection.magnitude);
    }

    void UpdateAnimation(float speed)
    {
        // Yürüme ve koþma hýzýný belirle
        moveSpeed = walkSpeed * walkSpeedMultiplier;
        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.W))
        {
            walkSpeedMultiplier = Mathf.Lerp(walkSpeedMultiplier, runSpeed / walkSpeed, Time.deltaTime * 5f);
        }
        else
        {
            walkSpeedMultiplier = Mathf.Lerp(walkSpeedMultiplier, 1f, Time.deltaTime * 5f);
        }

        // Yürüme ve koþma animasyonlarýný kontrol et
        playerAnim.SetFloat("hiz", speed * moveSpeed);
    }
}
