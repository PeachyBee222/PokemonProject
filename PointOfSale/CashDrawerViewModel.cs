using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using RoundRegister;

namespace PokemonProject.PointOfSale
{
    /// <summary>
    /// Cash drawer view model class
    /// </summary>
    public class CashDrawerViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// Notifies when a property of this class changes
        /// </summary>
        public event PropertyChangedEventHandler? PropertyChanged;

        /// <summary>
        /// Handles when a property is changed
        /// </summary>
        /// <param name="propertyName">the name of the property changing</param>
        public void HandlePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        /// <summary>
        /// Keeps track of the amount due
        /// </summary>
        public decimal AmountDue
        {
            get
            {
                if(NegativeAmountDue < 0)
                {
                    return 0m;
                }
                return NegativeAmountDue;
            }
        }

        /// <summary>
        /// Keeps track of the extra money a customer may give
        /// </summary>
        public decimal NegativeAmountDue
        {
            get
            {
                decimal temp = Total - ((DimesFromCustomer * .1m) +
                    (FivesFromCustomer * 5) +
                    (NicklesFromCustomer * .05m) +
                    (OnesFromCustomer) +
                    (PenniesFromCustomer * .01m) +
                    (QuartersFromCustomer * .25m) +
                    (TensFromCustomer * 10) +
                    (TwentiesFromTheCustomer * 20));
                return temp;
            } 
        }

        /// <summary>
        /// the total change owed to the customer
        /// </summary>
        public decimal ChangeOwed
        {
            get
            {
                decimal temp = -1 * NegativeAmountDue;
                if(NegativeAmountDue < 0)
                {
                    return temp;
                }
                return 0;
            }
        }

        /// <summary>
        /// The total owed
        /// </summary>
        public decimal Total { get; set; }

        #region Currency in Drawer

        /// <summary>
        /// The pennies in the cashdrawer
        /// </summary>
        public uint PenniesInDrawer
        {
            get
            {
                return CashDrawer.Pennies;
            }
            set
            {
                if (CashDrawer.Pennies != value)
                {
                    CashDrawer.Pennies = value;
                    HandlePropertyChanged(nameof(PenniesInDrawer));
                }
            }
        }

        /// <summary>
        /// the dimes in the cashdrawer
        /// </summary>
        public uint DimesInDrawer
        {
            get
            {
                return CashDrawer.Dimes;
            }
            set
            {
                if (CashDrawer.Dimes != value)
                {
                    CashDrawer.Dimes = value;
                    HandlePropertyChanged(nameof(DimesInDrawer));
                }
            }
        }

        /// <summary>
        /// the quarters in the drawer
        /// </summary>
        public uint QuartersInDrawer
        {
            get
            {
                return CashDrawer.Quarters;
            }
            set
            {
                if (CashDrawer.Quarters != value)
                {
                    CashDrawer.Quarters = value;
                    HandlePropertyChanged(nameof(QuartersInDrawer));
                }
            }
        }

        /// <summary>
        /// returns the nickles in the cashdrawer
        /// </summary>
        public uint NicklesInDrawer
        {
            get
            {
                return CashDrawer.Nickles;
            }
            set
            {
                if (CashDrawer.Nickles != value)
                {
                    CashDrawer. Nickles = value;
                    HandlePropertyChanged(nameof(NicklesInDrawer));
                }
            }
        }

        /// <summary>
        /// returns the fives in the cashdrawer
        /// </summary>
        public uint FivesInDrawer
        {
            get
            {
                return CashDrawer.Fives;
            }
            set
            {
                if (CashDrawer.Fives != value)
                {
                    CashDrawer.Fives = value;
                    HandlePropertyChanged(nameof(FivesInDrawer));
                }
            }
        }

        /// <summary>
        /// returns the ones in the cashdrawer
        /// </summary>
        public uint OnesInDrawer
        {
            get
            {
                return CashDrawer.Ones;
            }
            set
            {
                if (CashDrawer.Ones != value)
                {
                    CashDrawer.Ones = value;
                    HandlePropertyChanged(nameof(OnesInDrawer));
                }
            }
        }

        /// <summary>
        /// returns the tens in the cashdrawer
        /// </summary>
        public uint TensInDrawer
        {
            get
            {
                return CashDrawer.Tens;
            }
            set
            {
                if (CashDrawer.Tens != value)
                {
                    CashDrawer.Tens = value;
                    HandlePropertyChanged(nameof(TensInDrawer));
                }
            }
        }

        /// <summary>
        /// returns the twenties in the cashdrawer
        /// </summary>
        public uint TwentiesInDrawer
        {
            get
            {
                return CashDrawer.Twenties;
            }
            set
            {
                if (CashDrawer.Twenties != value)
                {
                    CashDrawer.Twenties = value;
                    HandlePropertyChanged(nameof(TwentiesInDrawer));
                }
            }
        }

