using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabMove : MonoBehaviour
{
    public Transform grabPoint; //Точка возврата граба
    public Rigidbody2D rb;
    public Rigidbody2D player;
    public float grabForce;
    public float grabForce2;
    public GameObject playerGO;
    public Camera cam;

    // bool objBack = false; //Состояние возвращения, хз нужно ли оно (пока что нет)

    void Start()
    {

    }

    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D col) //Условие коллыжына
    {
        Vector2 grabPoint2 = grabPoint.position - transform.position; //Рассчёт точки возврата
        rb.AddForce(grabPoint2 * grabForce2, ForceMode2D.Impulse); //Толчок граба с игроку
        Debug.Log("Попадание");
        if (col.gameObject.tag == "Player")
        {
            Debug.Log("Стыковка");
            rb.gameObject.AddComponent<FixedJoint2D>().connectedBody = player;
            //FixedJoint2D.breakForce = 100;
            playerGO.GetComponent<playermovement>().objInHand = true;
        }
    }

    public void Shoot() //Собственно выстрел и дебаг (нравится писать "дебаг" типа программист дофига)
    {
        Debug.Log("Похоронный");
        Vector2 mousePos = (cam.ScreenToWorldPoint(Input.mousePosition) - transform.position);
        rb.AddForce(mousePos * grabForce, ForceMode2D.Impulse);
    }

}