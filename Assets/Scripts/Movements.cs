using UnityEngine;
using UnityEngine.SceneManagement;

public class Movements : MonoBehaviour
{
    GameObject tablet;

    //Pour aller à la grotte
    public void ToCave()
    {
        //Si l'énigme a déjà été réussie, on va directement à la grotte
        if (GameManager.Instance.puzzle1Succeed)
        {
            SceneManager.LoadSceneAsync("Cave");
        }
        //Si l'énigme n'a pas encore été réussie, la flèche mène à l'énigme
        else
        {
            SceneManager.LoadSceneAsync("Wall Enigma");
        }
    }

    //Pour aller au village
    public void ToVillage()
    {
        SceneManager.LoadSceneAsync("Village");
    }

   public void ToVillageRightSide()
    {
        //Si le joueur a réussi le deuxième puzzle, il peut y aller
        if (GameManager.Instance.puzzle2Succeed)
        {
            SceneManager.LoadSceneAsync("Village right side");
        }
        else
        {
            //Si le joueur n'a réussi que le premier puzzle, il va à la scène avant le deuxième puzzle
            if (GameManager.Instance.puzzle1Succeed)
            {
                SceneManager.LoadSceneAsync("Whale translate");
            }
            //Si le joueur n'a pas réussi la première énigme, il ne peut pas encore aller par là.
            else
            {
                Debug.Log("Vous ne pouvez pas aller là pour le moment");
            }
            
        }
    }

    public void ToTranslationPuzzle()
    {
        SceneManager.LoadSceneAsync("Whale translate");
    }

    /*public void ToArrival()
    {
        SceneManager.LoadSceneAsync("Arrival");

    }*/

}
