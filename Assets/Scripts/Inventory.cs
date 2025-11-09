using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    [SerializeField] GameObject inventoryPanel;
    //Tableau pour stocker les pages
    [SerializeField] GameObject[] pages;
    [SerializeField] Button leftArrow;
    [SerializeField] Button rightArrow;
    [SerializeField] Button exit;

    //On commence avec 0 pages
    int currentPage = 0;
    bool isOpen = false;

    private void Start()
    {
        inventoryPanel.SetActive(false);
        UpdateInventoryDisplay();
    }

    public void ToggleInventory()
    {
        isOpen = !isOpen;
        inventoryPanel.SetActive(isOpen);

        if (isOpen)
        {
            UpdateInventoryDisplay();
        }
    }

    public void CloseInventory()
    {
        inventoryPanel.SetActive(!isOpen);
    }
    public void NextPage()
    {
        currentPage++;

        //Si le joueur arrive à la fin du nombre de pages, il retourne à la première page
        if(currentPage >= pages.Length)
        {
            currentPage = 0;
        }

        UpdateInventoryDisplay();
    }

    public void PreviousPage()
    {
        currentPage--;

        if(currentPage < 0)
        {
            currentPage = pages.Length - 1;
        }

        UpdateInventoryDisplay();
    }

    void UpdateInventoryDisplay()
    {
        for(int i = 0; i < pages.Length; i++)
        {
            bool shouldShow = GameManager.Instance.HasPage(pages[i].name);
            pages[i].SetActive(i == currentPage && shouldShow);
        }

        leftArrow.interactable = pages.Length > 1;
        rightArrow.interactable = pages.Length > 1;
    }
}
