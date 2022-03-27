
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermovement : MonoBehaviour
{
    public float movespeed;

    public Rigidbody2D rb;
    public Camera cam;
    public GameObject gr; //Ссылка на объект Grab

    public bool objInHand = true; //Есть ли в руке объект или нет

    Vector2 movement;
    Vector2 mousePos;

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetButtonDown("Fire1") && objInHand == true) //Если нажать Лкм и если в руки есть объект
        {
            //gr.GetComponent<GrabMove>().Destroy(fixedJoint);
            Debug.Log("Коронный"); // Просто проверка
            gr.GetComponent<GrabMove>().Shoot(); //Выполнение функции из объекта Grab (скрипт GrabMove)
            objInHand = false; //После выстрела в руках ничего нет
        }
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * movespeed * Time.fixedDeltaTime); //Тут какая-то движуха. Скопировал не помню че здесь

        Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
    }
}
