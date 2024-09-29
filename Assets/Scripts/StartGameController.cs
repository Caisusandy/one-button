using UnityEngine;
using UnityEngine.SceneManagement;

namespace OneButton
{
    public class StartGameController : MonoBehaviour
    {
        private void Update()
        {
            if (Input.GetKeyUp("space"))
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