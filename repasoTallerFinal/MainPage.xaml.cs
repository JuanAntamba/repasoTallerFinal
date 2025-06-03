using System;
using Microsoft.Maui.Controls;
using System.Collections.Generic;

namespace repasoTallerFinal;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
        operadorPicker.ItemsSource = new List<string> { "Movistar", "Claro", "Tuenti", "CNT" };
    }

    private void OnMontoCheckedChanged(object sender, CheckedChangedEventArgs e)
    {
        if (sender is RadioButton rb && rb.IsChecked)
        {
            seleccionLabel.Text = $"Ha seleccionado la recarga de: {rb.Content}";
        }
    }

    private async void OnRecargarClicked(object sender, EventArgs e)
    {
        string numero = numeroEntry.Text;
        string operador = operadorPicker.SelectedItem?.ToString();
        string monto = null;

        if (monto3Radio.IsChecked) monto = "3";
        else if (monto5Radio.IsChecked) monto = "5";
        else if (monto10Radio.IsChecked) monto = "10";

        if (string.IsNullOrWhiteSpace(numero) || operador == null || monto == null)
        {
            await DisplayAlert("Error", "Por favor complete todos los campos", "OK");
            return;
        }

        bool confirm = await DisplayAlert("CONFIRMAR",
            $"¿Desea recargar ${monto} al número {numero} con operador {operador}?",
            "Sí", "Cancelar");

        if (confirm)
        {
            await DisplayAlert("FINALIZADO", "Recarga exitosa", "OK");
        }
    }
}
