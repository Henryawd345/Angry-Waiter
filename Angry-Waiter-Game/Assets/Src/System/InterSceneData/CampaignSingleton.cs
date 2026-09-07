using UnityEngine;

public class CampaignSingleton : MonoBehaviour
{
    public float money {get; private set;}
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}
