using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _damage;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out Player player))
        {
            player.TakeDamage(_damage);
        }
        Die();
    }

    private void Die()
    {
        gameObject.SetActive(false);
    }
}
