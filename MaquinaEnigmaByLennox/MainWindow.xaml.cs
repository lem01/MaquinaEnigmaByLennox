using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Media;


namespace MaquinaEnigmaByLennox
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        //sondio 
        SoundPlayer tecla = new SoundPlayer(@"C:\Users\CLIENTE\source\repos\MaquinaEnigmaByLennox\Teclear.wav"); 
        SoundPlayer mover = new SoundPlayer(@"C:\Users\CLIENTE\source\repos\MaquinaEnigmaByLennox\Mover.wav");

        /// /////////////////////////

        bool isClear = false;

        string letras;
        string reflector_1_1, reflector_1_2;
        string Rotor_1_1, Rotor_1_2;
        string Rotor_2_1, Rotor_2_2;
        string Rotor_3_1, Rotor_3_2;

        //para validad que no se precione un espacio
        string aux = "";
        string ValidaEspacio;
        int ascci;

        //para la saber posicion de las letras
        int positionLetter;

        //me sirven como variables auxiliares para encolar las letras
        Dictionary<string, string> R1 = new Dictionary<string, string>();
        Dictionary<string, string> R2 = new Dictionary<string, string>();
        Dictionary<string, string> R3 = new Dictionary<string, string>();

        public MainWindow()
        {
            InitializeComponent();
        }

        //funciones
        void Generar_rotores()
        {

            LbRotor1.Text = "A";
            LbRotor2.Text = "A";
            LbRotor3.Text = "A";
            /////////////////// se reinician todos los strings/////////////////////
            letras = "";
            Rotor_1_1 = "";
            Rotor_2_1 = "";
            Rotor_3_1 = "";
            reflector_1_1 = "";

            Rotor_1_2 = "";
            Rotor_2_2 = "";
            Rotor_3_2 = "";
            reflector_1_2 = "";
            //////////////////////////////////////////////////////////////////////
           
            for (char i = 'A'; i <= 'Z'; i++)
            {
                letras += i;
                Rotor_1_1 += i;
                Rotor_2_1 += i;
                Rotor_3_1 += i;
                reflector_1_1 += i;
            }

            Rotor_1_2 = "QKENVJBMPHZYGTSDACFILORUXW";
            Rotor_2_2 = "JLFDBAWSOKGCYUQMIETRPZXVNH";
            Rotor_3_2 = "ZWQKEXNDRHMGUOTJVLPYSIFCBA";
            reflector_1_2 = "NOPQRSTUVWXYZABCDEFGHIJKLM";

            /*  Et1_1.Text = "";
              Et1_2.Text = "";
              Et2_1.Text = "";
              Et2_2.Text = "";
              Et3_1.Text = "";
              Et3_2.Text = "";

              Et1_1.Text = Rotor_1_1;
              Et1_2.Text = Rotor_1_2;
              Et2_1.Text = Rotor_2_1;
              Et2_2.Text = Rotor_2_2;
              Et3_1.Text = Rotor_3_1;
              Et3_2.Text = Rotor_3_2;*/

            //int[,] R1 = new int[2, 26] { { 16, 23, 10, 5, 4, 11, 7, 19, 9, 13, 24, 2, 0, 1, 15, 6, 18, 20, 21, 17, 25, 12, 14, 8, 22, 3},
            //                             { 19, 6, 18, 5, 8, 0, 23, 13, 3, 16, 10, 1, 12, 2, 17, 9, 25, 14, 7, 15, 21, 11, 24, 4, 20, 22} };

            //int[,] R2 = new int[2, 26] { { 10, 14, 23, 8, 24, 1, 0, 13, 18, 16, 15, 22, 21, 6, 9, 17, 25, 11, 19, 2, 20, 12, 4, 3, 7, 5},
            //                             { 13, 15, 2, 1, 22, 23, 9, 8, 18, 17, 21, 11, 16, 24, 0, 10, 19, 5, 3, 12, 6, 7, 14, 25, 4, 20} };

            //int[,] R3 = new int[2, 26] { { 25, 0, 17, 10, 1, 12, 16, 11, 15, 9, 24, 2, 18, 21, 19, 7, 5, 3, 8, 6, 23, 22, 13, 14, 4, 20},
            //                             { 7, 16, 1, 9, 23, 5, 8, 11, 18, 15, 21, 6, 22, 10, 12, 25, 0, 19, 2, 14, 20, 17, 13, 4, 24, 3} };

        }

        void GirarRotor1_arriba()
        {
            R1.Clear();

            for (int i = 0; i < Rotor_1_1.Length; i++)
                R1.Add(Rotor_1_1[i].ToString(), Rotor_1_2[i].ToString());

            int ultimoCaracter = Rotor_1_1.Length -1;
            ///cambia de posicion un rotor
            //guardo la clave
            string key = Rotor_1_1[ultimoCaracter].ToString();
            //guardo el valor
            string value = R1[key];

            R1.Remove(key);

            Rotor_1_1 = "";
            Rotor_1_2 = "";

            Rotor_1_1 += key;
            Rotor_1_2 += value;

            foreach (var item in R1.Keys)
                Rotor_1_1 += item;

            foreach (var item in R1.Values)
                Rotor_1_2 += item;       

            //actualizamos el conentido del label
            LbRotor1.Text = "";
            LbRotor1.Text = Rotor_1_1[0].ToString();

            //actulizamos el contenido de los texbox
           /* Et1_1.Text = "";
            Et1_2.Text = "";
            Et1_1.Text = Rotor_1_1;
            Et1_2.Text = Rotor_1_2;*/
        }

        void GirarRotor2_arriba()
        {
            R2.Clear();

            for (int i = 0; i < Rotor_2_1.Length; i++)
                R1.Add(Rotor_2_1[i].ToString(), Rotor_2_2[i].ToString());

            int ultimoCaracter = Rotor_2_1.Length - 1;
            ///cambia de posicion un rotor
            //guardo la clave
            string key = Rotor_2_1[ultimoCaracter].ToString();
            //guardo el valor
            string value = R2[key];

            R2.Remove(key);

            Rotor_2_1 = "";
            Rotor_2_2 = "";

            Rotor_2_1 += key;
            Rotor_2_2 += value;

            foreach (var item in R2.Keys)
                Rotor_2_1 += item;

            foreach (var item in R2.Values)
                Rotor_2_2 += item;

            //actualizamos el conentido del label
            LbRotor2.Text = "";
            LbRotor2.Text = Rotor_2_1[0].ToString();

            //actulizamos el contenido de los texbox
           // Et2_1.Text = "";
            //Et2_2.Text = "";
            //Et2_1.Text = Rotor_2_1;
           // Et2_2.Text = Rotor_2_2;
        }

        void GirarRotor3_arriba()
        {
            R3.Clear();

            for (int i = 0; i < Rotor_3_1.Length; i++)
                R3.Add(Rotor_3_1[i].ToString(), Rotor_3_2[i].ToString());

            int ultimoCaracter = Rotor_3_1.Length - 1;
            ///cambia de posicion un rotor
            //guardo la clave
            string key = Rotor_3_1[ultimoCaracter].ToString();
            //guardo el valor
            string value = R3[key];

            R3.Remove(key);

            Rotor_3_1 = "";
            Rotor_3_2 = "";

            Rotor_3_1 += key;
            Rotor_3_2 += value;

            foreach (var item in R3.Keys)
                Rotor_3_1 += item;

            foreach (var item in R3.Values)
                Rotor_3_2 += item;

            //actualizamos el conentido del label
            LbRotor3.Text = "";
            LbRotor3.Text = Rotor_3_1[0].ToString();

            //actulizamos el contenido de los texbox
           /* Et3_1.Text = "";
            Et3_2.Text = "";
            Et3_1.Text = Rotor_3_1;
            Et3_2.Text = Rotor_3_2;*/
        }


        void GirarRotor1_abajo()
        {
            R1.Clear();
            for (int i = 0; i < Rotor_1_1.Length; i++)
                R1.Add(Rotor_1_1[i].ToString(), Rotor_1_2[i].ToString());

            ///cambia de posicion un rotor
            //guardo la clave
            string key = Rotor_1_1[0].ToString();
            //guardo el valor
            string value = R1[key];

            R1.Remove(key);

            Rotor_1_1 = "";
            Rotor_1_2 = "";
            foreach (var item in R1.Keys)
                Rotor_1_1 += item;

            foreach (var item in R1.Values)
                Rotor_1_2 += item;

            Rotor_1_1 += key;
            Rotor_1_2 += value;

            //actualizamos el conentido del label
            LbRotor1.Text = "";
            LbRotor1.Text = Rotor_1_1[0].ToString();


            //actulizamos el contenido de los texbox
           /* Et1_1.Text = "";
            Et1_2.Text = "";
            Et1_1.Text = Rotor_1_1;
            Et1_2.Text = Rotor_1_2;*/
        }

        void GirarRotor2_abajo()
        {
            R2.Clear();

            for (int i = 0; i < Rotor_2_1.Length; i++)
                R2.Add(Rotor_2_1[i].ToString(), Rotor_2_2[i].ToString());


            ///cambia de posicion un rotor
            //guardo la clave
            string key = Rotor_2_1[0].ToString();
            //guardo el valor
            string value = R2[key];

            //remuevo el valor 
            R2.Remove(key);

            Rotor_2_1 = "";
            Rotor_2_2 = "";
            foreach (var item in R2.Keys)
                Rotor_2_1 += item;


            foreach (var item in R2.Values)
                Rotor_2_2 += item;

            Rotor_2_1 += key;
            Rotor_2_2 += value;

            //actualizamos el contenido de los labels
            LbRotor2.Text = "";
            LbRotor2.Text = Rotor_2_1[0].ToString();

            //actualizamos el contenido de los textbox
           /* Et2_1.Text = "";
            Et2_2.Text = "";
            Et2_1.Text = Rotor_2_1;
            Et2_2.Text = Rotor_2_2;*/

        }

        void GirarRotor3_abajo()
        {
            R3.Clear();

            for (int i = 0; i < Rotor_3_1.Length; i++)
                R3.Add(Rotor_3_1[i].ToString(), Rotor_3_2[i].ToString());

            ///cambia de posicion un rotor
            //guardo la clave
            string key = Rotor_3_1[0].ToString();
            //guardo el valor
            string value = R3[key];

            //remuevo el valor 
            R3.Remove(key);

            Rotor_3_1 = "";
            Rotor_3_2 = "";
            foreach (var item in R3.Keys)
                Rotor_3_1 += item;


            foreach (var item in R3.Values)
                Rotor_3_2 += item;

            Rotor_3_1 += key;
            Rotor_3_2 += value;

            //actualizamos el valor de los labels
            LbRotor3.Text = "";
            LbRotor3.Text = Rotor_3_1[0].ToString();

            //actualizamos el valor de los texbox
          /*  Et3_1.Text = "";
            Et3_2.Text = "";
            Et3_1.Text = Rotor_3_1;
            Et3_2.Text = Rotor_3_2;*/
        }


        void Gira_rotor1()
        {
            //var primer_vuelta = rotores[a];
            //primer_vuelta = primer_vuelta[-1: ];

            R1.Clear();

            for (int i = 0; i < Rotor_1_1.Length; i++)
            {
                R1.Add(Rotor_1_1[i].ToString(), Rotor_1_2[i].ToString());
                //for (int j = 0; j <= Et2.Text.Length; j++) 
                //{
                //    R1.Add(Et1.Text[i].ToString(),Et2.Text[j].ToString());
                //}

            }

            ///cambia de posicion un rotor
            //guardo la clave
            string key = Rotor_1_1[0].ToString();
            //guardo el valor
            string value = R1[key];

            //remuevo el valor 
            R1.Remove(key);

            ////agregamos la clave que estaba de primero a la cola
            //R1.Add(key, value);
            //R1.Add("N", value);


            Rotor_1_1 = "";
            Rotor_1_2 = "";
            foreach (var item in R1.Keys)
                Rotor_1_1 += item;
            //Et1_1.Text += item;

            foreach (var item in R1.Values)
                Rotor_1_2 += item;
            //Et1_2.Text += item;

            //Et1_1.Text += key;
            //Et1_2.Text += value;

            Rotor_1_1 += key;
            Rotor_1_2 += value;

            //actualizamos el conentido del label
            LbRotor1.Text = "";
            LbRotor1.Text = Rotor_1_1[0].ToString();


            //actulizamos el contenido de los texbox
           /* Et1_1.Text = "";
            Et1_2.Text = "";
            Et1_1.Text = Rotor_1_1;
            Et1_2.Text = Rotor_1_2;*/

        }

        void Gira_rotor2()
        {
            //var primer_vuelta = rotores[a];
            //primer_vuelta = primer_vuelta[-1: ];

            R2.Clear();

            for (int i = 0; i < Rotor_2_1.Length; i++)
            {
                R2.Add(Rotor_2_1[i].ToString(), Rotor_2_2[i].ToString());
                //for (int j = 0; j <= Et2.Text.Length; j++) 
                //{
                //    R1.Add(Et1.Text[i].ToString(),Et2.Text[j].ToString());
                //}

            }

            ///cambia de posicion un rotor
            //guardo la clave
            string key = Rotor_2_1[0].ToString();
            //guardo el valor
            string value = R2[key];

            //remuevo el valor 
            R2.Remove(key);

            ////agregamos la clave que estaba de primero a la cola
            //R1.Add(key, value);
            //R1.Add("N", value);

            Rotor_2_1 = "";
            Rotor_2_2 = "";
            foreach (var item in R2.Keys)
                Rotor_2_1 += item;
            //Et2_1.Text += item;

            foreach (var item in R2.Values)
                Rotor_2_2 += item;
            //Et2_2.Text += item;

            Rotor_2_1 += key;
            Rotor_2_2 += value;

            //actualizamos el contenido de los labels
            LbRotor2.Text = "";
            LbRotor2.Text = Rotor_2_1[0].ToString();

            //actualizamos el contenido de los textbox
           /* Et2_1.Text = "";
            Et2_2.Text = "";
            Et2_1.Text = Rotor_2_1;
            Et2_2.Text = Rotor_2_2;*/

            //para girar el tercer rotor
            if (Rotor_2_1[0] == 'A')
            {
                Gira_rotor3();
            }

        }

        void Gira_rotor3()
        {
            //var primer_vuelta = rotores[a];
            //primer_vuelta = primer_vuelta[-1: ];

            R3.Clear();

            for (int i = 0; i < Rotor_3_1.Length; i++)
            {
                R3.Add(Rotor_3_1[i].ToString(), Rotor_3_2[i].ToString());
                //for (int j = 0; j <= Et2.Text.Length; j++) 
                //{
                //    R1.Add(Et1.Text[i].ToString(),Et2.Text[j].ToString());
                //}

            }

            ///cambia de posicion un rotor
            //guardo la clave
            string key = Rotor_3_1[0].ToString();
            //guardo el valor
            string value = R3[key];

            //remuevo el valor 
            R3.Remove(key);

            ////agregamos la clave que estaba de primero a la cola
            //R1.Add(key, value);
            //R1.Add("N", value);


            Rotor_3_1 = "";
            Rotor_3_2 = "";
            foreach (var item in R3.Keys)
                Rotor_3_1 += item;
            //Et3_1.Text += item;

            foreach (var item in R3.Values)
                Rotor_3_2 += item;
            //Et3_2.Text += item;

            Rotor_3_1 += key;
            Rotor_3_2 += value;


            //actualizamos el valor de los labels
            LbRotor3.Text = "";
            LbRotor3.Text = Rotor_3_1[0].ToString();

            //actualizamos el valor de los texbox
           /* Et3_1.Text = "";
            Et3_2.Text = "";
            Et3_1.Text = Rotor_3_1;
            Et3_2.Text = Rotor_3_2;*/

        }


        void Girar_rotores()
        {

            Gira_rotor1();

            if (LbRotor1.Text[0] == 'A')
                Gira_rotor2();

        }

        void Encriptar()
        {
            //L => V => P => B => W
            //con esto agarro la ultima letra que ah ingresado el usuario 
            int count = EtEntrada.Text.Length;
            string letterInput = EtEntrada.Text[count - 1].ToString();
            ////////////////////////////////////////////////////

            char auxLetter = ' ';

            ///encontrar la posicion que tendria en el abecedario la letra ingresada 
            for (int i = 0; i < letras.Length; i++)
            {
                if (letterInput.ToUpper() == letras[i].ToString())
                {
                    positionLetter = i;
                    break;
                    //auxLetter = Rotor_1_1[positionLetter];
                    //MessageBox.Show("posicion: "+positionLetter.ToString()+" letra: "+auxLetter);
                }
            }   

            //de R1_1 => R1_2 
            auxLetter = Rotor_1_1[positionLetter];
            for (int i = 0; i < letras.Length; i++)
            {
                if (auxLetter == Rotor_1_2[i])
                {
                    positionLetter = i;
                    auxLetter = Rotor_1_2[positionLetter];
                    //MessageBox.Show("posicion: " + positionLetter.ToString() + " letra: " + auxLetter);
                    break;
                }
            }

            //de R2_1 => R2_2
            auxLetter = Rotor_2_1[positionLetter];
            for (int i = 0; i < letras.Length; i++)
            {
                if (auxLetter == Rotor_2_2[i])
                {
                    positionLetter = i;
                    auxLetter = Rotor_2_2[positionLetter];
                    //MessageBox.Show("posicion: " + positionLetter.ToString() + " letra: " + auxLetter);
                    break;
                }
            }

            //de R3_1 => R3_2
            auxLetter = Rotor_3_1[positionLetter];
            for (int i = 0; i < letras.Length; i++)
            {
                if (auxLetter == Rotor_3_2[i])
                {
                    positionLetter = i;
                    auxLetter = Rotor_3_2[positionLetter];
                    //MessageBox.Show("posicion: " + positionLetter.ToString() + " letra: " + auxLetter);
                    break;
                }
            }


            //de R3_2 => reflector 
            auxLetter = reflector_1_1[positionLetter];
            //MessageBox.Show(auxLetter.ToString()+" "+ positionLetter.ToString());
            //EtSalida.Text += auxLetter; 
            EtSalida.Text += ReflectorVuelta(auxLetter,positionLetter);

        }

        char ReflectorVuelta(char auxLetter, int position)
        {
            //
            auxLetter = reflector_1_2[position];
            //MessageBox.Show(auxLetter + " " + position.ToString());

            //de refelctor 2_2 => reflector_1_1
            for (int i = 0; i < letras.Length; i++)
            {
                if (auxLetter == reflector_1_1[i]) 
                {
                    position = i;
                    auxLetter = Rotor_1_1[position];
                    //MessageBox.Show(auxLetter + " " + position.ToString());
                    break;
                }
            }

            //reflector_1_1 => Rotor_3_2   Q => V
            auxLetter = Rotor_3_2[position];
            for (int i = 0; i < letras.Length; i++) 
            {
                if (auxLetter == Rotor_3_1[i]) 
                {
                    position = i;
                    auxLetter = Rotor_3_1[position];
                    //MessageBox.Show(auxLetter + " " + position.ToString());
                    break;
                }
            }

            //de rotor3_1 => rotor2_2  V => Z
            auxLetter = Rotor_2_2[position];
            for (int i = 0; i < letras.Length; i++)
            {
                if (auxLetter == Rotor_2_1[i])
                {
                    position = i;
                    auxLetter = Rotor_2_1[position];
                    break;
                }
            }

            // de rotor_2_1 => rotor_1_2  Z => W
            auxLetter = Rotor_1_2[position];
            for (int i = 0; i < letras.Length; i++)
            {
                if (auxLetter == Rotor_1_1[i])
                {
                    position = i;
                    auxLetter = Rotor_1_1[position];
                    //MessageBox.Show(auxLetter + " " + position.ToString());
                    break;
                }
            }

            //de rotor 1_1 => letras   W => W
            auxLetter = letras[position];
            return auxLetter;
        }

         bool ValidarEpacios() {
            //con esto agarro la ultima letra que ah ingresado el usuario 
            int count = EtEntrada.Text.Length;
           
            if (EtEntrada.Text.Length > 1)
            {
                ValidaEspacio = EtEntrada.Text[count - 1].ToString();
                ascci = ValidaEspacio.ToUpper()[0];


            }   
            else
            {
                ValidaEspacio = EtEntrada.Text[0].ToString();
                ascci = ValidaEspacio[0];
                if(ascci == 32)
                {
                    ////EtEntrada.Text = "";
                    //for (int i = 0; i < EtEntrada.Text.Length; i++)
                    //    aux += EtEntrada.Text[i];
                    return true;
                }
               
            }
              
            ////////////////////////////////////////////////////
            ///
            //valido que no sea espacio ni back
             
            //MessageBox.Show(ascci.ToString());
            if (ascci == 32 )
            {
                //borro el espacio
                for (int i = 0; i < EtEntrada.Text.Length-1; i++)
                    aux += EtEntrada.Text[i];

                //EtEntrada.Text = "";
                //EtEntrada.Text = aux;
                return true;
            }      
            else
                return false;
        }
        ///////// IS LOAD FORM /////////////////////////////////////////////////////////////////////////

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Generar_rotores();
        }


        private void EtEnttada_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            int control = 0;
            string letter = e.Key.ToString();
            char num = ' ';
            if (letter.Length == 1)
            {
                num = char.Parse(letter);
                control = num;
            }

            if (control >= 65 && control <= 90)
                e.Handled = false;
            else
                e.Handled = true;

            //string inputText = e.Key.ToString();
            //  if (char.IsControl(Convert.ToChar(e.Key)))
            //      e.Handled = true;
            //  else
            //if (Convert.ToChar(e.Key.ToString()) == 'ñ' || Convert.ToChar(e.Key.ToString()) == 'Ñ')
            //      e.Handled = true;
            //  else
            //if (char.IsLetter(Convert.ToChar(e.Key.ToString())))
            //      e.Handled = false;
            //  else
            //      e.Handled = true;
        }

        private void EtEntrada_PrevewTextInput(object sender, TextCompositionEventArgs e)
        {
          

           
            //int character = Convert.ToInt32(Convert.ToChar(e.Text));
            //if ((character >= 65 && character <= 90) || (character >= 97 && character <= 122))
            //    e.Handled = false;
            //else
            //    e.Handled = true;
        }

      

        private void Et_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(isClear == false) 
            {
                Encriptar();
                Girar_rotores();
                tecla.Play();
            }
               
        }

        /// BOTONES QUE MUEVEN LAS LETRAS ARRIBA Y A BAJO///////////////////////
        private void Bnt_arriba_R1_click(object sender, RoutedEventArgs e)
        {
            GirarRotor1_arriba();
            mover.Play();
        }

        private void Bnt_arriba_R2_click(object sender, RoutedEventArgs e)
        {
            GirarRotor2_arriba();
            mover.Play();
        }

        private void Bnt_arriba_R3_click(object sender, RoutedEventArgs e)
        {
            GirarRotor3_arriba();
            mover.Play();
        }


        private void Btn_Abajo_Rotor1_Click(object sender, RoutedEventArgs e)
        {
            GirarRotor1_abajo();
            mover.Play();
        }

        private void Btn_Abajo_Rotor2_Click(object sender, RoutedEventArgs e)
        {
            GirarRotor2_abajo();
            mover.Play();
        }

        private void Btn_Abajo_Rotor3_Click(object sender, RoutedEventArgs e)
        {
            GirarRotor3_abajo();
            mover.Play();
        }

        private void BtnGirar_Click_1(object sender, RoutedEventArgs e)
        {
            Girar_rotores();
        }


        private void Btn_Limpiat_click(object sender, RoutedEventArgs e)
        {
            isClear = true;
            EtEntrada.Text = "";
            EtSalida.Text = "";
            isClear = false;
        }

        private void btn_Reset_click(object sender, RoutedEventArgs e)
        {
            Generar_rotores();
        }
    }
}
