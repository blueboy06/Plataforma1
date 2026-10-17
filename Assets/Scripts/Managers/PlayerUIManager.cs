using UnityEngine;
using UnityEngine.UI;

public class PlayerUIManager : MonoBehaviour
{
    public static PlayerUIManager Instance;

    [SerializeField] private Image healthFill;
    [SerializeField] private GameObject playerGO;

    private Health playerHealth;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(this);
        }

        playerHealth = playerGO.GetComponent<Health>();
    }

    public void ChangeHealthBarFill()
    {
        healthFill.fillAmount = playerHealth.CurrentHealth/playerHealth.MaxHealth;
    }
}
