using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ResidentExecutor
{
    public class MainWindowViewModel : ViewModelBase
    {
        private Area selectedArea;
        private Measurent selectedMeasurent;
        private List<Area> areas;
        private AppService service;
        private List<ComboData<Area>> comboAreas;
        private List<CalculationValue> calculations;
        private DateTime date = DateTime.Now;

        private RelayCommand addAreaCommand;
        private RelayCommand addMeasurentCommand;
        private RelayCommand loadCommand;

        public MainWindowViewModel() 
        {
            comboAreas = new List<ComboData<Area>>();
            service = new AppService();
            selectedArea = new Area();
            selectedMeasurent = new Measurent();
            areas = service.GetAreas();
            LoadComboAreas(areas);
            Calculations = service.GetValues(Date);
        }

        public RelayCommand AddAreaCommand
        {
            get 
            {
                return addAreaCommand ?? (addAreaCommand = new RelayCommand(param => AddAreaExecute(), param => CanAddAreaExecute()));
            }
        }

        public RelayCommand AddMeasurentCommand
        {
            get
            {
                return addMeasurentCommand ?? (addMeasurentCommand = new RelayCommand(param => AddMeasurentCommandExecute()));
            }
        }

        public RelayCommand LoadCommand
        {
            get
            {
                return loadCommand ?? (loadCommand = new RelayCommand(param => LoadCommandExecute()));
            }
        }

        public Area SelectedArea
        {
            get { return selectedArea; }
            set 
            { 
                selectedArea = value;
                OnPropertyChanged(nameof(SelectedArea));
            }
        }

        public Measurent SelectedMeasurent 
        {
            get { return selectedMeasurent; }
            set 
            {
                selectedMeasurent = value;
                OnPropertyChanged(nameof(SelectedMeasurent));
            }
        }


        public DateTime Date 
        {
            get { return date; }
            set 
            {
                date = value;
                OnPropertyChanged(nameof(Date));
            }
        }
        public List<CalculationValue> Calculations 
        {
            get { return calculations; }
            set 
            {
                calculations = value;
                OnPropertyChanged(nameof(Calculations));
            }
        }

        public List<ComboData<Area>> ComboAreas 
        {
            get { return comboAreas; }
            set 
            {
                comboAreas = value;
                OnPropertyChanged(nameof(ComboAreas));
            }
        }

        public void LoadComboAreas(List<Area> areas) 
        {
            comboAreas = new List<ComboData<Area>>();

            foreach (Area area in areas) 
            {
                comboAreas.Add(new ComboData<Area> { Name = area.Name, Value = area });
            }

            ComboAreas = comboAreas;
        }

        public void AddAreaExecute() 
        {
            areas.Add(SelectedArea);
            SelectedArea = new Area();
            service.SaveAreas(areas);
            LoadComboAreas(areas);

            MessageBox.Show("Area added");
        }

        public bool CanAddAreaExecute() 
        {
            return selectedArea.Code != null && selectedArea.Name != null 
                && selectedArea.Code != string.Empty && selectedArea.Name != string.Empty;
        }

        public void AddMeasurentCommandExecute() 
        {
            service.AddMeasurment(SelectedMeasurent);
            SelectedMeasurent = new Measurent();

            MessageBox.Show("Measurment added");
        }

        public void LoadCommandExecute() 
        {
            Calculations = service.GetValues(Date);
        }
    }
}
