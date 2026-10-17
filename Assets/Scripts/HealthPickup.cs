using UnityEngine;
//Definiremos Componente2D 
[RequireComponent(typeof(Collider2D))]
public class HealthPickup : MonoBehaviour
{
  
  //Utilizamos [SerializedField] para que la variable floatHealthAmount sea visible en el inspector
  // y lo hacemos decimal con el fin de que esta sea visible, para modificar parámetros
   [SerializeField] float healthAmount = 25f; //
  // Aplicamos Start, y definimos un Collider2D, puesto que estamos recurriendo a una imagen
    private void Start()
    {
        // El Collider tiene que ser 2D, para que nuestro player detecte la imagen
        Collider2D col = GetComponent<Collider2D>();
        col.isTrigger = true;
    }
    // Aplicamos OnTriggerEnter2D, pra que al momento de chocar, la imagen pueda detectar código
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Comprobamos si el objeto que entra tiene el componente Health (por ejemplo, el Player)
        Health otherHealth = collision.GetComponent<Health>();

        if (otherHealth != null)
        {
            // Para que el script funcione, ,la salud tiene que ser menor que la salud original 
            if (otherHealth.CurrentHealth < otherHealth.MaxHealth)
            {
                otherHealth.IncreaseHealth(healthAmount); // Llamaremos al método "Health" y lo HAREMOS público para reconoce este script y se ejecute y proceda a modificar el valor de vida puesto que se encuentra en "Health"
                Destroy(gameObject); // Destruirá el objeto NADA mas tocado
            }
        }
    }
}