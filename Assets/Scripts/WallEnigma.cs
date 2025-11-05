using UnityEngine;
using UnityEngine.SceneManagement;

public class WallEnigma : MonoBehaviour
{
    //Initialiser le tableau avec l'ordre que le joueur doit suivre
    string[] correctAnswer = { "left", "right", "right", "left" };
    int actualIndex = 0;

    public void ButtonClick(string button)
    {

        //Si le clic du joueur correspond, il continue
        if(button == correctAnswer[actualIndex])
        {
            actualIndex++;

            Debug.Log("nice");

            //Si le joueur fait le bon ordre au complet, il a réussi
            if (actualIndex >= correctAnswer.Length)
            {
                //Affichage pour voir si ça fonctionne bien
                Debug.Log("réussi");
                SceneManager.LoadSceneAsync("Cave");
            }
        }

        //Si le clic du joueur est mauvais, il échoue et recommence
        else
        {
            Debug.Log("raté");
            actualIndex = 0;
        }
    }
}
