using UnityEngine;
using UnityEngine.InputSystem;

public class CamaraGreybox : MonoBehaviour
{
    [Header("Configuración de Cámara")]
    public float sensibilidadMouse = 15f;
    public Transform cuerpoJugador; // Arrastrar la Cápsula aquí en el Inspector

    private float rotacionX = 0f;

    private void Start()
    {
        // Ocultar y bloquear el cursor en el centro de la pantalla
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        // Leer el movimiento del mouse
        Vector2 deltaMouse = Mouse.current.delta.ReadValue();

        float mouseX = deltaMouse.x * sensibilidadMouse * Time.deltaTime;
        float mouseY = deltaMouse.y * sensibilidadMouse * Time.deltaTime;

        // Calcular la rotación vertical (mirar arriba/abajo) e invertir el eje Y
        rotacionX -= mouseY;
        // Limitar la rotación para que no dé una vuelta de 360 grados sobre su propio cuello
        rotacionX = Mathf.Clamp(rotacionX, -90f, 90f);

        // Aplicar rotación vertical a la cámara
        transform.localRotation = Quaternion.Euler(rotacionX, 0f, 0f);
        
        // Aplicar rotación horizontal a todo el cuerpo del jugador (la cápsula)
        cuerpoJugador.Rotate(Vector3.up * mouseX);
    }
}
