using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class LevelUIManager : MonoBehaviour
{
    public static LevelUIManager Instance;

    [HideInInspector] public int levelCount;

    [SerializeField] TMP_Text levelCountText;

    void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this);
    }

    void Start()
    {
        if (PlayerPrefs.HasKey("Level"))
        {
            levelCount = PlayerPrefs.GetInt("Level");
        }
        else
        {
            levelCount = 1;
        }

        //ChangeAllUIs();
    }

    public void ChangeAllUIs()
    {
        if(levelCount < 10)
        {
            levelCountText.text = "LEVEL 0" + levelCount.ToString();
        }
        else
        {
            levelCountText.text = "LEVEL " + levelCount.ToString();
        }
    }
}
