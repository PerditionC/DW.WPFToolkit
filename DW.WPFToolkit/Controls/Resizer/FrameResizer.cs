﻿using System.ComponentModel;
using System.Windows;
using System.Windows.Controls.Primitives;

namespace DW.WPFToolkit.Controls
{
    /// <summary>
    /// Represents a single line to drag in a specific direction. This is used in the <see cref="DW.WPFToolkit.Controls.Resizer" />.
    /// </summary>
    public class FrameResizer : Thumb
    {
        static FrameResizer()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(FrameResizer), new FrameworkPropertyMetadata(typeof(FrameResizer)));
#if TRIAL
            License1.License.Display();
#endif
        }

        /// <summary>
        /// Gets or sets the direction where the frame resizer can be moved to.
        /// </summary>
        [DefaultValue(FrameResizerDirections.LeftRight)]
        public FrameResizerDirections Direction
        {
            get { return (FrameResizerDirections)GetValue(DirectionProperty); }
            set { SetValue(DirectionProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="DW.WPFToolkit.Controls.FrameResizer.Direction" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty DirectionProperty =
            DependencyProperty.Register("Direction", typeof(FrameResizerDirections), typeof(FrameResizer), new UIPropertyMetadata(FrameResizerDirections.LeftRight));

        /// <summary>
        /// Gets or sets the position of the frame resizer inside the <see cref="DW.WPFToolkit.Controls.Resizer" /> control.
        /// </summary>
        [DefaultValue(FrameResizerPositions.Right)]
        public FrameResizerPositions Position
        {
            get { return (FrameResizerPositions)GetValue(PositionProperty); }
            set { SetValue(PositionProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="DW.WPFToolkit.Controls.FrameResizer.Position" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty PositionProperty =
            DependencyProperty.Register("Position", typeof(FrameResizerPositions), typeof(FrameResizer), new UIPropertyMetadata(FrameResizerPositions.Right));
    }
}
