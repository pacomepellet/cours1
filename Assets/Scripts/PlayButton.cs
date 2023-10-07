using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour
{
    public int FirstScene = 1;

    public void CommencerJeu()
    {
        SceneManager.LoadScene(FirstScene); 
    }
}
