using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabMove : MonoBehaviour
{
    public Transform grabPoint; //����� �������� �����
    public Rigidbody2D rb;
    public Rigidbody2D player;
    public float grabForce;
    public float grabForce2;
    public GameObject playerGO;
    public Camera cam;

    // bool objBack = false; //��������� �����������, �� ����� �� ��� (���� ��� ���)

    void Start()
    {

    }

    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D col) //������� ���������
    {
        Vector2 grabPoint2 = grabPoint.position - transform.position; //������� ����� ��������
        rb.AddForce(grabPoint2 * grabForce2, ForceMode2D.Impulse); //������ ����� � ������
        Debug.Log("���������");
        if (col.gameObject.tag == "Player")
        {
            Debug.Log("��������");
            rb.gameObject.AddComponent<FixedJoint2D>().connectedBody = player;
            //FixedJoint2D.breakForce = 100;
            playerGO.GetComponent<playermovement>().objInHand = true;
        }
    }

    public void Shoot() //���������� ������� � ����� (�������� ������ "�����" ���� ����������� ������)
    {
        Debug.Log("����������");
        Vector2 mousePos = (cam.ScreenToWorldPoint(Input.mousePosition) - transform.position);
        rb.AddForce(mousePos * grabForce, ForceMode2D.Impulse);
    }

}