using UnityEngine;

public class LevelManager : MonoBehaviour
{
    void Start()
    {
        //if(LevelUIManager.Instance.levelCount > 4)
        //{
        //    GameManager.Instance.SelectShape();
        //}

        LevelUIManager.Instance.ChangeAllUIs();
    }
}
