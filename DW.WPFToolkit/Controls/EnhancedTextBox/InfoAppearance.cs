﻿namespace DW.WPFToolkit.Controls
{
    /// <summary>
    /// Defines when the <see cref="DW.WPFToolkit.Controls.EnhancedTextBox.InfoText" /> in the <see cref="DW.WPFToolkit.Controls.EnhancedTextBox" /> and its derived controls is visible.
    /// </summary>
    public enum InfoAppearance
    {
        /// <summary>
        /// No info text has to be shown.
        /// </summary>
        None,

        /// <summary>
        /// The info text is shown when the box is empty, no matter if it has the keyboard focus or not.
        /// </summary>
        OnEmpty,

        /// <summary>
        /// The info text is shown when the box is empty and does not have the keyboard focus.
        /// </summary>
        OnLostFocus
    }
}
