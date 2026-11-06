using UnityEngine;
using UnityEngine.InputSystem;

public class InteraccionGreybox : MonoBehaviour
{
    [Header("Feedback Visual")]
    public Material materialBase; // Material blanco normal
    public Material materialResaltado; // Material amarillo/brillante para indicar que es interactuable
    
    private MeshRenderer meshRenderer;
    private bool jugadorEnZona = false;

    private void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        meshRenderer.material = materialBase;
    }

    private void Update()
    {
        // Si el jugador está dentro del Trigger y presiona la tecla 'E'
        if (jugadorEnZona && Keyboard.current.eKey.wasPressedThisFrame)
        {
            EjecutarAccion();
        }
    }

    // Cuando la cápsula del jugador ENTRA a la caja verde
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            jugadorEnZona = true;
            meshRenderer.material = materialResaltado; // El cubo "brilla", indicando que se puede usar
        }
    }

    // Cuando la cápsula del jugador SALE de la caja verde
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            jugadorEnZona = false;
            meshRenderer.material = materialBase; // El cubo regresa a la normalidad
        }
    }

    private void EjecutarAccion()
    {
        Debug.Log("¡Interacción exitosa!");
        
        // Aquí es donde los alumnos pueden ponerse creativos más adelante:
        // - Encender una luz
        // - Disparar un sistema de partículas
        // - Reproducir un sonido
        
        // Recompensa visual inmediata para el greybox: el cubo crece un poco
        transform.localScale = Vector3.one * 1.5f; 
    }
}
