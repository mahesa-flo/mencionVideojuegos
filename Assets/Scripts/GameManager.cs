using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public GameObject fighter1;
    public GameObject fighter2;
    public GameObject fighter3;
    public GameObject fighter4;
    public GameObject fighter5;

    Fighter fighterMasVida;
    List<Fighter> listaMuertos = new List<Fighter>();
    List<Fighter> listaLuchadoresRandom = new List<Fighter>();

    //función para crear Lista de Fighters --> todos tendrán la misma vida (health)
    public List<Fighter> InitFighters(List<string> listaNombres, List<string> listaCategorias, int health)
    {
        List<Fighter> listaLuchadores = new List<Fighter>();
        for (int i = 0; i < listaNombres.Count; i++)
        {
            listaLuchadores.Add(new Fighter(listaNombres[i], listaCategorias[i], health));
        }

        return listaLuchadores;
    }


    //función para crear Lista de Fighters --> cada uno tendrá una vida random entre 80 y 100
    public List<Fighter> InitFightersRandom(List<string> listaNombres, List<string> listaCategorias, int vidaMinima, int vidaMaxima)
    {

        List<Fighter> listaLuchadores = new List<Fighter>();
        for (int i = 0; i < listaNombres.Count; i++)
        {
            int healthRandom = Random.Range(vidaMinima, vidaMaxima);
            listaLuchadores.Add(new Fighter(listaNombres[i], listaCategorias[i], healthRandom));
        }

        return listaLuchadores;
    }



    //función para obtener el Fighter con mayor vida.
    public Fighter personajeMasVida(List<Fighter> listaLuchadores)
    {

        int health = 0;
        foreach (Fighter luchador in listaLuchadores)
        {
            if (luchador.health > health)
            {
                fighterMasVida = luchador;
                health = luchador.health;
            }

        }
        return fighterMasVida;
    }

    //función que devuelve la lista con personajes muertos
    public List<Fighter> Deaths(List<Fighter> listaLuchadores)
    {

        foreach (Fighter luchador in listaLuchadores)
        {
            bool luchadorMuerto = luchador.IsAlive();
            if (luchadorMuerto == true)
            {
                listaMuertos.Add(luchador);
            }
        }

        return listaMuertos;
    }

    //cuando un Fighter notifique que ha muerto, lo anyado a la listaMuertos 
    public void AnyadirMuerto(Fighter fighter)
    {
        listaMuertos.Add(fighter);
    }

    // Start is called before the first frame update
    void Start()
    {

        List<string> listaNombres = new List<string>();
        listaNombres.Add("Scorpion");
        listaNombres.Add("Kano");
        listaNombres.Add("Sonya");
        listaNombres.Add("Johnny Cage");
        listaNombres.Add("Sub-Zero");

        List<string> listaCategorias = new List<string>();
        listaCategorias.Add("Ninja");
        listaCategorias.Add("Mercenario");
        listaCategorias.Add("Teniente");
        listaCategorias.Add("Actor");
        listaCategorias.Add("Ninja");


        // EJERCICIOS del 4 al 7: crear lista de luchadores llamando a la función InitFighters()
        //int healthLuchadores = 100;
        //List<Fighter> listaLuchadores = InitFighters(listaNombres, listaCategorias, healthLuchadores);
        //foreach (Fighter luchador in listaLuchadores)
        //{
        //    Debug.Log(luchador.InfoLuchador());
        //}



        // EJERCICIOS del 8 al 12: crear lista de luchadores llamando a la función InitFightersRandom(), obtener personaje con más vida

        listaLuchadoresRandom = InitFightersRandom(listaNombres, listaCategorias, 80, 100);

        Debug.Log("-------------------LISTADO DE FIGHTERS-------------------");
        foreach (Fighter luchador in listaLuchadoresRandom)
        {
            Debug.Log(luchador.MuestraInfoLuchador());
        }

        Debug.Log("El luchador con más vida es -->  " + personajeMasVida(listaLuchadoresRandom).MuestraInfoLuchador());


        
        
        // OJO!! revisar esto..... y el Update() para ver como notifica el personaje al GO cuando se queda sin vida...
        listaLuchadoresRandom[1].DecreaseHealth(100);

        Debug.Log("------------LISTADO DE FIGHTERS MUERTOS------------------");
        
        foreach (Fighter fighter in listaMuertos)
        {
            fighter.MuestraInfoLuchador();
        }


    }






    // Update is called once per frame
    void Update()
    {

        foreach (Fighter luchador in listaLuchadoresRandom)
        {
            if (luchador.IsAlive()==false) AnyadirMuerto(luchador);
        }



    }
}
