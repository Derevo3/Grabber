using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed;
    public int positionOfPatrol;
    public Transform point;
    public Rigidbody2D rb;
    public Rigidbody2D grab;

    bool active = true;
    bool moveingRight;

    void Start()
    {
        
    }

    void Update()
    {
        if (active == true)
        {
            Chill();
        }
    }

    void Chill() //��������� �����
    {
        if (transform.position.x > point.position.x + positionOfPatrol) //���� ���������� ������� ������ ���������� �� ����� ������� �� ���� �������, �� ������� � ������� ����
        {
            moveingRight = false;
        }
        else if (transform.position.x < point.position.x - positionOfPatrol) //�����, �� ����, ������� �� ��
        {
            moveingRight = true;
        }

        if (moveingRight) //������� ����-����
        {
            transform.position = new Vector2(transform.position.x + speed * Time.deltaTime, transform.position.y);
        }
        else
        {
            transform.position = new Vector2(transform.position.x - speed * Time.deltaTime, transform.position.y);
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Grab")
        {
            Debug.Log("�����");
            rb.gameObject.AddComponent<FixedJoint2D>().connectedBody = grab;
            active = false;
        }
    }

    /*void ActiveOff()
    {
        active = false;
        //����� ���� ����� ������� �������� � ����, �������� ����� Joint
        //������ ��������� ��� �������, ������� � ������ ����
        //�� � �������� ������� ������, ���� ������ � ��������
    }*/
}
