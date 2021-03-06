﻿using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace View.Servicios
{
    public class DialogService
    {
        /// <summary>
        /// Método que muestra un mensaje el la pantalla actual.
        /// </summary>
        /// <param name="title">Cadena que representa el título que contendrá el mensaje.</param>
        /// <param name="message">Cadena que representa el mensaje que mostrará el mensaje.</param>
        /// <returns></returns>
        public async Task SendMessage(string title, string message)
        {
            //Obtenemos la pantalla actual, y casteamos para que se tome como tipo MetroWindow.
            var window = Application.Current.Windows.OfType<MetroWindow>().LastOrDefault();

            window.MetroDialogOptions.ColorScheme = MetroDialogColorScheme.Accented;

            //Verificamos que la pantalla que obtuvimos sea diferente de nulo.
            if (window != null)

                //Ejecutamos el método para mostrar el mensaje en la pantalla actual.
                await window.ShowMessageAsync(title, message);
        }

        /// <summary>
        /// Método que muestra un mensaje el la pantalla actual.
        /// </summary>
        /// <param name="title"></param>
        /// <param name="message"></param>
        /// <param name="setting"></param>
        /// <param name="style"></param>
        /// <returns></returns>
        public async Task<MessageDialogResult> SendMessage(string title, string message, MetroDialogSettings setting, MessageDialogStyle style)
        {
            //Obtenemos la pantalla actual, y casteamos para que se tome como tipo MetroWindow.
            var window = Application.Current.Windows.OfType<MetroWindow>().LastOrDefault();

            //Establecemos el color de acentuación para el dialog.
            window.MetroDialogOptions.ColorScheme = MetroDialogColorScheme.Accented;

            setting.ColorScheme = MetroDialogColorScheme.Accented;

            //Comprobamos que la ventana sea diferente de nulo.
            if (window != null)
            {
                //Ejecutamos el método para mostrar el mensaje. El resultado lo guardamos en una variable local.
                MessageDialogResult result = await window.ShowMessageAsync(title, message, style, setting);

                //Retornamos el resultado.
                return result;
            }
            else
                //Si la ventana no fue encontrada, retornamos un valor Negative.
                return MessageDialogResult.Negative;
        }

        /// <summary>
        /// Método que muestra un mensaje en una pantalla con un título en específico.
        /// </summary>
        /// <param name="title"></param>
        /// <param name="message"></param>
        /// <param name="setting"></param>
        /// <param name="style"></param>
        /// <param name="tittleWindow"></param>
        /// <returns></returns>
        public async Task<MessageDialogResult> SendMessage(string title, string message, MetroDialogSettings setting, MessageDialogStyle style, string tittleWindow)
        {
            //Obtenemos la pantalla con el título en específico., y casteamos para que se tome como tipo MetroWindow.
            var window = Application.Current.Windows.OfType<MetroWindow>().Where(x => x.Title.Equals(tittleWindow)).FirstOrDefault();

            //Establecemos el color de acentuación para el dialog.
            window.MetroDialogOptions.ColorScheme = MetroDialogColorScheme.Accented;

            setting.ColorScheme = MetroDialogColorScheme.Accented;

            //Comprobamos que la ventana sea diferente de nulo.
            if (window != null)
            {
                //Ejecutamos el método para mostrar el mensaje. El resultado lo guardamos en una variable local.
                MessageDialogResult result = await window.ShowMessageAsync(title, message, style, setting);

                //Retornamos el resultado.
                return result;
            }
            else
                //Si la ventana no fue encontrada, retornamos un valor Negative.
                return MessageDialogResult.Negative;
        }

        /// <summary>
        /// Método que muestra un mesaje modal con progress bar.
        /// </summary>
        /// <param name="title"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public async Task<ProgressDialogController> SendProgressAsync(string title, string message)
        {
            //Obtenemos la pantalla actual, y casteamos para que se tome como tipo MetroWindow.
            var window = Application.Current.Windows.OfType<MetroWindow>().LastOrDefault();

            //Creamos las configuraciones que va a tener el mensaje.
            MetroDialogSettings settings = new MetroDialogSettings();
            settings.AnimateShow = false;
            settings.AnimateHide = false;
            settings.ColorScheme = MetroDialogColorScheme.Accented;

            //Comprobamos que la ventana sea diferente de nulo.
            if (window != null)
            {
                //Ejecutamos el método para mostrar el mensaje. El resultado lo guardamos en una variable local.
                var Controller = await window.ShowProgressAsync(title, message, false, settings);

                //Ejecutamos el método para indicar que el mensaje no tiene un fin establecido.
                Controller.SetIndeterminate();

                //Retornamos el resultado.
                return Controller;
            }

            //Si la ventana es igual a nulo retornamos un null.
            return null;
        }
    }
}
