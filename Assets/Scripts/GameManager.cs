using UnityEngine;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    //On peut l'appeler partout
    public static GameManager Instance;

    [HideInInspector] public bool puzzle1Succeed = false;
    [HideInInspector] public bool puzzle2Succeed = false;
    [HideInInspector] public bool puzzle3Succeed = false;
    [HideInInspector] public bool arrivalDialogueDone = false;

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
}
