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

    /*public void ToWhaleForBubbles()
    {
        //Si le joueur a réussi le premier puzzle, il peut aller à la suite
        if(GameManager.Instance.puzzle1Succeed)
        {
            SceneManager.LoadSceneAsync("Whale for bubbles");
        }
        //Si le joueur n'a pas réussi le premier puzzle, il ne peut pas aller à la suite
        else
        {
            Debug.Log("Vous ne pouvez pas aller là pour le moment");
        }
    }*/

   public void ToVillageRightSide()
    {
        if (GameManager.Instance.puzzle2Succeed)
        {
            SceneManager.LoadSceneAsync("Village right side");
        }
        else
        {
            if (GameManager.Instance.puzzle1Succeed)
            {
                SceneManager.LoadSceneAsync("Whale for bubbles");
            }
            else
            {
                Debug.Log("Vous ne pouvez pas aller là pour le moment");
            }
            
        }
    }

    public void ToBubblesPuzzle()
    {
        SceneManager.LoadSceneAsync("Bubbles enigma");
    }

    public void ToArrival()
    {
        SceneManager.LoadSceneAsync("Arrival");

    }

}
