using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace IChat.User_Control
{
    public class ControlBar_ViewModel : BaseViewModel
    {
        public ICommand Minimize_Command { get; set; }
        public ICommand Maximize_Command { get; set; }
        public ICommand Close_Command { get; set; }
        public ICommand Drag_Command { get; set; }

        public ControlBar_ViewModel()
        {

            Minimize_Command = new RelayCommand<UserControl>(p =>
            {
                return true;
            }, p =>
            {
                Window windowparent = getParent(p) as Window;

                if (windowparent != null)
                {
                    windowparent.WindowState = WindowState.Minimized;
                }
            });

            Maximize_Command = new RelayCommand<UserControl>(p =>
            {
                return true;
            }, p =>
            {
                Window windowparent = getParent(p) as Window;

                if (windowparent != null)
                {
                    if (windowparent.WindowState == WindowState.Maximized)
                    {
                        windowparent.WindowState = WindowState.Normal;
                    }
                    else
                    {
                        windowparent.WindowState = WindowState.Maximized;
                    }
                }
            });


            Close_Command = new RelayCommand<UserControl>(p =>
            {
                return true;
            }, p =>
            {
                Window windowparent = getParent(p) as Window;

                if (windowparent != null)
                {
                    windowparent.Close();
                }
            });

            Drag_Command = new RelayCommand<UserControl>(p =>
            {
                return true;
            }, p =>
            {
                Window windowparent = getParent(p) as Window;

                if (windowparent != null)
                {
                    windowparent.DragMove();
                }

            });

        }

        private FrameworkElement getParent(UserControl uc)
        {
            FrameworkElement p = uc;
            while (p.Parent != null)
            {
                p = p.Parent as FrameworkElement;
            }
            return p;
        }
    }

    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }

    class RelayCommand<T> : ICommand
    {
        private readonly Predicate<T> _canExecute;
        private readonly Action<T> _execute;

        public RelayCommand(Predicate<T> canExecute, Action<T> execute)
        {
            if (execute == null)
                throw new ArgumentNullException("execute");

            _canExecute = canExecute;
            _execute = execute;
        }

        public bool CanExecute(object paramenter)
        {
            return _canExecute == null ? true : _canExecute((T)paramenter);
        }

        public void Execute(object paramenter)
        {
            _execute((T)paramenter);
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
    }
}
