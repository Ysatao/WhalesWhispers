using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class BubblesEnigma : MonoBehaviour
{
    //Déclarer et définir la variable pour la réponse à l'énigme
    int correctAnswer = 4;

    public GameObject croixPanel;

    public void ChooseAnswer(int playerAnswer)
    {
        //Si le joueur clique sur la bonne réponse, il retourne à la baleine
        if(playerAnswer == correctAnswer)
        {
            SceneManager.LoadSceneAsync("Whale for bubbles");
            GameManager.Instance.puzzle2Succeed = true;
        }
        else
        {
            //Si le joueur rate, une croix s'affiche pour lui faire comprendre qu'il a raté et qu'il doit recommencer
            StartCoroutine(StartCroixRouge(1f));
        }
    }

    private IEnumerator StartCroixRouge(float delay)
    {
        croixPanel.SetActive(true);
        yield return new WaitForSeconds(delay);
        croixPanel.SetActive(false);
    }
}
