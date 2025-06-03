using System;
using Microsoft.Maui.Controls;

namespace repasoTallerFinal;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();

        operadorPicker.ItemsSource = new List<string> { "Movistar", "Claro", "Tuenti", "CNT" };
    }

    private async void OnRecargarClicked(object sender, EventArgs e)
    {
        string numero = numeroEntry.Text;
        string operador = operadorPicker.SelectedItem?.ToString();
        string monto = null;

        if (monto3Check.IsChecked) monto = "3";
        else if (monto5Check.IsChecked) monto = "5";
        else if (monto10Check.IsChecked) monto = "10";

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

    private void OnMontoCheckedChanged(object sender, CheckedChangedEventArgs e)
    {
        // Desmarcar otros para simular comportamiento tipo radio
        if (sender == monto3Check && e.Value)
        {
            monto5Check.IsChecked = false;
            monto10Check.IsChecked = false;
            seleccionLabel.Text = "Ha seleccionado la recarga de: $3";
        }
        else if (sender == monto5Check && e.Value)
        {
            monto3Check.IsChecked = false;
            monto10Check.IsChecked = false;
            seleccionLabel.Text = "Ha seleccionado la recarga de: $5";
        }
        else if (sender == monto10Check && e.Value)
        {
            monto3Check.IsChecked = false;
            monto5Check.IsChecked = false;
            seleccionLabel.Text = "Ha seleccionado la recarga de: $10";
        }
        else if (!monto3Check.IsChecked && !monto5Check.IsChecked && !monto10Check.IsChecked)
        {
            seleccionLabel.Text = "";
        }
    }
}
