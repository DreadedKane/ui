/**
 * Copyright (c) Eugene Bridger. All rights reserved.
 * Licensed under the MIT License. See LICENSE file in the project root for full license information.
 */

using System;
using UnityEngine;

namespace HomewreckersStudio
{
    /**
     * Displays a list of resolutions for the user to select.
     */
    public sealed class ResolutionDialog : MonoBehaviour
    {
        [Header("Prefabs")]

        [SerializeField]
        [Tooltip("Used to instantiate a button for each resolution.")]
        private ResolutionButton m_buttonPrefab;

        [Header("Required Components")]

        [SerializeField]
        [Tooltip("Used to show/hide the dialog.")]
        private GameObject m_view;
        
        [SerializeField]
        [Tooltip("Container for the resolution buttons.")]
        private RectTransform m_content;

        /** Invoked when a resolution is selected. */
        private event Action<Resolution> m_selectEvent;

        /**
         * Shows the dialog.
         */
        public void Show(Action<Resolution> selectEvent)
        {
            m_selectEvent = selectEvent;

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
         * Hides the dialog and instantiates the buttons.
         */
        private void Start()
        {
            Hide();

            foreach (Resolution resolution in Screen.resolutions)
            {
                ResolutionButton button = Instantiate(m_buttonPrefab, m_content);

                button.Initialize(resolution, OnSelect);
            }
        }

        /**
         * Hides the dialog, sets the resolution, and invokes the callback.
         */
        private void OnSelect(Resolution resolution)
        {
            Hide();

            Screen.SetResolution(resolution.width, resolution.height, true, resolution.refreshRate);

            Event.Invoke(m_selectEvent, resolution);
        }
    }
}

