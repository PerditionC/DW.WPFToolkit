﻿using System.Windows;
using System.Windows.Controls;

namespace DW.WPFToolkit.Controls
{
    /// <summary>
    /// Represents a button to step forward or backwards through the pages in the <see cref="DW.WPFToolkit.Controls.PagingControl" />.
    /// </summary>
    public class PagingNavigateButton : Button
    {
        static PagingNavigateButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(PagingNavigateButton), new FrameworkPropertyMetadata(typeof(PagingNavigateButton)));
#if TRIAL
            License1.LicenseChecker.Validate();
#endif
        }
    }
}
