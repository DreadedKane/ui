/**
 * Copyright (c) Eugene Bridger. All rights reserved.
 * Licensed under the MIT License. See LICENSE file in the project root for full license information.
 */

using UnityEngine;

namespace HomewreckersStudio
{
    /**
     * Manages displaying the resolution dialog.
     */
    public sealed class OptionsMenu : MonoBehaviour
    {
        [Header("Required Components")]

        [SerializeField]
        [Tooltip("Used to display the resolution dialog.")]
        private ResolutionDialog m_resolutionDialog;
        
        [SerializeField]
        [Tooltip("Used to display the current resolution.")]
        private Button m_resolutionButton;

        /**
         * Initializes the resolution button.
         */
        private void Start()
        {
            if (m_resolutionButton)
            {
                m_resolutionButton.AddListener(ShowResolutionDialog);

                UpdateResolution(Screen.currentResolution);
            }
        }

        /**
         * Shows the resolution dialog.
         */
        private void ShowResolutionDialog()
        {
            m_resolutionDialog.Show(UpdateResolution);
        }

        /**
         * Updates the resolution button.
         */
        private void UpdateResolution(Resolution resolution)
        {
            m_resolutionButton.ButtonText = String.FromResolution(resolution);
        }
    }
}
