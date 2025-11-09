using UnityEngine;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    //On peut l'appeler partout
    public static GameManager Instance;

    [HideInInspector] public bool puzzle1Succeed = false;
    [HideInInspector] public bool puzzle2Succeed = false;
    [HideInInspector] public bool arrivalDialogueDone = false;
    [HideInInspector] public bool pageTaken = false;
    //Faire une liste pour l'inventaire
    [HideInInspector] public List<string> collectedPages = new List<string>();

    //Il sera actif dès le lancement du jeu
    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            //Pour ne pas détruire l'instance
            DontDestroyOnLoad(Instance);
        }
        //Si l'instance existe déjà, celle-ci est détruite
        else if (Instance != this)
        {
            Destroy(this.gameObject);
        }
    }

    //Gérer les pages que le joueur possède déjà
    public bool HasPage(string pageNumber)
    {
        return collectedPages.Contains(pageNumber);
    }

    //Gérer l'ajout de pages
    public void AddPage(string pageNumber)
    {
        if (!collectedPages.Contains(pageNumber))
        {
            collectedPages.Add(pageNumber);
        }
    }
}
