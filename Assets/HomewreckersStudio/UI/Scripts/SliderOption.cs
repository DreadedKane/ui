/**
 * Copyright (c) Eugene Bridger. All rights reserved.
 * Licensed under the MIT License. See LICENSE file in the project root for full license information.
 */

using UnityEngine;
using UnityEngine.UI;

namespace HomewreckersStudio
{
    /**
     * Manages a slider used to set a persistent value.
     */
    public sealed class SliderOption : MonoBehaviour
    {
        [Header("Required Components")]

        [SerializeField]
        [Tooltip("Used to set the option value.")]
        private Slider m_slider;

        [Header("Properties")]

        [SerializeField]
        [Tooltip("The persistent data key.")]
        private string m_key;

        [SerializeField]
        [Tooltip("The default value of the option.")]
        private float m_defaultValue;

        /**
         * Updates the persistent data.
         */
        public void OnValueChanged(float value)
        {
            PlayerPrefs.SetFloat(m_key, value);
        }

        /**
         * Initializes the slider value.
         */
        private void Start()
        {
            m_slider.value = PlayerPrefs.GetFloat(m_key, m_defaultValue);
        }
    }
}

