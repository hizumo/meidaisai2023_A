using UnityEngine;
using UnityEngine.SceneManagement;

public class RuleSquript : MonoBehaviour
{
    public void OnClickRuleButton()
    {
        SceneManager.LoadScene("RuleScenes");
    }
    public void OnClickBackButton()
    {
        SceneManager.LoadScene("StartSceneMaitake");
    }
}
