using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;

namespace Voorbeelden_DataSet
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

        private DataView dvStud;
        private DataTable dt;
        private DataSet ds;

        private void BtnDatasetCreate_Click(object sender, RoutedEventArgs e)
        {
            ds = new DataSet();
            dt = new DataTable("Stud");

            // Kolommen declareren 
            DataColumn dcStudId = new DataColumn("StudId", typeof(int));
            DataColumn dcNaam = new DataColumn("Naam", typeof(string));
            DataColumn dcOpleiding = new DataColumn("Opleiding", typeof(string));
            DataColumn dcGbDatum = new DataColumn("GbDatum", typeof(DateTime));

            // Kolommen toevoegen aan DataColumnCollection.
            dt.Columns.Add(dcStudId);
            dt.Columns.Add(dcNaam);
            dt.Columns.Add(dcOpleiding);
            dt.Columns.Add(dcGbDatum);

            // Extra kolom met verschillende kenmerken.
            DataColumn dcTel = new DataColumn
            {
                ColumnName = "Telefoon",
                DataType = typeof(string),
                Unique = true,
                ReadOnly = false
            };
            dt.Columns.Add(dcTel);

            // Primaire sleutel aanduiden.
            DataColumn[] sleutel = { dcStudId }; // kunnen meerdere kolommen zijn => dus type array 
            dt.PrimaryKey = sleutel;

            // Unieke constraint voor naam toepassen.
            UniqueConstraint uniek = new UniqueConstraint(dcNaam);

            // Rijen toevoegen aan DataTable
            dt.Rows.Add(new object[] { 1, "Kristof Palmaers", "Graduaat Programmeren", "17/08/1980", "011775100" });
            dt.Rows.Add(new object[] { 2, "Paul Dox", "Graduaat Digitale vormgeving", "17/03/1972", "011775101" });
            dt.Rows.Add(new object[] { 3, "Patricia Briers", "Graduaat Systemen en netwerken", "17/10/1971", "011775102" });
            dt.Rows.Add(new object[] { 4, "Jasper Beuls", "Graduaat Programmeren", "17/08/1990", "011775103" });
            dt.Rows.Add(new object[] { 5, "Laila Janssen", "Graduaat Programmeren", "17/04/1990", "011775104" });


            // Rij toevoegen met DataRow
            DataRow rij = dt.NewRow();
            rij[dcStudId] = 6;
            rij[dcNaam] = "Ann Das";
            rij[dcOpleiding] = "Graduaat Systemen en netwerken";
            rij[dcGbDatum] = "1990/12/15 18:35:10";
            rij[dcTel] = "011775105";
            dt.Rows.Add(rij);

            // Tabel toevoegen aan dataset
            ds.Tables.Add(dt);

            // Afdruk in component DataGrid
            //DataView dv = ds.Tables["Stud"].DefaultView;
            dvStud = ds.Tables["Stud"].DefaultView;
            DataGridStud.ItemsSource = dvStud;

            // Uitvoer als XML
            dt.WriteXml(@"..\stud.xml");
        }

        private void BtnNaamTelefoon_Click(object sender, RoutedEventArgs e)
        {

             // === Afdruk Listbox ===
            LbxFuncties.ItemsSource = dvStud;
            LbxFuncties.DisplayMemberPath = "Naam"; // Je kan hier kiezen welke kolom je wenst te zien in je listbox.


            // === Afdruk in tekstvak ===
            TxtResultaat.Clear();
            for (int i = 0; i < dvStud.Count; i++)
            {
                TxtResultaat.Text += $"{dvStud[i]["Naam"]} {dvStud[i]["Telefoon"]}\r\n";
            }

            // Afdruk in component DataGrid -- afdruk opnieuw als je naar andere knoppen geweest bent
            dvStud = ds.Tables["Stud"].DefaultView;
            DataGridStud.ItemsSource = dvStud;
        }

        private void BtnNaamE_Click(object sender, RoutedEventArgs e)
        {
            // ===  Nieuwe DATA VIEW  ===
            DataView dv2 = new DataView(dt);
            dv2.RowFilter = "Naam like '%er%'";
            dv2.Sort = "naam";

            LbxFuncties.ItemsSource = dv2;
            LbxFuncties.DisplayMemberPath = "Naam"; // kolomnamen respecteren!!!
                                                    // 3de dataview

            // === Afdruk in DataGrid
            DataGridStud.ItemsSource = dv2;

            TxtResultaat.Clear();
            foreach (DataRowView item in dv2)  // Geeft telkens 1 rij dus daarom foreach
            {
                TxtResultaat.Text += $"{item.Row["Naam"]}  {item.Row["GbDatum"]}\r\n";
            }
        }

        private void BtnProgrammeren_Click(object sender, RoutedEventArgs e)
        {
            // ===  Nieuwe DATA VIEW  ===
            DataView dv3 = new DataView(dt);
            dv3.Sort = "Opleiding desc";
            DataRowView[] drv = dv3.FindRows("Graduaat Programmeren"); // zoekt op opgegeven sorteersleutel.

            // === Afdruk in DataGrid
            DataGridStud.ItemsSource = dv3;

            LbxFuncties.ItemsSource = drv;
            LbxFuncties.DisplayMemberPath = "Naam"; // kolomnamen respecteren!!!
                                                    // 3de dataview

            TxtResultaat.Clear();
            foreach (DataRowView item in drv)  // Geeft telkens 1 rij dus daarom foreach
            {
                TxtResultaat.Text += $"{item.Row["Naam"]}  {item.Row["Opleiding"]}\r\n";
            }

        }
    }
        }




















