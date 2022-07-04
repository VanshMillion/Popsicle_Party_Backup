using UnityEngine;

public class LevelManager : MonoBehaviour
{
    void Start()
    {
        GameManager.Instance.SelectShape();

        LevelUIManager.Instance.ChangeAllUIs();
    }
}
