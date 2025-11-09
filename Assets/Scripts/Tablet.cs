using UnityEngine;

public class Tablet : MonoBehaviour
{
    public void TakeTablet()
    {
        //Marquer la tablette comme récupérée
        GameManager.Instance.tabletTaken = true;
        //Cacher la tablette
        gameObject.SetActive(false);

        //Vérifier que ça fonctionne
        Debug.Log("Tablette récupérée");
    }

    void Start()
    {
        //Si le joueur a déjà récupéré la tablette, on la cache au chargement de la scène
        if(GameManager.Instance != null && GameManager.Instance.tabletTaken)
        {
            gameObject.SetActive(false);
        }
    }
}
