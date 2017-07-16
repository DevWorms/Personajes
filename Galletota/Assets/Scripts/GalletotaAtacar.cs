using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GalletotaAtacar : MonoBehaviour
{
    public float TiempoEntreAtaque = 0.5f;
    public int DañoAtaque = 10;

    private Animator Animacion;
    private Rigidbody2D Cuerpo;
    private GameObject Galleta;

    GameObject player;
    bool JugadorEnRango;
    float timer;

    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        Animacion = GetComponent<Animator>();
        Cuerpo = GetComponent<Rigidbody2D>();
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            JugadorEnRango = true;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player)
        {
            JugadorEnRango = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (timer >= TiempoEntreAtaque && JugadorEnRango)
        {
            Ataque();
            SendMessage("UpdateState", "Atacar");
        }
    }

    public void Ataque()
    {
        timer = 0f;


    }

    //método el cual cambiará las animaciones de cada acción
    public void UpdateState(string state = null)
    {
        if (state != null)
        {
            Animacion.Play(state);
        }
    }
}