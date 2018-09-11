/**
 * Copyright (c) Eugene Bridger. All rights reserved.
 * Licensed under the MIT License. See LICENSE file in the project root for full license information.
 */

using UnityEngine;
using UnityEngine.UI;

namespace HomewreckersStudio
{
    /**
     * Manages a button representing a control.
     */
    public sealed class ControlButton : MonoBehaviour
    {
        [Header("Required Components")]

        [SerializeField]
        [Tooltip("Used to display the input mapping.")]
        private Text m_buttonText;

        [Header("Properties")]

        [SerializeField]
        [Tooltip("The unique key for the control.")]
        private string m_key;

        /**
         * Initializes the button.
         */
        private void Start()
        {
            Control control = InputManager.Instance.GetControl(m_key);

            m_buttonText.text = control.Input;
        }
    }
}

