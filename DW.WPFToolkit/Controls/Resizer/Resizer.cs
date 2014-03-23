﻿using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace DW.WPFToolkit.Controls
{
    [TemplatePart(Name = "PART_LeftThumb", Type = typeof(Thumb))]
    [TemplatePart(Name = "PART_LeftTopThumb", Type = typeof(Thumb))]
    [TemplatePart(Name = "PART_TopThumb", Type = typeof(Thumb))]
    [TemplatePart(Name = "PART_RightTopThumb", Type = typeof(Thumb))]
    [TemplatePart(Name = "PART_RightThumb", Type = typeof(Thumb))]
    [TemplatePart(Name = "PART_RightBottomThumb", Type = typeof(Thumb))]
    [TemplatePart(Name = "PART_BottomThumb", Type = typeof(Thumb))]
    [TemplatePart(Name = "PART_LeftBottomThumb", Type = typeof(Thumb))]
    public class Resizer : ContentControl
    {
        static Resizer()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(Resizer), new FrameworkPropertyMetadata(typeof(Resizer)));
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            var leftThumb = GetTemplateChild("PART_LeftThumb") as Thumb;
            var leftTopThumb = GetTemplateChild("PART_LeftTopThumb") as Thumb;
            var topThumb = GetTemplateChild("PART_TopThumb") as Thumb;
            var rightTopThumb = GetTemplateChild("PART_RightTopThumb") as Thumb;
            var rightThumb = GetTemplateChild("PART_RightThumb") as Thumb;
            var rightBottomThumb = GetTemplateChild("PART_RightBottomThumb") as Thumb;
            var botomThumb = GetTemplateChild("PART_BottomThumb") as Thumb;
            var leftBottomThumb = GetTemplateChild("PART_LeftBottomThumb") as Thumb;

            if (leftThumb != null)
                leftThumb.DragDelta += LeftThumb_DragDelta;
            if (leftTopThumb != null)
                leftTopThumb.DragDelta += LeftTopThumb_DragDelta;
            if (topThumb != null)
                topThumb.DragDelta += TopThumb_DragDelta;
            if (rightTopThumb != null)
                rightTopThumb.DragDelta += RightTopThumb_DragDelta;
            if (rightThumb != null)
                rightThumb.DragDelta += RightThumb_DragDelta;
            if (rightBottomThumb != null)
                rightBottomThumb.DragDelta += RightBottomThumb_DragDelta;
            if (botomThumb != null)
                botomThumb.DragDelta += BotomThumb_DragDelta;
            if (leftBottomThumb != null)
                leftBottomThumb.DragDelta += LeftBottomThumb_DragDelta;

            RefreshCornerVisibilities();
        }

        private double GetFinalWidth(double additionalValue)
        {
            if (double.IsNaN(Width))
                Width = ActualWidth;
            var newWidth = Width + additionalValue;
            return PrepareWidthByRange((newWidth < 0) ? 0 : newWidth);
        }

        private double PrepareWidthByRange(double p)
        {
            if (double.IsNaN(MinWidth) ||
                p >= MinWidth)
            {
                if (double.IsNaN(MaxWidth) ||
                    p <= MaxWidth)
                    return p;
                return MaxWidth;
            }
            return MinWidth;
        }

        private double GetFinalHeight(double additionalValue)
        {
            if (double.IsNaN(Height))
                Height = ActualHeight;
            var newHeight = Height + additionalValue;
            return PrepareHeightByRange((newHeight < 0) ? 0 : newHeight);
        }

        private double PrepareHeightByRange(double p)
        {
            if (double.IsNaN(MinHeight) ||
                p >= MinHeight)
            {
                if (double.IsNaN(MaxHeight) ||
                    p <= MaxHeight)
                    return p;
                return MaxHeight;
            }
            return MinHeight;
        }

        private void LeftThumb_DragDelta(object sender, DragDeltaEventArgs e)
        {
            Width = GetFinalWidth(e.HorizontalChange * -1);
        }

        private void LeftTopThumb_DragDelta(object sender, DragDeltaEventArgs e)
        {
            Width = GetFinalWidth(e.HorizontalChange * -1);
            Height = GetFinalHeight(e.VerticalChange * -1);
        }

        private void TopThumb_DragDelta(object sender, DragDeltaEventArgs e)
        {
            Height = GetFinalHeight(e.VerticalChange * -1);
        }

        private void RightTopThumb_DragDelta(object sender, DragDeltaEventArgs e)
        {
            Width = GetFinalWidth(e.HorizontalChange);
            Height = GetFinalHeight(e.VerticalChange * -1);
        }

        private void RightThumb_DragDelta(object sender, DragDeltaEventArgs e)
        {
            Width = GetFinalWidth(e.HorizontalChange);
        }

        private void RightBottomThumb_DragDelta(object sender, DragDeltaEventArgs e)
        {
            Width = GetFinalWidth(e.HorizontalChange);
            Height = GetFinalHeight(e.VerticalChange);
        }

        private void BotomThumb_DragDelta(object sender, DragDeltaEventArgs e)
        {
            Height = GetFinalHeight(e.VerticalChange);
        }
        
        private void LeftBottomThumb_DragDelta(object sender, DragDeltaEventArgs e)
        {
            Width = GetFinalWidth(e.HorizontalChange * -1);
            Height = GetFinalHeight(e.VerticalChange);
        }

        public double LeftWidth
        {
            get { return (double)GetValue(LeftWidthProperty); }
            set { SetValue(LeftWidthProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="DW.WPFToolkit.Controls.Resizer.LeftWidth" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty LeftWidthProperty =
            DependencyProperty.Register("LeftWidth", typeof(double), typeof(Resizer), new UIPropertyMetadata(4.0, OnSizeChanged));

        public double TopHeight
        {
            get { return (double)GetValue(TopHeightProperty); }
            set { SetValue(TopHeightProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="DW.WPFToolkit.Controls.Resizer.TopHeight" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty TopHeightProperty =
            DependencyProperty.Register("TopHeight", typeof(double), typeof(Resizer), new UIPropertyMetadata(4.0, OnSizeChanged));

        public double RightWidth
        {
            get { return (double)GetValue(RightWidthProperty); }
            set { SetValue(RightWidthProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="DW.WPFToolkit.Controls.Resizer.RightWidth" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty RightWidthProperty =
            DependencyProperty.Register("RightWidth", typeof(double), typeof(Resizer), new UIPropertyMetadata(4.0, OnSizeChanged));

        public double BottomHeight
        {
            get { return (double)GetValue(BottomHeightProperty); }
            set { SetValue(BottomHeightProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="DW.WPFToolkit.Controls.Resizer.BottomHeight" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty BottomHeightProperty =
            DependencyProperty.Register("BottomHeight", typeof(double), typeof(Resizer), new UIPropertyMetadata(4.0, OnSizeChanged));

        public Thickness FrameSizes
        {
            get { return (Thickness)GetValue(FrameSizesProperty); }
            set { SetValue(FrameSizesProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="DW.WPFToolkit.Controls.Resizer.FrameSizes" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty FrameSizesProperty =
            DependencyProperty.Register("FrameSizes", typeof(Thickness), typeof(Resizer), new UIPropertyMetadata(new Thickness(8), OnFrameSizesChanged));

        private static void OnFrameSizesChanged(DependencyObject owner, DependencyPropertyChangedEventArgs e)
        {
            var control = (Resizer)owner;
            var thickness = (Thickness)e.NewValue;
            control.LeftWidth = thickness.Left;
            control.TopHeight = thickness.Top;
            control.RightWidth = thickness.Right;
            control.BottomHeight = thickness.Bottom;
        }

        private static void OnSizeChanged(DependencyObject owner, DependencyPropertyChangedEventArgs e)
        {
            var control = (Resizer)owner;
            control.RefreshCornerVisibilities();
        }

        private void RefreshCornerVisibilities()
        {
            var leftTopThumb = GetTemplateChild("PART_LeftTopThumb") as Thumb;
            var rightTopThumb = GetTemplateChild("PART_RightTopThumb") as Thumb;
            var rightBottomThumb = GetTemplateChild("PART_RightBottomThumb") as Thumb;
            var leftBottomThumb = GetTemplateChild("PART_LeftBottomThumb") as Thumb;

            if (LeftWidth > 0 &&
                TopHeight > 0 &&
                leftTopThumb != null)
                leftTopThumb.Visibility = Visibility.Visible;
            if (TopHeight > 0 &&
                RightWidth > 0 &&
                rightTopThumb != null)
                rightTopThumb.Visibility = Visibility.Visible;
            if (RightWidth > 0 &&
                BottomHeight > 0 &&
                rightBottomThumb != null)
                rightBottomThumb.Visibility = Visibility.Visible;
            if (BottomHeight > 0 &&
                LeftWidth > 0 &&
                leftBottomThumb != null)
                leftBottomThumb.Visibility = Visibility.Visible;
        }

        public double CornerSize
        {
            get { return (double)GetValue(CornerSizeProperty); }
            set { SetValue(CornerSizeProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="DW.WPFToolkit.Controls.Resizer.CornerSize" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty CornerSizeProperty =
            DependencyProperty.Register("CornerSize", typeof(double), typeof(Resizer), new UIPropertyMetadata(16.0));
    }
}
