﻿using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace DW.WPFToolkit.Controls
{
    [TemplatePart(Name = "PART_Pointer", Type = typeof(Path))]
    [TemplatePart(Name = "PART_Pie", Type = typeof(Ellipse))]
    [TemplatePart(Name = "PART_PercentLabel", Type = typeof(Label))]
    [TemplatePart(Name = "PART_Items", Type = typeof(EllipsePanel))]
    public class EllipsedProgressBar : ProgressBar
    {
        static EllipsedProgressBar()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(EllipsedProgressBar), new FrameworkPropertyMetadata(typeof(EllipsedProgressBar)));
        }

        public EllipsedProgressBar()
        {
            _outherEllipse = new EllipseGeometry();
            _innerEllipse = new EllipseGeometry();

            Loaded += (sender, e) =>
            {
                CalculateValues();
                OnIsIndeterminateChanged();
            };
        }

        public double OutherRadius
        {
            get { return (double)GetValue(OutherRadiusProperty); }
            set { SetValue(OutherRadiusProperty, value); }
        }

        public static readonly DependencyProperty OutherRadiusProperty =
            DependencyProperty.Register("OutherRadius", typeof(double), typeof(EllipsedProgressBar), new UIPropertyMetadata(0.0, OnOutherRadiusChanged));

        private static void OnOutherRadiusChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            var control = (EllipsedProgressBar)sender;
            control.OnOutherRadiusChanged();
        }

        public double InnerRadius
        {
            get { return (double)GetValue(InnerRadiusProperty); }
            set { SetValue(InnerRadiusProperty, value); }
        }

        public static readonly DependencyProperty InnerRadiusProperty =
            DependencyProperty.Register("InnerRadius", typeof(double), typeof(EllipsedProgressBar), new UIPropertyMetadata(0.0, OnInnerRadiusChanged));

        private static void OnInnerRadiusChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            var control = (EllipsedProgressBar)sender;
            control.OnInnerRadiusChanged();
        }

        public double StrokeThickness
        {
            get { return (double)GetValue(StrokeThicknessProperty); }
            set { SetValue(StrokeThicknessProperty, value); }
        }

        public static readonly DependencyProperty StrokeThicknessProperty =
            DependencyProperty.Register("StrokeThickness", typeof(double), typeof(EllipsedProgressBar), new UIPropertyMetadata(0.0));

        public EllipsedProgressBarKind DisplayKind
        {
            get { return (EllipsedProgressBarKind)GetValue(DisplayKindProperty); }
            set { SetValue(DisplayKindProperty, value); }
        }

        public static readonly DependencyProperty DisplayKindProperty =
            DependencyProperty.Register("DisplayKind", typeof(EllipsedProgressBarKind), typeof(EllipsedProgressBar), new UIPropertyMetadata(EllipsedProgressBarKind.Pie, OnDisplayKindChanged));

        private static void OnDisplayKindChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            var control = (EllipsedProgressBar)sender;
            control.CalculateValues();
        }

        public bool IsInversed
        {
            get { return (bool)GetValue(IsInversedProperty); }
            set { SetValue(IsInversedProperty, value); }
        }

        public static readonly DependencyProperty IsInversedProperty =
            DependencyProperty.Register("IsInversed", typeof(bool), typeof(EllipsedProgressBar), new UIPropertyMetadata(false, OnIsInversedChanged));

        private static void OnIsInversedChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            var control = (EllipsedProgressBar)sender;
            control.CalculateValues();
        }

        public bool ShowOutherCircle
        {
            get { return (bool)GetValue(ShowOutherCircleProperty); }
            set { SetValue(ShowOutherCircleProperty, value); }
        }

        public static readonly DependencyProperty ShowOutherCircleProperty =
            DependencyProperty.Register("ShowOutherCircle", typeof(bool), typeof(EllipsedProgressBar), new UIPropertyMetadata(false));

        public Brush OutherCircleBrush
        {
            get { return (Brush)GetValue(OutherCircleBrushProperty); }
            set { SetValue(OutherCircleBrushProperty, value); }
        }

        public static readonly DependencyProperty OutherCircleBrushProperty =
            DependencyProperty.Register("OutherCircleBrush", typeof(Brush), typeof(EllipsedProgressBar));

        public Brush InnerCircleBrush
        {
            get { return (Brush)GetValue(InnerCircleBrushProperty); }
            set { SetValue(InnerCircleBrushProperty, value); }
        }

        public static readonly DependencyProperty InnerCircleBrushProperty =
            DependencyProperty.Register("InnerCircleBrush", typeof(Brush), typeof(EllipsedProgressBar));

        public double OutherCircleThickness
        {
            get { return (double)GetValue(OutherCircleThicknessProperty); }
            set { SetValue(OutherCircleThicknessProperty, value); }
        }

        public static readonly DependencyProperty OutherCircleThicknessProperty =
            DependencyProperty.Register("OutherCircleThickness", typeof(double), typeof(EllipsedProgressBar));

        public double InnerCircleThickness
        {
            get { return (double)GetValue(InnerCircleThicknessProperty); }
            set { SetValue(InnerCircleThicknessProperty, value); }
        }

        public static readonly DependencyProperty InnerCircleThicknessProperty =
            DependencyProperty.Register("InnerCircleThickness", typeof(double), typeof(EllipsedProgressBar));

        public bool ShowInnerCircle
        {
            get { return (bool)GetValue(ShowInnerCircleProperty); }
            set { SetValue(ShowInnerCircleProperty, value); }
        }

        public static readonly DependencyProperty ShowInnerCircleProperty =
            DependencyProperty.Register("ShowInnerCircle", typeof(bool), typeof(EllipsedProgressBar), new UIPropertyMetadata(false));

        public double StartAngle
        {
            get { return (double)GetValue(StartAngleProperty); }
            set { SetValue(StartAngleProperty, value); }
        }

        public static readonly DependencyProperty StartAngleProperty =
            DependencyProperty.Register("StartAngle", typeof(double), typeof(EllipsedProgressBar), new UIPropertyMetadata(0.0, OnStartAngleChanged));

        private static void OnStartAngleChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            var control = (EllipsedProgressBar)sender;
            control.CalculateValues();
        }

        public DoubleCollection OutherCircleDashArray
        {
            get { return (DoubleCollection)GetValue(OutherCircleDashArrayProperty); }
            set { SetValue(OutherCircleDashArrayProperty, value); }
        }

        public static readonly DependencyProperty OutherCircleDashArrayProperty =
            DependencyProperty.Register("OutherCircleDashArray", typeof(DoubleCollection), typeof(EllipsedProgressBar));

        public DoubleCollection InnerCircleDashArray
        {
            get { return (DoubleCollection)GetValue(InnerCircleDashArrayProperty); }
            set { SetValue(InnerCircleDashArrayProperty, value); }
        }

        public static readonly DependencyProperty InnerCircleDashArrayProperty =
            DependencyProperty.Register("InnerCircleDashArray", typeof(DoubleCollection), typeof(EllipsedProgressBar));

        public Style PercentLabelStyle
        {
            get { return (Style)GetValue(PercentLabelStyleProperty); }
            set { SetValue(PercentLabelStyleProperty, value); }
        }

        public static readonly DependencyProperty PercentLabelStyleProperty =
            DependencyProperty.Register("PercentLabelStyle", typeof(Style), typeof(EllipsedProgressBar));

        public bool HasPercentLabel
        {
            get { return (bool)GetValue(HasPercentLabelProperty); }
            set { SetValue(HasPercentLabelProperty, value); }
        }

        public static readonly DependencyProperty HasPercentLabelProperty =
            DependencyProperty.Register("HasPercentLabel", typeof(bool), typeof(EllipsedProgressBar), new UIPropertyMetadata(false));

        public IItemsFactory ItemsFactory
        {
            get { return (IItemsFactory)GetValue(ItemsFactoryProperty); }
            set { SetValue(ItemsFactoryProperty, value); }
        }

        public static readonly DependencyProperty ItemsFactoryProperty =
            DependencyProperty.Register("ItemsFactory", typeof(IItemsFactory), typeof(EllipsedProgressBar), new UIPropertyMetadata(OnItemsFactoryChanged));

        private static void OnItemsFactoryChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            var control = (EllipsedProgressBar)sender;
            control.TryTakeItems();
        }

        public bool RotateItems
        {
            get { return (bool)GetValue(RotateItemsProperty); }
            set { SetValue(RotateItemsProperty, value); }
        }

        public static readonly DependencyProperty RotateItemsProperty =
            DependencyProperty.Register("RotateItems", typeof(bool), typeof(EllipsedProgressBar), new UIPropertyMetadata(true));

        public new bool IsIndeterminate
        {
            get { return (bool)this.GetValue(IsIndeterminateProperty); }
            set { this.SetValue(IsIndeterminateProperty, value); }
        }

        public static new readonly DependencyProperty IsIndeterminateProperty =
            ProgressBar.IsIndeterminateProperty.AddOwner(typeof(EllipsedProgressBar), new FrameworkPropertyMetadata(false, OnIsIndeterminateChanged));

        private static void OnIsIndeterminateChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            var control = (EllipsedProgressBar)sender;
            if (control.IsLoaded)
                control.OnIsIndeterminateChanged();
        }

        public double RotateSpeed
        {
            get { return (double)GetValue(RotateSpeedProperty); }
            set { SetValue(RotateSpeedProperty, value); }
        }

        public static readonly DependencyProperty RotateSpeedProperty =
            DependencyProperty.Register("RotateSpeed", typeof(double), typeof(EllipsedProgressBar), new UIPropertyMetadata(1.5));

        public SweepDirection RotateDirection
        {
            get { return (SweepDirection)GetValue(RotateDirectionProperty); }
            set { SetValue(RotateDirectionProperty, value); }
        }

        public static readonly DependencyProperty RotateDirectionProperty =
            DependencyProperty.Register("RotateDirection", typeof(SweepDirection), typeof(EllipsedProgressBar), new UIPropertyMetadata(SweepDirection.Clockwise));

        protected override void OnMinimumChanged(double oldMinimum, double newMinimum)
        {
            base.OnMinimumChanged(oldMinimum, newMinimum);
            if (CalculateValues())
                OnIsIndeterminateChanged();
        }

        protected override void OnMaximumChanged(double oldMaximum, double newMaximum)
        {
            base.OnMaximumChanged(oldMaximum, newMaximum);
            if (CalculateValues())
                OnIsIndeterminateChanged();
        }

        protected override void OnValueChanged(double oldValue, double newValue)
        {
            base.OnValueChanged(oldValue, newValue);
            if (CalculateValues())
                OnIsIndeterminateChanged();
        }

        private DoubleAnimation _currentAnimation;
        private RotateTransform _currentTransform;

        private void OnIsIndeterminateChanged()
        {
            TryTakeItems();
            CalculateValues();

            if (IsIndeterminate)
                BeginAnimation();
            else
            {
                EndAnimation();
                CalculateValues();
            }
        }

        private void BeginAnimation()
        {
            _currentAnimation = new DoubleAnimation();
            _currentAnimation.From = 0;
            _currentAnimation.To = 360;
            _currentAnimation.Duration = new Duration(TimeSpan.FromSeconds(RotateSpeed));
            _currentAnimation.RepeatBehavior = RepeatBehavior.Forever;

            _currentTransform = new RotateTransform(0, 0, 0);
            _currentTransform.BeginAnimation(RotateTransform.AngleProperty, _currentAnimation);

            if (DisplayKind == EllipsedProgressBarKind.Pie)
                _pieEllipse.RenderTransform = _currentTransform;
            else if (DisplayKind == EllipsedProgressBarKind.Pointer)
                _pointerPath.RenderTransform = _currentTransform;
            else
                _itemsPanel.RenderTransform = _currentTransform;
        }

        private void EndAnimation()
        {
            if (_currentTransform != null)
            {
                _currentTransform.BeginAnimation(RotateTransform.AngleProperty, null);
                RenderTransform = null;
                _currentAnimation = null;
                _currentTransform = null;
            }
        }

        private void OnOutherRadiusChanged()
        {
            Width = OutherRadius * 2.0;
            Height = Width;

            _outherEllipse.RadiusX = OutherRadius;
            _outherEllipse.RadiusY = OutherRadius;
            _outherEllipse.Center = new Point(OutherRadius, OutherRadius);
            _innerEllipse.Center = new Point(OutherRadius, OutherRadius);
        }

        private void OnInnerRadiusChanged()
        {
            _innerEllipse.RadiusX = InnerRadius;
            _innerEllipse.RadiusY = InnerRadius;
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            _pointerPath = GetTemplateChild("PART_Pointer") as Path;
            _pieEllipse = GetTemplateChild("PART_Pie") as Ellipse;
            _percentLabel = GetTemplateChild("PART_PercentLabel") as Label;
            _itemsPanel = GetTemplateChild("PART_Items") as EllipsePanel;

            TryTakeItems();
        }

        private void TryTakeItems()
        {
            if (_itemsPanel != null && ItemsFactory != null)
            {
                _currentItems = ItemsFactory.GenerateItems(IsIndeterminate);
                _itemsPanel.Children.Clear();
                foreach (UIElement element in _currentItems)
                    _itemsPanel.Children.Add(element);
            }
        }

        private Path _pointerPath;
        private Ellipse _pieEllipse;
        private EllipsePanel _itemsPanel;

        private readonly EllipseGeometry _outherEllipse;
        private readonly EllipseGeometry _innerEllipse;
        private Label _percentLabel;
        private IEnumerable<UIElement> _currentItems;

        private bool CalculateValues()
        {
            if (!CanCalculateValues())
                return false;

            if (DisplayKind == EllipsedProgressBarKind.Pie)
                SetPieValues();
            else if (DisplayKind == EllipsedProgressBarKind.Pointer)
                SetPointerValues();
            else
                SetItemsValues();
            return true;
        }

        private void SetPieValues()
        {
            var value = GetValue(true);

            var outherRadius = _outherEllipse.RadiusX;
            var innerRadius = _innerEllipse.RadiusX;

            var outherStartPoint = GetPosition(0, _outherEllipse);
            var outherEndPoint = GetPosition(value, _outherEllipse);
            var innerStartPoint = GetPosition(0, _innerEllipse);
            var innerEndPoint = GetPosition(value, _innerEllipse);

            var lineFromCenterToCircle = new LineSegment(outherStartPoint, false);

            PathSegment outherSegment;
            PathSegment innerSegment;
            if (IsInversed)
            {
                outherSegment = new ArcSegment(outherEndPoint, new Size(outherRadius, outherRadius), 45, value < 0.5, SweepDirection.Counterclockwise, false);
                innerSegment = new ArcSegment(innerStartPoint, new Size(innerRadius, innerRadius), 45, value < 0.5, SweepDirection.Clockwise, false);
            }
            else
            {
                outherSegment = new ArcSegment(outherEndPoint, new Size(outherRadius, outherRadius), 45, value > 0.5, SweepDirection.Clockwise, false);
                innerSegment = new ArcSegment(innerStartPoint, new Size(innerRadius, innerRadius), 45, value > 0.5, SweepDirection.Counterclockwise, false);
            }

            var lineFromCircleToCenter = new LineSegment(innerEndPoint, false);

            var pieFigure = new PathFigure();
            var pieGeometry = new PathGeometry();
            pieGeometry.Figures.Add(pieFigure);

            pieFigure.StartPoint = innerStartPoint;
            pieFigure.Segments.Add(lineFromCenterToCircle);
            pieFigure.Segments.Add(outherSegment);
            pieFigure.Segments.Add(lineFromCircleToCenter);
            pieFigure.Segments.Add(innerSegment);

            _pieEllipse.Clip = pieGeometry;

            _pieEllipse.RenderTransform = new RotateTransform(StartAngle);
        }

        private void SetPointerValues()
        {
            var value = GetValue(false);

            var outherPoint = GetPosition(value, _outherEllipse);
            var innerPoint = GetPosition(value, _innerEllipse);

            var lineFromCircleToCenter = new LineSegment(innerPoint, true);

            var pointerFigure = new PathFigure();
            var pointerGeometry = new PathGeometry();
            pointerGeometry.Figures.Add(pointerFigure);

            pointerFigure.StartPoint = outherPoint;
            pointerFigure.Segments.Add(lineFromCircleToCenter);

            _pointerPath.Data = pointerGeometry;

            _pointerPath.RenderTransform = new RotateTransform(StartAngle);
        }

        private void SetItemsValues()
        {
            ItemsFactory.EditItemsForValue(_currentItems, Minimum, Maximum, Value);

            CalculatePercentageValue();

            _itemsPanel.RenderTransform = new RotateTransform(StartAngle);
        }

        private double GetValue(bool adjusted)
        {
            var value = CalculatePercentageValue();

            if (adjusted)
            {
                if (IsInversed)
                {
                    if (Math.Abs(value - 0) < 0.001)
                        value = 0.00001;
                }
                else if (Math.Abs(value - 1) < 0.001)
                    value = 0.99999;
            }
            return value;
        }

        private double CalculatePercentageValue()
        {
            var value = (Value - Minimum) / (Maximum - Minimum);
            SetPercentageText(value);
            return value;
        }

        private void SetPercentageText(double value)
        {
            _percentLabel.Content = value.ToString("0%");
        }

        private Point GetPosition(double value, EllipseGeometry geometry)
        {
            var pathGeometry = geometry.GetOutlinedPathGeometry();
            if (pathGeometry.Figures.Count == 0)
                return geometry.Center;
            var outherGeometry = new PathGeometry(new[] { pathGeometry.Figures[0] });
            Point outherPoint, outherTangent;
            outherGeometry.GetPointAtFractionLength(value, out outherPoint, out outherTangent);
            return outherPoint;
        }

        private bool CanCalculateValues()
        {
            if (IsIndeterminate)
            {
                if (_pieEllipse == null)
                    return false;
                if (_itemsPanel == null)
                    return false;
                return true;
            }
            if (DisplayKind == EllipsedProgressBarKind.Pie)
                return _pieEllipse != null && _outherEllipse != null && _innerEllipse != null;
            if (DisplayKind == EllipsedProgressBarKind.Pointer)
                return _pointerPath != null && _outherEllipse != null && _innerEllipse != null;
            return _itemsPanel != null && ItemsFactory != null;
        }
    }
}
