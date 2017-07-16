using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vida : MonoBehaviour
{

    public int VidaTotal = 100;             //vida de la Galletota
    public int VidaActual;                  //vida actual que tiene

    private Animator Animacion;
    private Rigidbody2D Cuerpo;

    GalletotaAtacar galletotaAtacar;
    public bool EstaMuerto;                     //¿está muerto?
    public bool Dañado;                     //True cuando ha sido dañado

    // Use this for initialization
    void Start()
    {
        Animacion = GetComponent<Animator>();
        Cuerpo = GetComponent<Rigidbody2D>();
        galletotaAtacar = GetComponent<GalletotaAtacar>();

        VidaActual = VidaTotal;
    }

    // Update is called once per frame
    void Update()
    {
        if (Dañado)
        {
            SendMessage("UpdateState", "Daño");
        }
        Dañado = false;
    }

    public void RecibirDaño()
    {
        Dañado = true;

        //Reduce la vida, dependiendo de la cantidad de daño recibido
        //VidaActual -= CantidadDaño;

        //
        if (VidaActual <= 0 && !EstaMuerto)
        {
            Muerte();
            SendMessage("UpdateState", "Muerte");
        }
    }

    public void Muerte()
    {
        EstaMuerto = true;

        Animacion.SetTrigger("Die");

        galletotaAtacar.enabled = false;
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