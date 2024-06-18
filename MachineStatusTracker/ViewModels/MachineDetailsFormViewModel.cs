using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace MachineStatusTracker.ViewModels
{
    public class MachineDetailsFormViewModel:ViewModelBase
    {
        private readonly ObservableCollection<MachineStatus> _opStatuses;
        public IEnumerable<MachineStatus> OpStatuses => _opStatuses;


        private string _machineName;
        public string MachineName {
            get
            { 
                return _machineName; 
            } 
            set 
            {
               _machineName = value;
                OnPropertyChanged(nameof(MachineName));
                OnPropertyChanged(nameof(CanSubmit));
            } 
        }

        private MachineStatus _machineStatus;
        public MachineStatus MachineStatus
        {
            
        get
            {
                return _machineStatus;
            }
            set
            {
                _machineStatus = value;
                OnPropertyChanged(nameof(MachineStatus));
                OnPropertyChanged(nameof(CanSubmit));
            }
        }

        private string _machineDescription;
        public string MachineDescription
        {

            get
            {
                return _machineDescription;
            }
            set
            {
                _machineDescription = value;
                OnPropertyChanged(nameof(MachineDescription));
            }
        }

        public ICommand SubmitCommand { get; set; }
        public ICommand CancelCommand { get; set; }

        public bool CanSubmit =>  !string.IsNullOrEmpty(MachineName);

        public MachineDetailsFormViewModel(ICommand submitCommand, ICommand cancelCommand)
        {
            SubmitCommand = submitCommand;
            CancelCommand = cancelCommand;


            _opStatuses = new ObservableCollection<MachineStatus>();
            _opStatuses.Add(new MachineStatus("Idle", Guid.NewGuid()));
            _opStatuses.Add(new MachineStatus("Offline", Guid.NewGuid()));
            _opStatuses.Add(new MachineStatus("Online", Guid.NewGuid()));
            _opStatuses.Add(new MachineStatus("Maintenance", Guid.NewGuid()));
        }


    }
}
