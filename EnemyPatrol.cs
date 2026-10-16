using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    [SerializeField] private float patrolDistance = 3f;
    [SerializeField] private float moveSpeed = 2f;
    [SerializeField] private string playerTag = "Player";

    private Vector3 startPos;
    private int direction = 1; // 1 a la derecha, -1 a la izquierda

    private void Start()
    {
        startPos = transform.position;
    }

    private void Update()
    {
        transform.position += Vector3.right * direction * moveSpeed * Time.deltaTime;

        float distanceFromStart = transform.position.x - startPos.x;

        if (distanceFromStart > patrolDistance)
        {
            direction = -1;
        }
        else if (distanceFromStart < -patrolDistance)
        {
            direction = 1;
        }
    }

    // --- AGREGA ESTE BLOQUE ---
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(playerTag))
        {
            FallRespawn playerRespawn = other.GetComponent<FallRespawn>();
            if (playerRespawn != null)
            {
                playerRespawn.TriggerRespawn();
            }
        }
    }
}
