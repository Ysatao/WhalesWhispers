using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharactersDialogues : MonoBehaviour
{
    //Tableau de panels
    [SerializeField] GameObject[] dialoguePanels;
    [SerializeField] GameObject arrowToVillage;
    int currentIndex = 0;
    string[] playerAnswer = { "to the puzzle", "not now"};

    /*public void YesNo(string answer)
    {
        //Si le joueur choisit to the puzzle, il ira au puzzle. Sinon, le dialogue se ferme
        if (answer == "to the puzzle")
        {
            SceneManager.LoadSceneAsync("Translation enigma");
        }
        else
        {
            EndDialogue();
        }
    }*/

    public void StartDialogue()
    {
        currentIndex = 0;

        //Cacher la flèche
        if (arrowToVillage != null)
            arrowToVillage.SetActive(false);

        //Si le puzzle 2 n'a pas été résolu, le dialogue recommence
        if (GameManager.Instance !=null && GameManager.Instance.puzzle2Succeed)
        {
            for(int i = 0; i < dialoguePanels.Length; i++)
            {
                dialoguePanels[i].SetActive(false);
            }
        }
        else if(dialoguePanels.Length > 0)
        {
            dialoguePanels[0].SetActive(true);
        }
        else
        {
            for(int i = 0; i <dialoguePanels.Length; i++)
            {
                dialoguePanels[i].SetActive(false);
            }
        }
    }
    private void Start()
    {
        StartDialogue();
    }

    public void NextDialogue()
    {
        //S'il n'y a plus de panels, le dialogue se termine
        if(dialoguePanels.Length == 0)
        {
            return;
        }

        //Désactiver le panel actuel et passer au suivant
        dialoguePanels[currentIndex].SetActive(false);
        currentIndex++;

        if(currentIndex >= dialoguePanels.Length)
        {
            EndDialogue();
        }
        else
        {
            dialoguePanels[currentIndex].SetActive(true);
        }
    }

    public void EndDialogue()
    {
        for(int i = 0; i < dialoguePanels.Length; i++)
        {
            dialoguePanels[i].SetActive(false);
        }


        GameManager.Instance.arrivalDialogueDone = true;

        ///Afficher la flèche
        if (arrowToVillage != null)
            arrowToVillage.SetActive(true);
    }

    
}
