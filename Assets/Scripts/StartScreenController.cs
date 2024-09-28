using UnityEngine;
using UnityEngine.SceneManagement;

namespace OneButton
{
    public class StartScreenController : MonoBehaviour
    {
        private void Update()
        {
            if (!GameManager.instance.isEndGame && Input.GetKeyUp("space"))
            {
                StartGame();
            }
        }

        public void StartGame()
        {
            SceneManager.LoadScene("SampleScene");
        }
    }
}