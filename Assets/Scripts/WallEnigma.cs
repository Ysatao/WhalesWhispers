using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WallEnigma : MonoBehaviour
{
    //Initialiser le tableau avec l'ordre que le joueur doit suivre
    string[] correctAnswer = { "left", "right", "right", "left" };
    int actualIndex = 0;

    public GameObject croixPanel;
    public GameObject goodAnswerPanel;
    public void ButtonClick(string button)
    {

        //Si le clic du joueur correspond, il continue
        if (button == correctAnswer[actualIndex])
        {
            actualIndex++;
            

            Debug.Log("nice");

            //Si le joueur fait le bon ordre au complet, il a réussi
            if (actualIndex >= correctAnswer.Length)
            {
                //Affichage pour voir si ça fonctionne bien
                Debug.Log("réussi");
                StartCoroutine(StartGoodAnswerPanel(1f));
                GameManager.Instance.puzzle1Succeed = true;
                SceneManager.LoadSceneAsync("Cave");
            }
        }

        //Si le clic du joueur est mauvais, il échoue et recommence
        else
        {
            Debug.Log("raté");
            //Si le joueur rate, une croix s'affiche pour lui faire comprendre qu'il a raté et qu'il doit recommencer
            StartCoroutine(StartCroixRouge(1f));

            actualIndex = 0;
        }
    }

        private IEnumerator StartCroixRouge(float delay)
        {
        croixPanel.SetActive(true);
        yield return new WaitForSeconds(delay);
        croixPanel.SetActive(false);
        }

         private IEnumerator StartGoodAnswerPanel(float delay)
        {
        goodAnswerPanel.SetActive(true);
        yield return new WaitForSeconds(delay);
        goodAnswerPanel.SetActive(false);
        }
}

