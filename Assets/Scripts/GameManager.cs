using UnityEngine;

public class GameManager : MonoBehaviour
{
    //On peut l'appeler partout
    public static GameManager Instance;

    [HideInInspector] public bool puzzle1Succeed = false;

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
