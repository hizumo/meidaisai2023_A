using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStartButtonScript : MonoBehaviour
{

    public void OnClickStartButton()
    {
        SceneManager.LoadScene("GameScenes1 maitake 1");
    }

}
