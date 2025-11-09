using UnityEngine;

public class InventoryIcon : MonoBehaviour
{
    [SerializeField] GameObject icon;

    private void Start()
    {
        UpdateIconVisibility();
    }
    private void Update()
    {
        UpdateIconVisibility();
    }

    void UpdateIconVisibility()
    {
        if(GameManager.Instance != null)
        {
            bool hasPages = GameManager.Instance.collectedPages.Count > 0;
            icon.SetActive(hasPages);
        }
    }
}
