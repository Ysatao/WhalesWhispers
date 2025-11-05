using UnityEngine;
using UnityEngine.SceneManagement;

public class Movements : MonoBehaviour
{
    public void ToWallEnigma()
    {
        SceneManager.LoadSceneAsync("Wall enigma");
    }

    public void ToVillage()
    {
        SceneManager.LoadSceneAsync("Village");
    }
}
