using UnityEngine;
using UnityEngine.SceneManagement;
public class UIManager : MonoBehaviour
{
    public void RePlayButton()
    {
        //Ads can be added before load scene.
        SceneManager.LoadScene(0);
    }
}
