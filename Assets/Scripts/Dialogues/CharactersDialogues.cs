using UnityEngine;
using TMPro;

public class CharactersDialogues : MonoBehaviour
{
    [SerializeField] GameObject dialoguePanel;
    [SerializeField] GameObject dialoguePanel2;
    [SerializeField] GameObject dialoguePanel3;



    public void ShowDialogue()
    {
        dialoguePanel.SetActive(true);
    }

    public void NextDialogue()
    {
        dialoguePanel.SetActive(false);
        dialoguePanel2.SetActive(true);
    }

    public void NextDialogue2()
    {
        dialoguePanel2.SetActive(false);
        dialoguePanel3.SetActive(true);
    }

    public void EndDialogue()
    {
        dialoguePanel.SetActive(false);
        dialoguePanel2.SetActive(false);
        dialoguePanel3.SetActive(false);
    }
}
