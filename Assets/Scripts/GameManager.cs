using UnityEngine;

public class GameManager : MonoBehaviour
{

    public GameObject fighter;

    // Start is called before the first frame update
    void Start()
    {
        Fighter luchador = fighter.GetComponent<Fighter>();


        //Debug.Log("[GM] el nombre del luchador es: " + fighter.GetComponent<Fighter>().nombre);
        //Debug.Log("[GM] la categoría es: "+ fighter.GetComponent<Fighter>().category);
        //Debug.Log("[GM] la vida es: " + fighter.GetComponent<Fighter>().health);


        Debug.Log("[GM] el nombre del luchador es: " + luchador.nombre);
        Debug.Log("[GM] la categoría es: " + luchador.category);
        Debug.Log("[GM] la vida es: " + luchador.health);

    }

    // Update is called once per frame
    void Update()
    {

    }
}
