﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JLL_InternetConnection_Issues
{
    class UserPrompt
    {
        public static DialogResult Disclaimer(string userInput)

        {

            DialogResult dr = MessageBox.Show($"{userInput}", "Disclaimer", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);

            return dr;



        }

        //public static DialogResult UserConfirmation(string userInput)

        //{

        //   DialogResult dr = MessageBox.Show($"{userInput}", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);

        //    return dr;

        //}

        public static DialogResult FinalConfirmation(string userInput)

        {



            DialogResult dr = MessageBox.Show($"{userInput}", "Disclaimer", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);

            return dr;

        }



    }

}

