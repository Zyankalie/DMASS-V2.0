using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace DMASS
{
    public abstract class Tab : TabItem 
    {
        public Tab()
        {
            //CloseCommand = new ActionCommand(p => CloseRequested?.Invoke(this, EventArgs.Empty));
            CloseableHeader cth = new CloseableHeader();
            this.Header = cth;
            // Attach to the CloseableHeader events
            // (Mouse Enter/Leave, Button Click, and Label resize)
            cth.button_close.MouseEnter +=
               new MouseEventHandler(button_close_MouseEnter);
            cth.button_close.MouseLeave +=
               new MouseEventHandler(button_close_MouseLeave);
            cth.button_close.Click +=
               new RoutedEventHandler(button_close_Click);
            cth.label_TabTitle.SizeChanged +=
               new SizeChangedEventHandler(label_TabTitle_SizeChanged);

            // Button MouseEnter - When the mouse is over the button - change color to Red
            void button_close_MouseEnter(object sender, MouseEventArgs e)
            {
                ((CloseableHeader)this.Header).button_close.Foreground = Brushes.Red;
            }
            // Button MouseLeave - When mouse is no longer over button - change color back to black
            void button_close_MouseLeave(object sender, MouseEventArgs e)
            {
                ((CloseableHeader)this.Header).button_close.Foreground = Brushes.Black;
            }
            // Button Close Click - Remove the Tab - (or raise
            // an event indicating a "CloseTab" event has occurred)
            void button_close_Click(object sender, RoutedEventArgs e)
            {
                ((Tab)this).CloseRequested(this, e);
            }
            // Label SizeChanged - When the Size of the Label changes
            // (due to setting the Title) set position of button properly
            void label_TabTitle_SizeChanged(object sender, SizeChangedEventArgs e)
            {
                ((CloseableHeader)this.Header).button_close.Margin = new Thickness(
                   ((CloseableHeader)this.Header).label_TabTitle.ActualWidth + 5, 3, 4, 0);
            }
        }

        protected override void OnSelected(RoutedEventArgs e)
        {
            base.OnSelected(e);
            ((CloseableHeader)this.Header).button_close.Visibility = Visibility.Visible;
        }

        protected override void OnUnselected(RoutedEventArgs e)
        {
            base.OnUnselected(e);
            ((CloseableHeader)this.Header).button_close.Visibility = Visibility.Hidden;
        }

        
        protected override void OnMouseEnter(MouseEventArgs e)
        {
            base.OnMouseEnter(e);
            ((CloseableHeader)this.Header).button_close.Visibility = Visibility.Visible;
        }

        
        protected override void OnMouseLeave(MouseEventArgs e)
        {
            base.OnMouseLeave(e);
            if (!this.IsSelected)
            {
                ((CloseableHeader)this.Header).button_close.Visibility = Visibility.Hidden;
            }
        }

        public string Title
        {
            set
            {
                ((CloseableHeader)this.Header).label_TabTitle.Content = value;
            }
        }
        public ICommand CloseCommand { get; }
        public event EventHandler CloseRequested;    
    }
}
