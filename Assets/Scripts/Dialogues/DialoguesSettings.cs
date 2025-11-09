using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DialoguesSettings : MonoBehaviour
{

    public GameObject text;


    public void Start()
    {
        //Fonction qui lance le texte au début
        TextVillageCoroutine();
    }

      public void TextVillageCoroutine()
    {
        //Si le puzzle n'a pas encore été réussi, le texte apparaît
        if (!GameManager.Instance.puzzle1Succeed)
        {
            StartCoroutine(StartDialogue(6));
        }
        //Si le puzzle a été réussi, le texte n'apparaît plus
        else
        {
            text.SetActive(false);
        }
    }

    private IEnumerator StartDialogue(float delay)
    {
        text.SetActive(true);
        yield return new WaitForSeconds(delay);
        text.SetActive(false);
    }

}
