/**
 * Copyright (c) Eugene Bridger. All rights reserved.
 * Licensed under the MIT License. See LICENSE file in the project root for full license information.
 */

using UnityEngine;
using UnityEngine.Assertions;

namespace HomewreckersStudio
{
    /**
     * Tests the dialog and logging behaviour.
     */
    public sealed class UITests : MonoBehaviour
    {
        [Header("Required Components")]

        [SerializeField]
        [Tooltip("Used to test the dialog.")]
        private Dialog m_dialog;

        /** Are we testing button 1? */
        private bool m_testingButton1;

        /** Are we testing button 2? */
        private bool m_testingButton2;

        /**
         * Runs the unit tests.
         */
        private void Start()
        {
            Debug.Log("Running unit tests");

            TestDialog();
            TestLogging();
        }

        /**
         * Finishes the unit tests.
         */
        private void Finish()
        {
            Debug.Log("Unit tests complete");
        }

        /**
         * Tests the dialog with no buttons.
         */
        private void TestDialog()
        {
            m_dialog.Show("This dialog will close in 2 seconds.");

            Invoke("HideDialog", 2f);
        }

        /**
         * Tests the dialog with one button.
         */
        private void HideDialog()
        {
            m_dialog.Show("Press the button.", "Button", OnButton);
        }

        /**
         * Tests the dialog confirm button.
         */
        private void OnButton()
        {
            m_testingButton1 = true;
            m_testingButton2 = false;

            m_dialog.Show("Press button 1.", "Button 1", "Button 2", OnButton1, OnButton2);
        }

        /**
         * Tests the dialog cancel button.
         */
        private void OnButton1()
        {
            Assert.IsTrue(m_testingButton1, "Dialog button 1 test failed.");

            m_testingButton1 = false;
            m_testingButton2 = true;

            m_dialog.Show("Press button 2.", "Button 1", "Button 2", OnButton1, OnButton2);
        }

        /**
         * Finishes the unit tests.
         */
        private void OnButton2()
        {
            Assert.IsTrue(m_testingButton2, "Dialog button 2 test failed.");

            Finish();
        }

        /**
         * Prints different types of log statement.
         */
        private void TestLogging()
        {
            Debug.Log("Test log");
            Debug.LogWarning("Test warning");
            Debug.LogAssertion("Test assertion");
            Debug.LogError("Test error");
            Debug.LogException(new System.Exception("Test exception"));
        }
    }
}
