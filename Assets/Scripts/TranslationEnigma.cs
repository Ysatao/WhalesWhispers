using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections;

public class TranslationEnigma : MonoBehaviour
{
    public Image foreignWordImage;
    //Texte dans chaque case
    public TextMeshProUGUI[] slotsText;
    //Boutons pour chaque lettre disponible
    public Button[] letterButtons;
    //L'image du mot étranger
    public Sprite foreignWordSprite;
    //Le mot à deviner
    public string correctWord = "OSEAN";
    //Les lettres déjà données
    public string[] knownLetters = { "E", "A" };
    //true si la lettre est déjà donnée
    private bool[] isSlotKnown;

    private string[] playerAnswer;

    public GameObject croixPanel;

    void Start()
    {
        foreignWordImage.sprite = foreignWordSprite;

        playerAnswer = new string[correctWord.Length];
        isSlotKnown = new bool[correctWord.Length];

        //Initialiser les slots
        for(int i = 0; i < slotsText.Length; i++)
        {
            string letter = correctWord[i].ToString();
            bool known = false;
            for(int j = 0; j < knownLetters.Length; j++)
            {
                if(knownLetters[j] == letter)
                {
                    known = true;
                    break;
                }
            }

            if (known)
            {
                slotsText[i].text = letter;
                playerAnswer[i] = letter;
                //Verrouiller le slot
                isSlotKnown[i] = true;
            }
            else
            {
                //Ce qui apparaît quand les slots sont vides
                slotsText[i].text = "_";
                playerAnswer[i] = null;
                isSlotKnown[i] = false;
            }
        }
    }

    //Le joueur peut cliquer sur les lettres pour constuire le mot
    public void OnLetterClick(string letter)
    {
        for(int i = 0; i < playerAnswer.Length; i++)
        {
            if (string.IsNullOrEmpty(playerAnswer[i]))
            {
                playerAnswer[i] = letter;
                slotsText[i].text = letter;
                break;
            }
        }
    }

    //Permettre au joueur de retirer la dernière lettre qu'il a mise grâce à un bouton
    public void RemoveLastLetter()
    {
        for(int i = playerAnswer.Length - 1; i >= 0; i--)
        {
            if(!string.IsNullOrEmpty(playerAnswer[i]) && !isSlotKnown[i])
            {
                playerAnswer[i] = null;
                slotsText[i].text = "_";
                break;
            }
        }
    }

    //Bouton qui vérifie si le mot est correct ou non. S'il est correct, on passe à la scène suivante
    public void ValidateWord()
    {
        for (int i = 0; i < playerAnswer.Length; i++)
        {
            if (string.IsNullOrEmpty(playerAnswer[i]))
            {
                Debug.Log("mot incomplet");
                return;
            }
        }

        //Si tous les slots sont remplis, vérifier si le mot est correct
        for (int i = 0; i < correctWord.Length; i++)
        {

            if (playerAnswer[i].ToUpper() != correctWord[i].ToString().ToUpper())
            {
                Debug.Log("incorect");
                //Si le joueur rate, une croix s'affiche pour lui faire comprendre qu'il a raté et qu'il doit recommencer
                StartCoroutine(StartCroixRouge(1f));
                //Reset le mot après 1 seconde s'il est mauvais
                Invoke("ResetWord", 1f);
                return;
            }
        }

        if(GameManager.Instance != null)
        {
            GameManager.Instance.puzzle2Succeed = true;
        }

        //Charger la scène suivante
        GameObject camera = Camera.main.gameObject;
        Movements movements = camera.GetComponent<Movements>();

        if (movements != null)
        {
            //Appel du script movements pour aller à la scène suivante
            movements.ToVillageRightSide();
        }
    }

    private IEnumerator StartCroixRouge(float delay)
    {
        croixPanel.SetActive(true);
        yield return new WaitForSeconds(delay);
        croixPanel.SetActive(false);
    }

    //Reset le mot lorsque le joueur se trompe
    void ResetWord()
    {
        for(int i = 0; i < playerAnswer.Length; i++)
        {
            string letter = correctWord[i].ToString();
            bool isKnown = false;

            for(int j = 0; j < knownLetters.Length; j++)
            {
                if (knownLetters[j] == letter)
                {
                    isKnown = true;
                    break;
                }
            }

            if (isKnown)
            {
                playerAnswer[i] = letter;
                slotsText[i].text = letter;
            }
            else
            {
                playerAnswer[i] = null;
                slotsText[i].text = "_";
            }
        }
    }

}
