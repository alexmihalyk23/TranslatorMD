using System;
using System.Speech.Synthesis;
using System.Windows;
using System.Windows.Input;
using TranslatorMD.Commands;

namespace TranslatorMD.ViewModels
{
    class MainWindowViewModel : ViewModelBase
    {
        private string _copyText;
        private string _speakText;

        SpeechSynthesizer talk = new SpeechSynthesizer();

        public DelegateCommand closeAppCommand;
       
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

        public string CopyText
        {
            get
            {
                
                return _copyText;
            }
            set
            {

                _copyText = value;
                OnPropertyChanged("CopyText");
            }
        }

        public string SpeakText
        {
            get
            {
                return _speakText;
            }
            set
            {

                _speakText = value;
                OnPropertyChanged("SpeakText");
            }
        }

        public DelegateCommand gitCommand;
        public ICommand GitCommand
        {
            get
            {
                if (gitCommand == null)
                {
                    gitCommand = new DelegateCommand(Git_Click);
                }

                return gitCommand;
            }
        }

        public DelegateCommand speakCommand;
        public ICommand SpeakCommand
        {
            get
            {
                if (speakCommand == null)
                {
                    speakCommand = new DelegateCommand(()=> {
                        talk.Speak(_speakText);
                    });
                }

                return speakCommand;
            }
        }

        public DelegateCommand copyCommand;
        public ICommand CopyCommand
        {
            get
            {
                if (copyCommand == null)
                {
                    copyCommand = new DelegateCommand(() => {
                        Clipboard.SetText(_copyText);
                    });
                }

                return copyCommand;
            }
        }

        private void Close_click()
        {
            Application.Current.Shutdown();
        }
        private void Git_Click()
        {
            System.Diagnostics.Process.Start("https://github.com/alexmihalyk23");
        }


    }
}

