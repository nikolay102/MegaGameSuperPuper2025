using System;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

namespace Game.Scripts
{
    public class UIController : MonoBehaviour
    {
        [SerializeField] private Button scoreButton;
        [SerializeField] private CubeManager cubeManager;
        [SerializeField] private Button spawnButton;
        [SerializeField] private Button despawnButton;
        [SerializeField] private ScroreChecker scroreChecker;
        [SerializeField] private TMP_Text winText;
        [SerializeField] private TMP_Text loseText;
        [SerializeField] private TMP_Text sumbob;

        private void OnEnable()
        {
            scroreChecker.onVictoryOrNot += Victory;
            scroreChecker.onSumbobChanged+= FinalScore;
        }

        private void Victory(bool isVictory)
        {
            if (isVictory)
            {
                loseText.gameObject.SetActive(false);
                winText.gameObject.SetActive(true);
            }
            else
            {
                winText.gameObject.SetActive(false);
                loseText.gameObject.SetActive(true);
            }
        }

        private void FinalScore(int score)
        {
            sumbob.text = scroreChecker.Sumboba.ToString();
        }
        
        private void Awake()
        {
            scoreButton.onClick.AddListener(cubeManager.ThrowAll);
            spawnButton.onClick.AddListener(cubeManager.SpawnCubes);
            despawnButton.onClick.AddListener(cubeManager.DestroyCubes);
        }
    }
}