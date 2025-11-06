using System.Collections;
using UnityEngine;

public class Dialogues : MonoBehaviour
{
    public GameObject text;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(StartDialogue(6));
    }

    private IEnumerator StartDialogue(float delay)
    {
        text.SetActive(true);
        yield return new WaitForSeconds(delay);
        text.SetActive(false);
    }

}
