/**
 * Copyright (c) Eugene Bridger. All rights reserved.
 * Licensed under the MIT License. See LICENSE file in the project root for full license information.
 */

using System;
using UnityEngine;
using UnityEngine.UI;

namespace HomewreckersStudio
{
    public sealed class Dialog : MonoBehaviour
    {
        /** The dialog text. */
        [SerializeField]
        private Text m_text;

        /** The confirm button text. */
        [SerializeField]
        private Text m_confirmText;

        /** The cancel button text. */
        [SerializeField]
        private Text m_cancelText;

        /** Used to show and hide the confirm button. */
        [SerializeField]
        private GameObject m_confirmButton;

        /** Used to show and hide the cancel button. */
        [SerializeField]
        private GameObject m_cancelButton;

        /** Invoked when the confirm button is clicked. */
        private Action m_confirmEvent;

        /** Invoked when the cancel button is clicked. */
        private Action m_cancelEvent;

        /**
         * Shows the dialog with no buttons.
         */
        public void Show(string message)
        {
            m_text.text = message;

            m_confirmButton.SetActive(false);
            m_cancelButton.SetActive(false);

            gameObject.SetActive(true);
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

            gameObject.SetActive(true);
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

            gameObject.SetActive(true);
        }

        /**
         * Hides the dialog.
         */
        public void Hide()
        {
            gameObject.SetActive(false);
        }

        /**
         * Invokes the confirm event.
         */
        public void OnConfirm()
        {
            Hide();

            Event.Invoke(m_confirmEvent);

            m_confirmEvent = null;
            m_cancelEvent = null;
        }

        /**
         * Invokes the cancel event.
         */
        public void OnCancel()
        {
            Hide();

            Event.Invoke(m_cancelEvent);

            m_confirmEvent = null;
            m_cancelEvent = null;
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
