
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermovement : MonoBehaviour
{
    public float movespeed;

    public Rigidbody2D rb;
    public Camera cam;
    public GameObject gr; //������ �� ������ Grab

    public bool objInHand = true; //���� �� � ���� ������ ��� ���

    Vector2 movement;
    Vector2 mousePos;

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetButtonDown("Fire1") && objInHand == true) //���� ������ ��� � ���� � ���� ���� ������
        {
            //gr.GetComponent<GrabMove>().Destroy(fixedJoint);
            Debug.Log("��������"); // ������ ��������
            gr.GetComponent<GrabMove>().Shoot(); //���������� ������� �� ������� Grab (������ GrabMove)
            objInHand = false; //����� �������� � ����� ������ ���
        }
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * movespeed * Time.fixedDeltaTime); //��� �����-�� �������. ���������� �� ����� �� �����

        Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
    }
}
