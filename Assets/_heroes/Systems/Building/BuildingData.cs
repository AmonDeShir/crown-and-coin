using UnityEngine;

[CreateAssetMenu(fileName = "BuildingData", menuName = "Data/Building")]
public class BuildingData : ScriptableObject, IDamageableData
{
    [SerializeField]
    private string m_name;
    
    [SerializeField]
    private int m_cost;

    [Header("HP")]
    [SerializeField]
    private float m_health;
    
    [SerializeField]
    private float m_startHealth = 50f;

    [SerializeField]
    [Tooltip("Health regeneration per second")]
    private float m_HealthRegeneration = 10f;
    
    [Header("Prefab")]
    [SerializeField]
    private GameObject m_prefab;

    public string Name => m_name;
    public int Cost => m_cost;
    public float MaxHealth => m_health;
    public float SpawnHealth => m_startHealth ;
    public float HealthRegeneration => m_HealthRegeneration;

    public GameObject Prefab => m_prefab;
}
