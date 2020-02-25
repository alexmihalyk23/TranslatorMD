using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using TranslatorMD.Commands;

namespace TranslatorMD.ViewModels
{
    class WindowButton : ViewModelBase
    {
        #region Commands
        #region Exit

        private DelegateCommand closeAppCommand;

        public ICommand CloseAppCommand
        {
            get
            {
                if (closeAppCommand == null)
                {
                    closeAppCommand = new DelegateCommand(Close_click);
                    
                }
                return closeAppCommand;

                
            }
            
        }

        private void Close_click()
        {
            Application.Current.Shutdown();
        }



        #endregion
        #endregion
    }
}
