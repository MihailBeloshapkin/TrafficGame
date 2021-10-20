using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Traffic
{
    /// <summary>
    /// Manages pause state.
    /// </summary>
    public class PauseScript : MonoBehaviour
    {
        [SerializeField] private State state;

        [SerializeField] private GameObject inter;

        [SerializeField] private GameObject generator;

        /// <summary>
        ///  States of the game.
        /// </summary>
        public enum State
        {
            Start,
            Playing,
            Pause,
            Finish
        }

        public void Start()
        {
            this.state = State.Start;
            inter.SetActive(false);
            generator.SetActive(false);
        }

        public void Finish() => this.state = State.Finish;

        /// <summary>
        /// Manages basic interface.
        /// </summary>
        public void OnGUI()
        {
            Cursor.visible = true;
            if (state == State.Playing)
            {
                if (GUI.Button(new Rect((float)(Screen.width) - 120f, 20f, 100f, 40f), "Pause"))
                {
                    state = State.Pause;
                    Time.timeScale = 0;
                    inter.SetActive(false);
                }
            }
            if (state == State.Start)
            {
                if (GUI.Button(new Rect((float)(Screen.width / 2) - 70f, (float)(Screen.height / 2) - 20f, 140f, 40f), "Start"))
                {
                    state = State.Playing;
                    inter.SetActive(true);
                    generator.SetActive(true);
                }
            }
            if (state == State.Pause)
            {
                if (GUI.Button(new Rect((float)(Screen.width / 2) - 70f, (float)(Screen.height / 2) - 20f, 140f, 40f), "Continue"))
                {
                    state = State.Playing;
                    Time.timeScale = 1;
                    inter.SetActive(true);
                }
            }
            if (state == State.Finish)
            {
                Time.timeScale = 0;
                inter.SetActive(false);

                if (GUI.Button(new Rect((float)(Screen.width / 2) - 70f, (float)(Screen.height / 2) - 80f, 140f, 40f), "Restart"))
                {
                    state = State.Playing;
                    Time.timeScale = 1;
                    inter.SetActive(true);
                    generator.GetComponent<Generator>().Restart();
                }
                if (GUI.Button(new Rect((float)(Screen.width / 2) - 70f, (float)(Screen.height / 2) - 20f, 140f, 40f), "Exit"))
                {
                    state = State.Playing;
                    Time.timeScale = 1;
                    inter.SetActive(true);
                    generator.GetComponent<Generator>().Restart();
                }
            }
        }
    }
}