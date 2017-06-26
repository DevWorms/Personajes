using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoLeche : MonoBehaviour
{

    private Animator animacion;

    public float Velocidad;

    private Rigidbody2D Cuerpo;

    public bool SeMueve;

    //Acciones que realizará el enemigo(Caminar, Esperar y Atacar)
    public float TiempoCaminando;
    private float ContadorCaminando;
    public float TiempoEspera;
    private float ContadorEspera;
    public float TiempoAtacando;
    private float ContadorAtacando;

    private int Accion;

	// Use this for initialization
	void Start ()
    {
        Cuerpo = GetComponent<Rigidbody2D>();
        animacion = GetComponent<Animator>();

        ContadorEspera = TiempoEspera;
        ContadorCaminando = TiempoCaminando;
        ContadorAtacando = TiempoAtacando;       

        EscogerAccion();        
    }
	
	// Update is called once per frame
	void Update ()
    {
		if(SeMueve)
        {
            ContadorCaminando -= Time.deltaTime;
            ContadorAtacando -= Time.deltaTime;

            switch (Accion)
            {
                case 0:
                    Cuerpo.velocity = new Vector2(0, 0);
                    SendMessage("UpdateState", "LecheParada");
                    break;

                case 1:
                    Cuerpo.velocity = new Vector2(Velocidad, 0);
                    SendMessage("UpdateState", "LecheCaminar");
                    break;

                case 2:
                    Cuerpo.velocity = new Vector2(0, 0);
                    SendMessage("UpdateState", "LecheAtacar");
                    if (ContadorAtacando <= 0)
                    {
                        SeMueve = false;
                        ContadorAtacando = TiempoAtacando;
                    }
                    break;
            }                        
            
            if(ContadorCaminando <= 0)
            {
                SeMueve = false;
                ContadorEspera = TiempoEspera;
            }
            
        }
        else
        {
            ContadorEspera -= Time.deltaTime;
            if(ContadorEspera <= 0)
            {
                EscogerAccion();
            }
        }
	}

    //determinará que acción realizará el enemigo
    public void EscogerAccion()
    {
        Accion = Random.Range(0, 3); //Número aleatorio que determinará la acción
        SeMueve = true; // 
        ContadorCaminando = TiempoCaminando; 
    }


    //método el cual cambiará las animaciones de cada acción
    public void UpdateState(string state = null)
    {
        if(state != null)
        {
            animacion.Play(state);
        }
    }
}
