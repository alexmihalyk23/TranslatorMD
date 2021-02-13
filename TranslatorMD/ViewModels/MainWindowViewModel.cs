using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net;
using System.Speech.Synthesis;
using System.Text;
using System.Windows;
using System.Windows.Input;
using TranslatorMD.Commands;
using TranslatorMD.Views;

namespace TranslatorMD.ViewModels
{
    class MainWindowViewModel : ViewModelBase
    {
        private string _copyText;
        private string _speakText;
        private string _inputText;
        private string _outputText;
        private string _selectedLang;
        private string _selectedLang_to;
        private string _apiKey;

        public static string apikey;

        class TransOutput
        {
            public string data;

        }


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
        public string InputText
        {
            get
            {
                return _inputText;
            }
            set
            {

                _inputText = value;
                OnPropertyChanged("InputText");
            }
        }

        public string OutputText
        {
            get
            {
                return  _outputText;

            }
            set
            {

                _outputText = value;
                OnPropertyChanged("OutputText");
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
                    speakCommand = new DelegateCommand(() =>
                    {
                        talk.Speak(Encoding.GetEncoding("UTF-8").GetString(Encoding.GetEncoding(1252).GetBytes(string.Join("", _outputText))));
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
                    copyCommand = new DelegateCommand(() =>
                    {
                        Clipboard.SetText(Encoding.GetEncoding("UTF-8").GetString(Encoding.GetEncoding(1252).GetBytes(string.Join("", _outputText))));
                });
                }

                return copyCommand;
            }
        }


        public string ApiKey
        {
            get
            {

                Console.WriteLine("get= " + _apiKey);
                return _apiKey;
            }
            set
            {
                apikey = value;




                _apiKey = value;
                OnPropertyChanged("ApiKey");


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

            public DelegateCommand translateCommand;
            //private startWindow startWindow;


            public ICommand TranslateCommand
            {
                get
                {
                    if (translateCommand == null)
                    {
                        translateCommand = new DelegateCommand(Translate);

                    }


                    return translateCommand;
                }
            }


        public string SelectedLang
        {
            get
            {
                Console.WriteLine(_selectedLang);
                return _selectedLang;
            }
            set
            {
                Console.WriteLine(_selectedLang);
                _selectedLang = value;
                OnPropertyChanged("SelectedLang");
            }
        }
        public List<string> Lang { get; } = new List<string> { "en", "ru", "uk", "de" };

        public string SelectedLang_to
        {
            get
            {
                Console.WriteLine(_selectedLang_to);
                return _selectedLang_to;
            }
            set
            {
                Console.WriteLine(_selectedLang_to);
                _selectedLang_to = value;
                OnPropertyChanged("SelectedLang_to");
            }
        }
        public List<string> Lang_to { get; } = new List<string> { "en", "ru", "uk", "de" };



        private void Translate()
        {

            try
            {
               
                using (WebClient webClient1 = new WebClient())
                {
                    webClient1.QueryString.Add("lang", SelectedLang + "-" + SelectedLang_to);
                    webClient1.QueryString.Add("as", "text");
                    webClient1.QueryString.Add("source", _inputText);
                    string result = webClient1.DownloadString("https://fasttranslator.herokuapp.com/api/v1/text/to/text");
                    Console.WriteLine(result);
                    var obj = JsonConvert.DeserializeObject<TransOutput>(result);
                    byte[] bytes = Encoding.Default.GetBytes(obj.data);
                    obj.data = Encoding.UTF8.GetString(bytes);


                    OutputText = obj.data;
                }

                
                
                
            }
            catch(WebException e)
            {
                MessageBox.Show("Connection Error", "Alert");
                
            }
            

        }



    }
}

