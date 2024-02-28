using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;

namespace Controlar_Banda
{
    public partial class Form1 : Form
    {

        //Variable que llevara el conteo de las cajas
        int contador = 0;

        public Form1()
        {
            InitializeComponent();
           
        }

        //Metodo que recibi el caracter por medio del puerto USB
        private void SerialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            // Lee el carácter recibido del puerto COM
            char CaracterRecibido = (char)serialPort1.ReadByte();

            // Si el carácter recibido es '1', incrementa el contador y actualiza el numero
            if (CaracterRecibido == '1')
            {
                //Le aumenta 1 a la variable contador
                contador++;
                //Metodo que actualiza el valor del contador
                Invoke(new Action(() => { Contador.Text = contador.ToString(); }));
            }
        }


        //Metodo que se usa cuando se presiona el boton de encender
        private void botonEncender_Click(object sender, EventArgs e)
        {
            try//Si todo se ejecuta correctamente
            {

                // Suscribe al evento DataReceived al manejador SerialPort1_DataReceived
                serialPort1.DataReceived += SerialPort1_DataReceived;

                //Enviar el caracter al micro
                serialPort1.Write("E");
                label1Led.BackColor = Color.Lime; //Cambia el fondo a verde
                label1Led.Text = "ON"; //Cambia el texto a ON
                botonApagar.Enabled = true; //Habilita el boton de apagar
                botonEncender.Enabled = false; //Deshabilita el boton de encender

                pictureBox1.Enabled = true; //Hace que se mueva la imagen GIF

            }
            catch (Exception error)//En caso de algun error muestra el mensaje
            {
                MessageBox.Show(error.Message);
            }



        }

        //Se ejecuta cuando se inicia la aplicacion
        private void Form1_Load(object sender, EventArgs e)
        {
            try //En caso que todo funcione bien
            {

                botonApagar.Enabled = false; //Deshabilita el boton de apagar
                serialPort1.PortName = "COM7"; //Abre el puero USB
                serialPort1.Open(); //Abre el puerto para la comunicacion serial

            }
            catch (Exception error)//En caso de algun error muestre el mensaje
            {
                MessageBox.Show(error.Message);

            }




        }

        //Cuando se cierra la aplicacion 
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (serialPort1.IsOpen) //En el caso de estar abierto el puerto 
            {
                try//Si todo se ejecuta bien
                {
                    serialPort1.Close();//Se ciera el puero
                }
                catch (Exception error) //En caso de un error se muestra el mensaje
                {
                    MessageBox.Show(error.Message);
                }
            }
        }

        //Metodo que se aplica cuando se presiona el boton de apagar
        private void botonApagar_Click(object sender, EventArgs e)
        {
            try //Si todo sale bien
            {
                //Enviar codigo al micro el caracter A
                serialPort1.Write("A");
                label1Led.BackColor = Color.Red; //Cambia el color del fondo del texto a rojo
                label1Led.Text = "OFF"; //Cambia el texto a OFF
                botonApagar.Enabled = false; //Deshabilita el boton de Apagar
                botonEncender.Enabled = true;//Habilita el boton de apagar


                contador = 0; // Reinicia el contador al presionar "Apagar"
                Contador.Text = "0"; // Actualiza el Label del contador

                pictureBox1.Enabled = false; //Pausa la imagen GIF
            }
            catch (Exception error) //Muestra el error en el caso de haberlo
            {
                MessageBox.Show(error.Message);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }




        












    }
}
