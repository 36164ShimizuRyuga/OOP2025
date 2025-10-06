﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorld
{
    class ViewModel : BindableBase
    {
        public ViewModel() {
            ChangeMessageCommand = new DelegateCommand<string>(
                (par) => GreetingMessage = par,
                (par)=>GreetingMessage != par)
                .ObservesProperty(()=> GreetingMessage);
            

        }

        private string _greetingMessage = "Hello world!";
        public string GreetingMessage { 
            get=>_greetingMessage;
            set =>  SetProperty(ref _greetingMessage, value);

        }
        

        public string NewMessage1 { get; } ="Bye-bye woeld";
        public string NewMessage2 { get; } = "Long time no see,woeld!";
        public DelegateCommand<string> ChangeMessageCommand { get; }

    }
}
