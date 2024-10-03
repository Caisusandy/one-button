using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace OneButton
{
    public class EndScreenController : MonoBehaviour
    {
        public static Score finalScore;
        private GameManager gameInstance = GameManager.instance;

        // add text component and add text here
        public TMP_Text physHealthScoreText;
        public TMP_Text mentHealthScoreText;
        public TMP_Text happinessScoreText;
        public TMP_Text moneyScoreText;
        public TMP_Text scenerioText;
        public TMP_Text roundsText;

        private void Start()
        {
            // set text content here
            roundsText.text = $"Survived for {gameInstance.turn - 1} rounds";
            physHealthScoreText.text = $"Physical Health: {finalScore.Physical}% remaining";
            mentHealthScoreText.text = $"Mental Health: {finalScore.Mental}% remaining";
            happinessScoreText.text = $"Happiness: {finalScore.Happiness}% remaining";
            moneyScoreText.text = $"${gameInstance.currentMoney} remaining";
            scenerioText.text = GetEndDescriptionText();
        }

        private string GetEndDescriptionText()
        {
            int scenerioIndex = Random.Range(0, 3);
            List<string> currentScenerioOptions = GetCurrentSenerioOptions();
            return currentScenerioOptions[scenerioIndex];
        }

        private List<string> GetCurrentSenerioOptions()
        {
            List<string> currentScenerioOptions = null;
            if (gameInstance.currentMoney <= 0)
            {
                currentScenerioOptions = new List<string>()
                {
                    "Whoops! Looks like the piggy bank is officially empty. Time to pack up your things and go home… but hey, at least you won’t have to worry about paying bills anymore!",
                    "Well, you’ve successfully made it to the ‘Totally Broke Club!’ Don’t worry, we have T-shirts. Unfortunately, that’s the only thing we can give you… for free!",
                    "Your wallet has taken a vacation… and it’s not coming back! Bank account: zero, but don’t worry, you can always try again. The market has spoken!"
                };
            }
            else if (finalScore.Mental <= 0)
            {
                currentScenerioOptions = new List<string>()
                {
                    "Uh oh, looks like you’re out of mental juice! Time to close the tabs in your brain and maybe do some yoga. Your mental health may be at zero, but your potential is endless!",
                    "Your brain needs a vacation. Maybe a little beach time? Or at least a snack. You’ve hit the limit, but don’t worry, your brain will bounce back… eventually!",
                    "Oops! Looks like your brain has officially clocked out. It’s been a tough market, but mental health is important! Time for some self-care and a retry!"
                };
            }
            else if (finalScore.Physical <= 0)
            {
                currentScenerioOptions = new List<string>()
                {
                    "Yikes! Your health meter just hit rock bottom. Maybe a nap and a smoothie will help? Don’t worry, you can always try again after some rest!",
                    "Oops, you forgot to take care of yourself! Your body has pressed the snooze button, but next time, don’t forget to grab a salad once in a while!",
                    "Looks like you’ve run out of energy! Time for a snack break and maybe a walk. Health may be at zero, but hey, at least you won’t have to run any more errands!"
                };
            }
            else if (finalScore.Happiness <= 0)
            {
                currentScenerioOptions = new List<string>()
                {
                    "Oh no, it looks like you’ve run out of smiles! No worries though, you can always find joy in the little things, like… um… well, at least you don’t have to play anymore!",
                    "You’ve officially hit ‘Grumpy Cat’ status. Maybe it’s time for a quick nap and some ice cream? Your happiness meter might be at zero, but there’s always next time!",
                    "Looks like happiness is out of stock! But hey, you gave it your best shot. Maybe next round, there will be a sale on joy?\""
                };
            }
            else
            {
                currentScenerioOptions = new List<string>()
                {
                    "Woohoo! You’ve done it! You kept your balance, didn’t go bankrupt, and still have plenty of happiness, health, and a few bucks to spare! Time to celebrate with… some more shopping?",
                    "Congrats! You managed to juggle the market like a pro and kept your needs in check. You’re officially a life balance champion! Now, go treat yourself to something fun!",
                    "You nailed it! Your money’s in the bank, and your happiness, health, and mental state are all A-OK. You’ve beaten the game—and life—without breaking a sweat!"
                };
            }

            return currentScenerioOptions;
        }
    }
}