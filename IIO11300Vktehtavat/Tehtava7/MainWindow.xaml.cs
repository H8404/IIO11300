using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Tehtava7
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void txtPassword_TextChanged(object sender, TextChangedEventArgs e)
        {
            if((txtPassword.Text.Length < 8) || checkGategory() == 1 )
            {
                txtTulos.Background = Brushes.Orange;
                txtTulos.Text = "Bad";
            }
            if ((txtPassword.Text.Length > 8) && (checkGategory() == 2))
            {
                txtTulos.Background = Brushes.Yellow;
                txtTulos.Text = "Fair";
            }
            if ((txtPassword.Text.Length > 12) && (checkGategory() == 3))
            {
                txtTulos.Background = Brushes.LightGreen;
                txtTulos.Text = "Moderate";
            }
            if ((txtPassword.Text.Length > 16) && (checkGategory() == 4))
            {
                txtTulos.Background = Brushes.Green;
                txtTulos.Text = "Good";
            }

            txtIso.Text = countUpperCase().ToString();
            txtPieni.Text = countLowerCase().ToString();
            txtNumero.Text = countNumbers().ToString();
            txtErikoinen.Text = countSpecialCharacter().ToString();
        }

       private int countUpperCase()
        {
            int count = 0;
            for (int i = 0; i <txtPassword.Text.Length; i++)
            {
                if (char.IsUpper(txtPassword.Text[i])) count++;
            }
            return count;
        }

        private int countLowerCase()
        {
            int count = 0;
            for (int i = 0; i < txtPassword.Text.Length; i++)
            {
                if (char.IsLower(txtPassword.Text[i])) count++;
            }
            return count;
        }

        private int countNumbers()
        {
            int count = 0;
            for (int i = 0; i < txtPassword.Text.Length; i++)
            {
                if (char.IsNumber(txtPassword.Text[i])) count++;
            }
            return count;
        }

        private int countSpecialCharacter()
        {
            int count = 0;
            for (int i = 0; i < txtPassword.Text.Length; i++)
            {
                if (char.IsSymbol(txtPassword.Text[i])) count++;
            }
            return count;
        }

        private int checkGategory()
        {
            int count = 0;
            if(countUpperCase() != 0)
            {
                count++;
            }
            if (countLowerCase() != 0)
            {
                count++;
            }
            if (countNumbers() != 0)
            {
                count++;
            }
            if (countSpecialCharacter() != 0)
            {
                count++;
            }
            return count;
        }
    }
}
