using UnityEngine;
using UnityEngine.UI;

public class HandController : MonoBehaviour
{
    public static HandController Instance;

    [SerializeField] Transform bowlPos;
    [SerializeField] Transform lidPos;
    [SerializeField] Transform handlePos;
    [SerializeField] Transform cupPos;

    [SerializeField] GameObject handPanel;

    [HideInInspector] public Animator handAnim;
    GameObject handImageObj;

    void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }

    void Start()
    {
        ShowHandPanel();

        handAnim = GetComponent<Animator>();

        BowlClick();
    }

    void BowlClick()
    {
        ShowHandPanel();

        transform.position = bowlPos.position;

        handAnim.SetBool("isBlinking", true);
    }

    public void ShowHandPanel()
    {
        if(handPanel.activeInHierarchy == false)
        {
            handPanel.SetActive(true);
        }
    }

    public void HideHandPanel()
    {
        if(handPanel.activeInHierarchy == true)
        {
            handPanel.SetActive(false);
        }
    }

    public void LidClick()
    {
        ShowHandPanel();

        transform.position = lidPos.position;
        handAnim.SetBool("isBlinking", true);
    }

    public void HandleClick()
    {
        ShowHandPanel();

        transform.position = handlePos.position;
        handAnim.SetBool("isBlinking", true);
    }

    public void CupClick()
    {
        ShowHandPanel();

        transform.position = cupPos.position;
        handAnim.SetBool("isBlinking", true);
    }
}
