using UnityEngine;

public class Pages : MonoBehaviour
{
    [SerializeField] string pageNumber;

    public void TakePage()
    {
        //Marquer la page comme récupérée
       if (GameManager.Instance != null)
        {

            if (!GameManager.Instance.collectedPages.Contains(pageNumber))
            {
                GameManager.Instance.collectedPages.Add(pageNumber);
            }
        }
        else
        {
            Debug.LogWarning("GameManager non trouvé");
        }

            //Cacher la page
            gameObject.SetActive(false);
    }

    private void Start()
    {
        //Si le joueur a déjà récupéré la page, elle n'apparaît plus dans la scène
        if (GameManager.Instance != null && GameManager.Instance.collectedPages.Contains(pageNumber))
        {
            gameObject.SetActive(false);
        }
    }
}
