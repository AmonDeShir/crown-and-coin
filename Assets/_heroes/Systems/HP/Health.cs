using TNRD;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [SerializeField] 
    private SerializableInterface<IDamageableData> m_data;
    public IDamageableData Data => m_data.Value;
    
    public float HealthPoints { get; private set; }
    public float RegenerationSpeed { get; private set; }
    
    public bool IsDead => HealthPoints <= 0f;
    
    public UnityEvent<float> OnDamaged;
    public UnityEvent<float> OnHpChanged;
    public UnityEvent OnDeath;

    private void Awake()
    {
        OnDamaged ??= new UnityEvent<float>();
        OnHpChanged ??= new UnityEvent<float>();
        OnDeath ??= new UnityEvent();

        HealthPoints = Data.MaxHealth;
        RegenerationSpeed = Data.HealthRegeneration;
    }
    
    private void Update()
    {
        if (CanRegenerate())
        {
            HealthPoints = Mathf.Min(HealthPoints + RegenerationSpeed * Time.deltaTime, Data.MaxHealth);
        }
    }

    private bool CanRegenerate()
    {
        return !IsDead && HealthPoints < Data.MaxHealth && RegenerationSpeed > 0f;
    }

    public void TakeDamage(float damage)
    {
        if (IsDead || damage <= 0f)
        {
            return;
        }
        
        HealthPoints = Mathf.Clamp(HealthPoints - damage, 0, Data.MaxHealth);
        
        OnDamaged.Invoke(damage);
        OnHpChanged.Invoke(HealthPoints);
        
        if (IsDead)
        {
            OnDeath.Invoke();
        }
    }

    public void Heal(float heal)
    {
        if (IsDead || heal <= 0f)
        {
            return;
        }
        
        HealthPoints = Mathf.Clamp(HealthPoints + heal, 0, Data.MaxHealth);
        OnHpChanged.Invoke(HealthPoints);
    }
}