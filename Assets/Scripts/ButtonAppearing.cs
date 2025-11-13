using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ButtonAppearing : MonoBehaviour
{
    public GameObject rightArrow;
    public GameObject translatePanel;
    public void Start()
    {
       
    }
    public void Update()
    {
        if (GameManager.Instance.puzzle1Succeed == true)
        {
            rightArrow.SetActive(true);
            translatePanel.SetActive(true);
        }
    }
}

