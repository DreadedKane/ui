/**
 * Copyright (c) Eugene Bridger. All rights reserved.
 * Licensed under the MIT License. See LICENSE file in the project root for full license information.
 */

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace HomewreckersStudio
{
    /**
     * Displays recent log statements.
     */
    public sealed partial class Console : MonoBehaviour
    {
        [Header("Required Components")]

        [SerializeField]
        [Tooltip("Used to show and hide the console.")]
        private GameObject m_view;

        [SerializeField]
        [Tooltip("Used to display the log statements.")]
        private Text m_text;

        [Header("Properties")]

        [SerializeField]
        [Tooltip("The maximum number of lines to display.")]
        private int m_maxLineCount = 12;

        [SerializeField]
        [Tooltip("The colour to use when displaying a warning.")]
        private Color m_warningColour = new Color(1f, 1f, 0f);

        [SerializeField]
        [Tooltip("The colour to use when displaying an assertion.")]
        private Color m_assertionColour = new Color(1f, .5f, 0f);

        [SerializeField]
        [Tooltip("The colour to use when displaying an error.")]
        private Color m_errorColour = new Color(1f, 0f, 0f);

        [SerializeField]
        [Tooltip("The colour to use when displaying an exception.")]
        private Color m_exceptionColour = new Color(1f, 0f, 1f);

        /** Used to store the log statements. */
        private Queue<string> m_statements;

        /**
         * Shows the console.
         */
        public void Show()
        {
            if (!m_view.activeSelf)
            {
                m_view.SetActive(true);
            }
        }

        /**
         * Hides the console.
         */
        public void Hide()
        {
            if (m_view.activeSelf)
            {
                m_view.SetActive(false);
            }
        }

        /**
         * Initializes the component.
         */
        private void Awake()
        {
            m_statements = new Queue<string>();
        }

        /**
         * Starts listening for log messages.
         */
        private void OnEnable()
        {
            Application.logMessageReceived += OnLog;
        }

        /**
         * Stops listening for log messages.
         */
        private void OnDisable()
        {
            Application.logMessageReceived -= OnLog;
        }

        /**
         * Hides the console.
         */
        private void Start()
        {
            Hide();
        }

        /**
         * Toggles visibility when tilde is pressed.
         */
        private void Update()
        {
            if (Input.GetKeyUp(KeyCode.BackQuote))
            {
                if (m_view.activeSelf)
                {
                    Hide();
                }
                else
                {
                    Show();
                }
            }

            UpdatePartial();
        }

        /** Platform-specific update method. */
        partial void UpdatePartial();

        /**
         * Adds a statement to the queue and updates the text.
         */
        private void OnLog(string condition, string stackTrace, LogType type)
        {
            AddStatement(condition, type);

            UpdateText();
        }

        /**
         * Adds a statement to the queue.
         */
        private void AddStatement(string condition, LogType type)
        {
            string colour = null;

            switch (type)
            {
                case LogType.Warning:
                    {
                        colour = ColorUtility.ToHtmlStringRGBA(m_warningColour);
                    }
                    break;

                case LogType.Assert:
                    {
                        colour = ColorUtility.ToHtmlStringRGBA(m_assertionColour);
                    }
                    break;

                case LogType.Error:
                    {
                        colour = ColorUtility.ToHtmlStringRGBA(m_errorColour);
                    }
                    break;

                case LogType.Exception:
                    {
                        colour = ColorUtility.ToHtmlStringRGBA(m_exceptionColour);
                    }
                    break;
            }

            string statement;

            if (colour == null)
            {
                statement = condition;
            }
            else
            {
                statement = string.Format("<color=\"{0}\">{1}</color>", colour, condition);
            }

            m_statements.Enqueue(statement);

            if (m_statements.Count > m_maxLineCount)
            {
                m_statements.Dequeue();
            }
        }

        /**
         * Updates the text with statements in the queue.
         */
        private void UpdateText()
        {
            m_text.text = null;

            foreach (string statement in m_statements)
            {
                if (string.IsNullOrEmpty(m_text.text))
                {
                    m_text.text = statement;
                }
                else
                {
                    m_text.text += string.Format("\n{0}", statement);
                }
            }
        }
    }
}
