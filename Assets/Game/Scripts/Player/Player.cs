using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private float _health;

    public event UnityAction<float> HealthChanged;
    public event UnityAction Died;
    private void Start()
    {
        HealthChanged?.Invoke(_health);
    }

    public void TakeDamage(float damage)
    {
        _health -= damage;
        HealthChanged?.Invoke(_health);
        
        if (_health <= 0)
            Die();
    }

    private void Die()
    {
        Died?.Invoke();
    }
}
