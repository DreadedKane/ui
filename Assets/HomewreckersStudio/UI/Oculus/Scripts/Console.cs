/**
 * Copyright (c) Eugene Bridger. All rights reserved.
 * Licensed under the MIT License. See LICENSE file in the project root for full license information.
 */

#if UNITY_ANDROID

using UnityEngine;

namespace HomewreckersStudio
{
    /**
     * Toggles visibility based on the camera pitch.
     */
    public sealed partial class Console
    {
        [Header("Properties (Oculus)")]

        [SerializeField]
        [Range(0f, 90f)]
        [Tooltip("Show the console when the camera pitch is greater than this.")]
        private float m_showAngle = 30f;

        /**
         * Toggles console visibility based on the camera angle.
         */
        partial void UpdatePartial()
        {
            float pitch = Math.Pitch(Camera.main.transform);

            if (pitch < -m_showAngle)
            {
                Show();
            }
            else
            {
                Hide();
            }
        }
    }
}

#endif // UNITY_ANDROID
