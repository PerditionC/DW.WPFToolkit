﻿#region License
/*
The MIT License (MIT)

Copyright (c) 2009-2014 David Wendland

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in
all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
THE SOFTWARE
*/
#endregion License

using System.Windows;
using System.Windows.Controls;

namespace DW.WPFToolkit.Controls
{
    public class WPFMessageBoxDetailsButtonControl : Expander
    {
        static WPFMessageBoxDetailsButtonControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(WPFMessageBoxDetailsButtonControl), new FrameworkPropertyMetadata(typeof(WPFMessageBoxDetailsButtonControl)));
        }

        public string CollapsedHeaderText
        {
            get { return (string)GetValue(CollapsedHeaderTextProperty); }
            set { SetValue(CollapsedHeaderTextProperty, value); }
        }

        public static readonly DependencyProperty CollapsedHeaderTextProperty =
            DependencyProperty.Register("CollapsedHeaderText", typeof(string), typeof(WPFMessageBoxDetailsButtonControl), new UIPropertyMetadata(null));

        public string ExpandedHeaderText
        {
            get { return (string)GetValue(ExpandedHeaderTextProperty); }
            set { SetValue(ExpandedHeaderTextProperty, value); }
        }

        public static readonly DependencyProperty ExpandedHeaderTextProperty =
            DependencyProperty.Register("ExpandedHeaderText", typeof(string), typeof(WPFMessageBoxDetailsButtonControl), new UIPropertyMetadata(null));
    }
}
