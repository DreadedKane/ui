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
     * Manages a button representing a screen resolution.
     */
    public sealed class ResolutionButton : MonoBehaviour
    {
        [Header("Required Components")]

        [SerializeField]
        [Tooltip("Used to display the resolution.")]
        private Text m_text;

        /** The resolution this button represents. */
        private Resolution m_resolution;

        /** Invoked when the button is clicked. */
        private event Action<Resolution> m_selectEvent;

        /**
         * Initializes the button.
         */
        public void Initialize(Resolution resolution, Action<Resolution> selectEvent)
        {
            m_resolution = resolution;

            m_text.text = String.FromResolution(resolution);

            m_selectEvent = selectEvent;
        }

        /**
         * Invokes the callback.
         */
        public void OnClick()
        {
            Event.Invoke(m_selectEvent, m_resolution);
        }
    }
}