        #endregion

        #region Customer paying currency

        /// <summary>
        /// Private backing field for customer pennies
        /// </summary>
        private uint _penniesCustomer = 0;

        /// <summary>
        /// The pennies from the customer
        /// </summary>
        public uint PenniesFromCustomer
        {
            get
            {
                return _penniesCustomer;
            }
            set
            {
                _penniesCustomer = value;
                HandlePropertyChanged(nameof(PenniesFromCustomer));
                HandlePropertyChanged(nameof(AmountDue));
                HandlePropertyChanged(nameof(ChangeOwed));
            }
        }
        /// <summary>
        /// Private backing field for customer dimes
        /// </summary>
        private uint _dimesCustomer = 0;
        /// <summary>
        /// the dimes from the customer
        /// </summary>
        public uint DimesFromCustomer
        {
            get
            {
                return _dimesCustomer;
            }
            set
            {
                _dimesCustomer = value;
                HandlePropertyChanged(nameof(DimesFromCustomer));
                HandlePropertyChanged(nameof(AmountDue));
                HandlePropertyChanged(nameof(ChangeOwed));
            }
        }
        /// <summary>
        /// Private backing field for customer quarter
        /// </summary>
        private uint _quarterCustomer = 0;
        /// <summary>
        /// the quarters from the customer
        /// </summary>
        public uint QuartersFromCustomer
        {
            get
            {
                return _quarterCustomer;
            }
            set
            {
                _quarterCustomer = value;
                HandlePropertyChanged(nameof(QuartersFromCustomer));
                HandlePropertyChanged(nameof(AmountDue));
                HandlePropertyChanged(nameof(ChangeOwed));
            }
        }
        /// <summary>
        /// Private backing field for customer nickles
        /// </summary>
        private uint _nicklesCustomer = 0;
        /// <summary>
        /// returns the nickles from the customer
        /// </summary>
        public uint NicklesFromCustomer
        {
            get
            {
                return _nicklesCustomer;
            }
            set
            {
                _nicklesCustomer = value;
                HandlePropertyChanged(nameof(NicklesFromCustomer));
                HandlePropertyChanged(nameof(AmountDue));
                HandlePropertyChanged(nameof(ChangeOwed));
            }
        }
        /// <summary>
        /// Private backing field for customer fives
        /// </summary>
        private uint _fivesCustomer = 0;
        /// <summary>
        /// returns the fives from the customer
        /// </summary>
        public uint FivesFromCustomer
        {
            get
            {
                return _fivesCustomer;
            }
            set
            {
                _fivesCustomer = value;
                HandlePropertyChanged(nameof(FivesFromCustomer));
                HandlePropertyChanged(nameof(AmountDue));
                HandlePropertyChanged(nameof(ChangeOwed));
            }
        }
        /// <summary>
        /// Private backing field for customer ones
        /// </summary>
        private uint _onesCustomer = 0;
        /// <summary>
        /// returns the ones from the customer
        /// </summary>
        public uint OnesFromCustomer
        {
            get
            {
                return _onesCustomer;
            }
            set
            {
                _onesCustomer = value;
                HandlePropertyChanged(nameof(OnesFromCustomer));
                HandlePropertyChanged(nameof(AmountDue));
                HandlePropertyChanged(nameof(ChangeOwed));
            }
        }
        /// <summary>
        /// Private backing field for customer tens
        /// </summary>
        private uint _tensCustomer = 0;
        /// <summary>
        /// returns the tens from the customer
        /// </summary>
        public uint TensFromCustomer
        {
            get
            {
                return _tensCustomer;
            }
            set
            {
                _tensCustomer = value;
                HandlePropertyChanged(nameof(TensFromCustomer));
                HandlePropertyChanged(nameof(AmountDue));
                HandlePropertyChanged(nameof(ChangeOwed));
            }
        }
        /// <summary>
        /// Private backing field for customer twenties
        /// </summary>
        private uint _twentiesCustomer = 0;
        /// <summary>
        /// returns the twenties from the customer
        /// </summary>
        public uint TwentiesFromTheCustomer
        {
            get
            {
                return _twentiesCustomer;
            }
            set
            {
                _twentiesCustomer = value;
                HandlePropertyChanged(nameof(TwentiesFromTheCustomer));
                HandlePropertyChanged(nameof(AmountDue));
                HandlePropertyChanged(nameof(ChangeOwed));
            }
        }

        #endregion

