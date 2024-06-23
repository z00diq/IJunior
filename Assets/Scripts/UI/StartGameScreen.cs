﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.UI
{
    public class StartGameScreen : Window
    {
        public event Action StartButtonClick;

        protected override void OnButtonClick()
        {
            StartButtonClick?.Invoke();
            Close();
        }
    }
}
