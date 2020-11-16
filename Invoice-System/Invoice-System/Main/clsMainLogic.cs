using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Invoice_System.Model;

namespace Invoice_System.Main
{
    /// <summary>
    /// Logic Class for Main Window
    /// </summary>
    public class clsMainLogic : INotifyPropertyChanged
    {
        private clsMainSQL db = clsMainSQL.Instance;
        private Invoice _currentInvoice;

        public clsMainLogic()
        {
            Items = db.GetAllItems();
            CurrentInvoice = null;
            SaveInvoiceCommand = new SimpleCommand(SaveInvoice);
            CreateInvoiceCommand = new SimpleCommand(CreateInvoice);
            RemoveInvoiceCommand = new SimpleCommand(RemoveInvoice);
            AddItemCommand = new SimpleCommand(AddItem);
            DeleteItemCommand = new SimpleCommand(DeleteItem);
            ShowSearchInvoiceWindowCommand = new SimpleCommand(ShowSearchInvoiceWindow);
            ShowItemsListWindowCommand = new SimpleCommand(ShowItemsListWindow);
        }

        private void ShowItemsListWindow(object o)
        {
            //todo:Invoke the ItemsList window,and handle the result


            //update items:
            Items = db.GetAllItems();
        }

        private void ShowSearchInvoiceWindow(object o)
        {
            //todo:Invoke the search window,and handle the result
        }

        private void SaveInvoice(object o)
        {
            if (this.CurrentInvoice.Number == null)
            {
                var newId = db.InsertNewInvoice(this.CurrentInvoice);
                this.CurrentInvoice = db.GetInvoiceByID(newId);
            }
            else
            {
                db.UpdateDate(this.CurrentInvoice);
            }
        }

        private void CreateInvoice(object o)
        {
            this.CurrentInvoice = new Invoice();
        }

        private void RemoveInvoice(object o)
        {
            db.DeleteInvoice(this.CurrentInvoice);
            this.CurrentInvoice = null;
        }

        private void AddItem(object o)
        {
            CurrentInvoice.Items.Add(NewItem);
        }

        private void DeleteItem(object o)
        {
            CurrentInvoice.Items.Remove(SelectedItem);
        }


        public Invoice CurrentInvoice
        {
            get => _currentInvoice;
            set
            {
                _currentInvoice = value;
                RaisePropertyChanged(nameof(CurrentInvoice));
            }
        }
        //the item from CurrentInvoice's items,which is selected in the data grid:
        public Item SelectedItem { get; set; }
        public List<Item> Items { get; set; }
        public Item NewItem { get; set; }
        public SimpleCommand CreateInvoiceCommand { get; set; }
        public SimpleCommand SaveInvoiceCommand { get; set; }
        public SimpleCommand RemoveInvoiceCommand { get; set; }
        public SimpleCommand AddItemCommand { get; set; }
        public SimpleCommand DeleteItemCommand { get; set; }
        public SimpleCommand ShowSearchInvoiceWindowCommand { get; set; }
        public SimpleCommand ShowItemsListWindowCommand { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
