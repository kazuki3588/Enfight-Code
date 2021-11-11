using UnityEngine;
using UnityEngine.SceneManagement;
public class BackButton : MonoBehaviour
{
    public void SceneBackButton()
    {
        SceneManager.LoadScene("LoginScene");
    }
}
