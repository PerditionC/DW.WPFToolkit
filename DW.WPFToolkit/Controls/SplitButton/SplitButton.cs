﻿using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace DW.WPFToolkit.Controls
{
    /// <summary>
    /// Shows a button which can be clicked but also expanded to call commands from child elements.
    /// </summary>
    [TemplatePart(Name = "PART_ContentButton", Type = typeof(SplitToggleButton))]
    public class SplitButton : ComboBox
    {
        static SplitButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(SplitButton), new FrameworkPropertyMetadata(typeof(SplitButton)));
#if TRIAL
            License1.License.Display();
#endif
        }

        /// <summary>
        /// The template gets added to the control.
        /// </summary>
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            var content = GetTemplateChild("PART_ContentButton") as SplitToggleButton;
            if (content != null)
                content.Click += new RoutedEventHandler(Content_Click);
        }

        private void Content_Click(object sender, RoutedEventArgs e)
        {
            CallClickEvent();
            CallCommand();
        }

        /// <summary>
        /// Gets or sets the command to be called when the button itself is clicked.
        /// </summary>
        [DefaultValue(null)]
        public ICommand Command
        {
            get { return (ICommand)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="DW.WPFToolkit.Controls.SplitButton.Command" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty CommandProperty =
            DependencyProperty.Register("Command", typeof(ICommand), typeof(SplitButton), new UIPropertyMetadata(null));

        /// <summary>
        /// Gets or sets the parameter to be passed with the <see cref="DW.WPFToolkit.Controls.SplitButton.Command" />.
        /// </summary>
        [DefaultValue(null)]
        public object CommandParameter
        {
            get { return (object)GetValue(CommandParameterProperty); }
            set { SetValue(CommandParameterProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="DW.WPFToolkit.Controls.SplitButton.CommandParameter" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty CommandParameterProperty =
            DependencyProperty.Register("CommandParameter", typeof(object), typeof(SplitButton), new UIPropertyMetadata(null));

        /// <summary>
        /// Occurs when the main button is clicked.
        /// </summary>
        public event RoutedEventHandler Click
        {
            add { AddHandler(ClickEvent, value); }
            remove { RemoveHandler(ClickEvent, value); }
        }

        /// <summary>
        /// Identifies the <see cref="DW.WPFToolkit.Controls.SplitButton.Click" /> routed event.
        /// </summary>
        public static readonly RoutedEvent ClickEvent = EventManager.RegisterRoutedEvent("Click", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(SplitButton));

        private void CallClickEvent()
        {
            var newEventArgs = new RoutedEventArgs(SplitButton.ClickEvent);
            RaiseEvent(newEventArgs);
        }

        private void CallCommand()
        {
            if (Command != null &&
                Command.CanExecute(CommandParameter))
                Command.Execute(CommandParameter);
        }

        /// <summary>
        /// Gets or sets the main content of the button.
        /// </summary>
        [DefaultValue(null)]
        public object Content
        {
            get { return (object)GetValue(ContentProperty); }
            set { SetValue(ContentProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="DW.WPFToolkit.Controls.SplitButton.Content" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty ContentProperty =
            DependencyProperty.Register("Content", typeof(object), typeof(SplitButton), new UIPropertyMetadata(null));

        /// <summary>
        /// Generates a new child item container to hold in the <see cref="DW.WPFToolkit.Controls.SplitButton" />.
        /// </summary>
        /// <returns>The generated child item container</returns>
        protected override DependencyObject GetContainerForItemOverride()
        {
            return new SplitButtonItem();
        }

        /// <summary>
        /// Checks if the item is already the correct item container. If not the <see cref="DW.WPFToolkit.Controls.SplitButton.GetContainerForItemOverride" /> will be used to generate the right container.
        /// </summary>
        /// <param name="item">The item to shown in the <see cref="DW.WPFToolkit.Controls.SplitButton" />.</param>
        /// <returns>True if the item is the correct item container already.</returns>
        protected override bool IsItemItsOwnContainerOverride(object item)
        {
            return item is SplitButtonItem;
        }
    }
}
