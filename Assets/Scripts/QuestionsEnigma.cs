using UnityEngine;
using System.Collections;

public class QuestionsEnigma : MonoBehaviour
{
    public string answer = "blue";
    public string incorrectAnswer1 = "red";
    public string incorrectAnswer2 = "green";
    public GameObject croixPanel;

    public void ButtonOnClick(string button)
    {
        if(button == answer)
        {
            GameManager.Instance.puzzle3Succeed = true;
            Debug.Log("bonne réponse");
        }
        else if(button == "red" || button == "green")
        {
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
