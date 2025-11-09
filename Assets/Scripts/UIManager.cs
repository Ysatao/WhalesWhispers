using UnityEngine;

public class UIManager : MonoBehaviour
{
    private static UIManager Instance;

    private void Awake()
    {
        {
            if (Instance == null)
            {
                Instance = this;

                DontDestroyOnLoad(gameObject);
            }
            else if (Instance != this)
            {
                Destroy(gameObject);
            }
        }
    }
}
