﻿using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace DW.WPFToolkit.Controls
{
    /// <summary>
    /// Enhances the <see cref="System.Windows.Controls.ComboBox" /> with a background info text.
    /// </summary>
    public class EnhancedComboBox : ComboBox
    {
        static EnhancedComboBox()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(EnhancedComboBox), new FrameworkPropertyMetadata(typeof(EnhancedComboBox)));
#if TRIAL
            License1.License.Display();
#endif
        }

        /// <summary>
        /// Gets or sets a value which indicates when the info text in the background is shown.
        /// </summary>
        [DefaultValue(InfoAppearance.OnLostFocus)]
        public InfoAppearance InfoAppearance
        {
            get { return (InfoAppearance)GetValue(InfoAppearanceProperty); }
            set { SetValue(InfoAppearanceProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="DW.WPFToolkit.Controls.EnhancedComboBox.InfoAppearance" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty InfoAppearanceProperty =
            DependencyProperty.Register("InfoAppearance", typeof(InfoAppearance), typeof(EnhancedComboBox), new UIPropertyMetadata(InfoAppearance.OnLostFocus));

        /// <summary>
        /// Gets or sets the info text shown in the background.
        /// </summary>
        [DefaultValue("")]
        public string InfoText
        {
            get { return (string)GetValue(InfoTextProperty); }
            set { SetValue(InfoTextProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="DW.WPFToolkit.Controls.EnhancedComboBox.InfoText" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty InfoTextProperty =
            DependencyProperty.Register("InfoText", typeof(string), typeof(EnhancedComboBox), new UIPropertyMetadata(""));

        /// <summary>
        /// Gets or sets the font style to be used in the info text in the background.
        /// </summary>
        public FontStyle InfoTextFontStyle
        {
            get { return (FontStyle)GetValue(InfoTextFontStyleProperty); }
            set { SetValue(InfoTextFontStyleProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="DW.WPFToolkit.Controls.EnhancedComboBox.InfoTextFontStyle" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty InfoTextFontStyleProperty =
            DependencyProperty.Register("InfoTextFontStyle", typeof(FontStyle), typeof(EnhancedComboBox), new UIPropertyMetadata(FontStyles.Italic));

        /// <summary>
        /// Gets or sets the foreground color of the info text in the background.
        /// </summary>
        public Brush InfoTextForeground
        {
            get { return (Brush)GetValue(InfoTextForegroundProperty); }
            set { SetValue(InfoTextForegroundProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="DW.WPFToolkit.Controls.EnhancedComboBox.InfoTextForeground" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty InfoTextForegroundProperty =
            DependencyProperty.Register("InfoTextForeground", typeof(Brush), typeof(EnhancedComboBox), new UIPropertyMetadata(Brushes.Gray));

        /// <summary>
        /// Gets or sets the horizontal alignment of the info text shown in the background.
        /// </summary>
        [DefaultValue(HorizontalAlignment.Left)]
        public HorizontalAlignment InfoTextHorizontalAlignment
        {
            get { return (HorizontalAlignment)GetValue(InfoTextHorizontalAlignmentProperty); }
            set { SetValue(InfoTextHorizontalAlignmentProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="DW.WPFToolkit.Controls.EnhancedComboBox.InfoTextHorizontalAlignment" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty InfoTextHorizontalAlignmentProperty =
            DependencyProperty.Register("InfoTextHorizontalAlignment", typeof(HorizontalAlignment), typeof(EnhancedComboBox), new UIPropertyMetadata(HorizontalAlignment.Left));

        /// <summary>
        /// Gets or sets the vertical alignment of the info text shown in the background.
        /// </summary>
        [DefaultValue(VerticalAlignment.Center)]
        public VerticalAlignment InfoTextVerticalAlignment
        {
            get { return (VerticalAlignment)GetValue(InfoTextVerticalAlignmentProperty); }
            set { SetValue(InfoTextVerticalAlignmentProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="DW.WPFToolkit.Controls.EnhancedComboBox.InfoTextVerticalAlignment" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty InfoTextVerticalAlignmentProperty =
            DependencyProperty.Register("InfoTextVerticalAlignment", typeof(VerticalAlignment), typeof(EnhancedComboBox), new UIPropertyMetadata(VerticalAlignment.Center));

        /// <summary>
        /// Gets or sets margin of the info text shown in the background.
        /// </summary>
        [DefaultValue(null)]
        public Thickness InfoTextMargin
        {
            get { return (Thickness)GetValue(InfoTextMarginProperty); }
            set { SetValue(InfoTextMarginProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="DW.WPFToolkit.Controls.EnhancedComboBox.InfoTextMargin" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty InfoTextMarginProperty =
            DependencyProperty.Register("InfoTextMargin", typeof(Thickness), typeof(EnhancedComboBox), new UIPropertyMetadata(null));

        /// <summary>
        /// Gets or sets the style of the info text shown in the background.
        /// </summary>
        [DefaultValue(null)]
        public Style InfoTextStyle
        {
            get { return (Style)GetValue(InfoTextStyleProperty); }
            set { SetValue(InfoTextStyleProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="DW.WPFToolkit.Controls.EnhancedComboBox.InfoTextStyle" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty InfoTextStyleProperty =
            DependencyProperty.Register("InfoTextStyle", typeof(Style), typeof(EnhancedComboBox), new UIPropertyMetadata(null));
    }
}