        #region currency for change
        /// <summary>
        /// private backing field for pennies
        /// </summary>
        private uint _penniesChange = 0;
        /// <summary>
        /// The pennies in change
        /// </summary>
        public uint PenniesChange
        {
            get
            {
                return _penniesChange;
            }
            set
            {
                _penniesChange = value;
                HandlePropertyChanged(nameof(PenniesChange));
            }
        }
        /// <summary>
        /// private backing field for dimes
        /// </summary>
        private uint _dimesChange = 0;
        /// <summary>
        /// the dimes in change
        /// </summary>
        public uint DimesChange
        {
            get
            {
                return _dimesChange;
            }
            set
            {
                _dimesChange = value;
                HandlePropertyChanged(nameof(DimesChange));
            }
        }
        /// <summary>
        /// private backing field for quarters
        /// </summary>
        private uint _quartersChange = 0;
        /// <summary>
        /// the quarters in change
        /// </summary>
        public uint QuartersChange
        {
            get
            {
                return _quartersChange;
            }
            set
            {
                _quartersChange = value;
                HandlePropertyChanged(nameof(QuartersChange));
            }
        }
        /// <summary>
        /// private backing field for nickles
        /// </summary>
        private uint _nicklesChange = 0;
        /// <summary>
        /// returns the nickles in change
        /// </summary>
        public uint NicklesChange
        {
            get
            {
                return _nicklesChange;
            }
            set
            {
                _nicklesChange = value;
                HandlePropertyChanged(nameof(NicklesChange));
            }
        }
        /// <summary>
        /// private backing field for fives
        /// </summary>
        private uint _fivesChange = 0;
        /// <summary>
        /// returns the fives in change
        /// </summary>
        public uint FivesChange
        {
            get
            {
                return _fivesChange;
            }
            set
            {
                _fivesChange = value;
                HandlePropertyChanged(nameof(FivesChange));
            }
        }
        /// <summary>
        /// private backing field for ones
        /// </summary>
        private uint _onesChange = 0;
        /// <summary>
        /// returns the ones in change
        /// </summary>
        public uint OnesChange
        {
            get
            {
                return _onesChange;
            }
            set
            {
                _onesChange = value;
                HandlePropertyChanged(nameof(OnesChange));
            }
        }
        /// <summary>
        /// private backing field for tens
        /// </summary>
        private uint _tensChange = 0;
        /// <summary>
        /// returns the change in tens 
        /// </summary>
        public uint TensChange
        {
            get
            {
                return _tensChange;
            }
            set
            {
                _tensChange = value;
                HandlePropertyChanged(nameof(TensChange));
            }
        }
        /// <summary>
        /// private backing field for twenties
        /// </summary>
        private uint _twentiesChange = 0;
        /// <summary>
        /// returns the twenties in change
        /// </summary>
        public uint TwentiesChange
        {
            get
            {
                return _twentiesChange;
            }
            set
            {
                _twentiesChange = value;
                HandlePropertyChanged(nameof(TwentiesChange));
            }
        }


        #endregion

        /// <summary>
        /// updates the drawer, subtracting the change and adding the customer paid
        /// </summary>
        public void FinalizeTransaction()
        {
            CashDrawer.Open();
            
            //adds to the drawer
            TwentiesInDrawer += TwentiesFromTheCustomer;
            TensInDrawer += TensFromCustomer;
            FivesInDrawer += FivesFromCustomer;
            OnesInDrawer += OnesFromCustomer;
            QuartersInDrawer += QuartersFromCustomer;
            DimesInDrawer += DimesFromCustomer;
            NicklesInDrawer += NicklesFromCustomer;
            PenniesInDrawer += PenniesFromCustomer;

            decimal temp = ChangeOwed;
            //leaves the drawer for change
            while (temp-20 >= 0 && TwentiesInDrawer>0)
            {
                temp -= 20;
                TwentiesInDrawer--;
                TwentiesChange++;
            }
            while (temp - 10 >= 0 && TensInDrawer > 0)
            {
                temp -= 10;
                TensInDrawer--;
                TensChange++;
            }
            while (temp - 5 >= 0 && FivesInDrawer > 0)
            {
                temp -= 5;
                FivesInDrawer--;
                FivesChange++;
            }
            while (temp - 1 >= 0 && OnesInDrawer > 0)
            {
                temp -= 1;
                OnesInDrawer--;
                OnesChange++;
            }
            while (temp - .25m >= 0 && QuartersInDrawer > 0)
            {
                temp -= .25m;
                QuartersInDrawer--;
                QuartersChange++;
            }
            while (temp - .1m >= 0 && DimesInDrawer > 0)
            {
                temp -= .1m;
                DimesInDrawer--;
                DimesChange++;
            }
            while (temp - .05m >= 0 && NicklesInDrawer > 0)
            {
                temp -= .05m;
                NicklesInDrawer--;
                NicklesChange++;
            }
            while (temp - .01m >= 0 && PenniesInDrawer > 0)
            {
                temp -= .01m;
                PenniesInDrawer--;
                PenniesChange++;
            }

            
        }

    }
}
