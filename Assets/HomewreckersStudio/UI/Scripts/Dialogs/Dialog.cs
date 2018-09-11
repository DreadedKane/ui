/**
 * Copyright (c) Eugene Bridger. All rights reserved.
 * Licensed under the MIT License. See LICENSE file in the project root for full license information.
 */

using System;
using UnityEngine;
using UnityEngine.UI;

namespace HomewreckersStudio
{
    /**
     * Displays a message with optional buttons.
     */
    public sealed class Dialog : MonoBehaviour
    {
        [Header("Required Components")]

        [SerializeField]
        [Tooltip("Used to show and hide the dialog.")]
        private GameObject m_view;

        [SerializeField]
        [Tooltip("The text displayed in the dialog.")]
        private Text m_text;

        [SerializeField]
        [Tooltip("The text displayed on the confirm button.")]
        private Text m_confirmText;

        [SerializeField]
        [Tooltip("The text displayed on the cancel button.")]
        private Text m_cancelText;

        [SerializeField]
        [Tooltip("Used to show and hide the confirm button.")]
        private GameObject m_confirmButton;

        [SerializeField]
        [Tooltip("Used to show and hide the cancel button.")]
        private GameObject m_cancelButton;

        /** Invoked when the confirm button is clicked. */
        private event Action m_confirmEvent;

        /** Invoked when the cancel button is clicked. */
        private event Action m_cancelEvent;

        /**
         * Shows the dialog with no buttons.
         */
        public void Show(string message)
        {
            m_text.text = message;

            m_confirmButton.SetActive(false);
            m_cancelButton.SetActive(false);

            m_view.SetActive(true);
        }

        /**
         * Shows the dialog with one button.
         */
        public void Show(string text, string confirmText, Action confirmEvent)
        {
            m_text.text = text;
            m_confirmText.text = confirmText;
            m_confirmEvent = confirmEvent;

            m_confirmButton.SetActive(true);
            m_cancelButton.SetActive(false);

            m_view.SetActive(true);
        }

        /**
         * Shows the dialog with two buttons.
         */
        public void Show(string text, string confirmText, string cancelText, Action confirmEvent, Action cancelEvent)
        {
            m_text.text = text;
            m_confirmText.text = confirmText;
            m_cancelText.text = cancelText;
            m_confirmEvent = confirmEvent;
            m_cancelEvent = cancelEvent;

            m_confirmButton.SetActive(true);
            m_cancelButton.SetActive(true);

            m_view.SetActive(true);
        }

        /**
         * Hides the dialog.
         */
        public void Hide()
        {
            m_view.SetActive(false);
        }

        /**
         * Invokes the confirm event.
         */
        public void OnConfirm()
        {
            Hide();

            Event.Invoke(m_confirmEvent);
        }

        /**
         * Invokes the cancel event.
         */
        public void OnCancel()
        {
            Hide();

            Event.Invoke(m_cancelEvent);
        }

        /**
         * Hides the dialog.
         */
        private void Awake()
        {
            Hide();
        }
    }
}
