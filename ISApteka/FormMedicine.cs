using ISApteka.Database;
using ISApteka.Database.Models;
using ISApteka.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static ISApteka.Entities.Enums;

namespace ISApteka
{
    public partial class FormMedicine : Form
    {
        private FormCatalog FormCatalog { get; set; }
        private User User { get; set; }
        private Medicine Medicine { get; set; }
        private List<Store> Stores { get; set; }
        private List<Brand> Brands { get; set; }
        private Repository Repository { get; }
        private Mode Mode { get; set; }
        private int MedicineId { get; set; }


        public FormMedicine(User user, Repository repository, FormCatalog formCatalog, int medicineId, Mode mode)
        {
            InitializeComponent();

            Repository = repository;
            FormCatalog = formCatalog;
            User = user;
            Stores = formCatalog.Stores;
            Mode = mode;
            MedicineId = medicineId;
            
            //  buttons
            if (Mode == Mode.Read)
            {
                buConfirm.Visible = false;
                buDelete.Visible = false;
            }
            if (Mode == Mode.Add)
            {
                buConfirm.Text = "Добавить";
                buDelete.Visible = false;
            }

            Task.Run(() => this.InintializeMedicine(medicineId)).Wait();
            buConfirm.Click += BuConfirm_Click;
            buDelete.Click += BuDelete_Click;
        }

        private async void BuDelete_Click(object sender, EventArgs e)
        {
            await Repository.DeleteByIdIntoStore(MedicineId);
            await Repository.DeleteByIdIntoMedicines(MedicineId);
            await FormCatalog.DataBinding();
            this.Hide();
        }

        private async void BuConfirm_Click(object sender, EventArgs e)
        {
            if (Mode == Mode.Add)
            {
                await CreateMedicine();
            }
            else if (Mode == Mode.Edit)
            {
                await UpdateMedicine(MedicineId);
            }
            await FormCatalog.DataBinding();
            this.Hide();
        }


        private async Task UpdateMedicine(int medicineId)
        {
            var selectedItem = (Item)coBrand.SelectedItem;
            Medicine = new()
            {
                Id = medicineId,
                Name = teName.Text,
                Description = teDescription.Text,
                Instruction = teInstruction.Text,
                Composition = teComposition.Text,
                Form = teForm.Text,
                IsPrescription = chIsPrescription.Checked,
                Amount = teAmount.Text,
                BrandId = selectedItem != null ? selectedItem.Value : null
            };


            await Repository.UpdateByIdIntoMedicines(Medicine);
            Store store = new()
            {
                MedicineId = medicineId,
                Amount = Convert.ToInt32(teTotal.Text),
                Cost = Convert.ToDouble(teCost.Text.Replace(".", ",")),
                Place = tePlace.Text
            };
            await Repository.UpdateByMedicineIdIntoStore(store);
        }


        private async Task CreateMedicine()
        {
            var selectedItem = (Item)coBrand.SelectedItem;
            Medicine = new()
            {
                Name = teName.Text,
                Description = teDescription.Text,
                Instruction = teInstruction.Text,
                Composition = teComposition.Text,
                Form = teForm.Text,
                IsPrescription = chIsPrescription.Checked,
                Amount = teAmount.Text,
                BrandId = selectedItem != null ? selectedItem.Value : null
            };

            
            var id = await Repository.CreateIntoMedicines(Medicine);
            Store store = new()
            {
                MedicineId = id,
                Amount = Convert.ToInt32(teTotal.Text),
                Cost = Convert.ToDouble(teCost.Text.Replace(".",",")),
                Place = tePlace.Text
            };
            await Repository.CreateIntoStore(store);
        }


        private async Task InintializeMedicine(int medicineId)
        {
            try
            {
                // comboBox insert
                Brands = new();
                Brands = await Repository.GetAllFromBrands();
                coBrand.DisplayMember = "Text";
                coBrand.ValueMember = "Value";
                foreach (var brand in Brands)
                {
                    coBrand.Items.Add(new Item() { Text = brand.Name, Value = brand.Id });
                }

                // edit or read
                if (Mode != Mode.Add)
                {
                    Medicine = new();
                    Medicine = await Repository.GetByIdFromMedicines(medicineId);
                    // data from Medicines
                    teName.Text = Medicine.Name;
                    teAmount.Text = Medicine.Amount;
                    teForm.Text = Medicine.Form;
                    teComposition.Text = Medicine.Composition;
                    teInstruction.Text = Medicine.Instruction;
                    teDescription.Text = Medicine.Description;                
                    chIsPrescription.Checked = Medicine.IsPrescription;

                    var hasTotal = false;
                    // data from Stores
                    foreach (var store in Stores)
                    {
                        if (store.MedicineId == Medicine.Id)
                        {
                            tePlace.Text = store.Place ?? "";
                            teCost.Text = $"{store.Cost}";
                            if (store.Amount != null)
                            {
                                teTotal.Text = store.Amount.Value.ToString();
                                hasTotal = true;
                            }
                        }
                    }
                    if (hasTotal == false)
                    {
                        teTotal.Text = "0";
                    }

                    // data from Brands
                    if (Medicine.BrandId != null)
                    {
                        Brand selectedBrand = await Repository.GetByIdFromBrands(Medicine.BrandId.Value);
                        coBrand.SelectedItem = new Item() { Text = selectedBrand.Name, Value = selectedBrand.Id };
                        foreach (var item in coBrand.Items)
                        {
                            var selectedItem = (Item)item;
                            if (selectedItem.Value == selectedBrand.Id)
                            {
                                coBrand.SelectedItem = selectedItem;
                            }
                        }                        
                    }
                }



                if (Mode == Mode.Read)
                {
                    teName.ReadOnly = true;
                    teAmount.ReadOnly = true;
                    teForm.ReadOnly = true;
                    teComposition.ReadOnly = true;
                    teInstruction.ReadOnly = true;
                    teDescription.ReadOnly = true;
                    chIsPrescription.Enabled = false;
                    coBrand.Enabled = false;
                    teTotal.ReadOnly = true;
                    tePlace.ReadOnly = true;
                    teCost.ReadOnly = true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }     
    }
}
