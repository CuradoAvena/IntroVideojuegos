using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
public class MovimientoGreybox : MonoBehaviour
{
    [Header("Configuración de Movimiento")]
    public float velocidad = 6f;

    private Rigidbody rb;
    private Vector2 inputMovimiento;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        // Congelar la rotación en X y Z para que la cápsula no se caiga como un pino de boliche
        rb.constraints = RigidbodyConstraints.FreezeRotation;
    }

    private void Update()
    {
        // Leer WASD de forma directa
        float x = 0f; 
        float y = 0f;
        
        if (Keyboard.current.wKey.isPressed) y += 1f;
        if (Keyboard.current.sKey.isPressed) y -= 1f;
        if (Keyboard.current.dKey.isPressed) x += 1f;
        if (Keyboard.current.aKey.isPressed) x -= 1f;

        // Normalizar para que no se mueva más rápido en diagonal
        inputMovimiento = new Vector2(x, y).normalized;
    }

    private void FixedUpdate()
    {
        // Calcular el movimiento relativo hacia donde está mirando la cápsula
        Vector3 movimiento = (transform.right * inputMovimiento.x + transform.forward * inputMovimiento.y) * velocidad;
        
        // Aplicar el movimiento al Rigidbody
        rb.MovePosition(rb.position + movimiento * Time.fixedDeltaTime);
    }
}