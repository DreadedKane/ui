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
     * Manages a button.
     */
    public class Button : MonoBehaviour
    {
        [Header("Required Components")]

        [SerializeField]
        [Tooltip("The text displayed on the button.")]
        private Text m_buttonText;

        /** Invoked when the button is clicked. */
        private event Action m_selectEvent;

        /**
         * Sets the button text.
         */
        public string ButtonText
        {
            set
            {
                m_buttonText.text = value;
            }
        }

        /**
         * Adds a listener to the select event.
         */
        public void AddListener(Action selectEvent)
        {
            m_selectEvent += selectEvent;
        }

        /**
         * Invokes the select event when the button is clicked.
         */
        public void OnClick()
        {
            Event.Invoke(m_selectEvent);
        }
    }
}

