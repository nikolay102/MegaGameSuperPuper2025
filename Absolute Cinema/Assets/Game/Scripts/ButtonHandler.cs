using System;
using UnityEngine;
using UnityEngine.UI;
namespace Game.Scripts
{
    public class ButtonHandler: MonoBehaviour
    {
        public Button button;
        void Start() {
            button.onClick.AddListener(TaskOnClick);
        }
        void TaskOnClick() {
            Debug.Log("Даун");
        }
    }
}