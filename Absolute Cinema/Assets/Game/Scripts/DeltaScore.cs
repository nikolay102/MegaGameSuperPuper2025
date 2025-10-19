using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine;

namespace Game.Scripts
{
    public class DeltaScore: MonoBehaviour
    {
        private int scoreValue=3;
        [SerializeField] private Button plusButton;
        [SerializeField] private Button minusButton;
        [SerializeField] private TMP_Text scoreText;
        [SerializeField] private ScroreChecker scroreChecker;
        

        private void Awake()
        {
            minusButton.onClick.AddListener(() => Minus());
            plusButton.onClick.AddListener(() => Plus());
        }

        private void OnEnable()
        {
            onScoreChanged += Govn;
        }

        private void Govn(int score)
        {
            scoreText.text = score.ToString();
        }

        private event Action<int> onScoreChanged;
        private void Plus()
        {
            //scoreValue++;
            scroreChecker.Givn++;
            //Debug.Log(scoreValue);
            onScoreChanged?.Invoke(scroreChecker.Givn);
        }
        
        private void Minus()
        {
            //scoreValue--;
            scroreChecker.Givn--;
            //Debug.Log(scoreValue);
            onScoreChanged?.Invoke(scroreChecker.Givn);
        }
    }
}