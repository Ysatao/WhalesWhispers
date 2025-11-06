using UnityEngine;
using UnityEngine.SceneManagement;

public class Movements : MonoBehaviour
{
    //Pour aller du village à la grotte
    public void FromVillageToCave()
    {
        //Si l'énigme a déjà été réussie, on va directement à la grotte
        if (GameManager.Instance.puzzle1Succeed)
        {
            SceneManager.LoadSceneAsync("Cave");
        }
        //Si l'énigme n'a pas encore été réussie, la flèche mène à l'énigme
        else
        {
            SceneManager.LoadSceneAsync("Wall Enigma");
        }
    }

    //Pour aller de la grotte au village
    public void FromCaveToVillage()
    {
        SceneManager.LoadSceneAsync("Village");
    }
}
