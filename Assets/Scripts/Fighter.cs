using UnityEngine;

public class Fighter : MonoBehaviour
{
    Fighter luchador;

    public string nombre;
    public string category;
    public int health;

    public Fighter(string nombre, string category, int healt)
    {
        this.nombre = nombre;
        this.category = category;
        this.health = healt;
    }

    //muestra los datos del Fighter
    public string MuestraInfoLuchador()
    {
        return ("Nombre: " + this.nombre + " / Categoria: " + this.category + " / Vida: " + this.health);
    }

    //quita vida al Fighter
    public void DecreaseHealth(int quitarVida)
    {
        this.health -= quitarVida;
    }

    //consulta si un Fighter está vivo
    public bool IsAlive()
    {
        bool estaVivo;
        if (this.luchador.health > 0) estaVivo = true;
        else estaVivo = false;

        return estaVivo;
    }



    // OJO!!! revisar esto....
    //EJERCICIO 12:
    //cuando el Fighter muere notifica al GO que ha muerto
    //public Fighter NotificaMuerto() {

    //if(this.health==0) return luchador;
    //}




    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {

    }
}
