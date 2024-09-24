using UnityEngine;

namespace OneButton
{
    /// <summary>
    /// Use this class to initialize the game and start the game
    /// </summary>
    public class GameManager : MonoBehaviour
    {
        public float startTime;
        public float decreasing;

        public float startPrice;
        public ItemCollections collections;
        public ItemSelectionController selectionController;

        [Header("Stat")]
        public int turn;
        public float currentMoney;
        public int currentScore;
        public float currentStartTime;
        public float timer;


        private void Start()
        {
            currentStartTime = startTime;
            timer = currentStartTime;
        }

        private void Update()
        {
            timer -= Time.deltaTime;
            if (timer < 0)
            {
                // check end turn
                CheckSelection();
                currentStartTime -= decreasing;
                timer = currentStartTime;
                // set up next turn
                Setup();
            }
        }

        public void Setup()
        {
            // change this in the future
            var pair = collections.items[turn];
            selectionController.Setup(pair);
        }

        public void CheckSelection()
        {
            // trigger something
            turn++;
        }
    }
}
