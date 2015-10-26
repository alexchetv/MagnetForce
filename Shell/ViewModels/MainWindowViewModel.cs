namespace Shell.ViewModels
{
    using Catel.MVVM;
    using System.Threading.Tasks;
    using Catel.Data;
    using Catel.Services;
    using Shell.Services;
    using Models;
    using System.Collections.ObjectModel;
    using System.Collections.Generic;

    public class MainWindowViewModel : ViewModelBase
    {
        private readonly IUIVisualizerService _uiVisualizerService;
        private readonly IPleaseWaitService _pleaseWaitService;
        private readonly IMessageService _messageService;
        private readonly IOpenFileService _openFileService;

        public MainWindowViewModel(IUIVisualizerService uiVisualizerService, IPleaseWaitService pleaseWaitService, IMessageService messageService, IOpenFileService openFileService)
        {
            _uiVisualizerService = uiVisualizerService;
            _pleaseWaitService = pleaseWaitService;
            _messageService = messageService;
            _openFileService = openFileService;

            AddMagnet = new Command(OnAddMagnetExecuteAsync);
            EditMagnet = new Command(OnEditMagnetExecuteAsync, OnEditMagnetCanExecute);
            RemoveMagnet = new Command(OnRemoveMagnetExecuteAsync, OnRemoveMagnetCanExecute);
        }

        public override string Title { get { return "Shell"; } }

        // TODO: Register models with the vmpropmodel codesnippet
        
        [Model]
        public MFProblem ProblemObject
        {
            get { return GetValue<MFProblem>(ProblemObjectProperty); }
            private set { SetValue(ProblemObjectProperty, value); }
        }
        public static readonly PropertyData ProblemObjectProperty = RegisterProperty("ProblemObject", typeof(MFProblem), new MFProblem());
        
        // TODO: Register view model properties with the vmprop or vmpropviewmodeltomodel codesnippets
        [ViewModelToModel("ProblemObject","Name")]
        public string Name
        {
            get { return GetValue<string>(NameProperty); }
            set { SetValue(NameProperty, value); }
        }
        public static readonly PropertyData NameProperty = RegisterProperty("Name", typeof(string));


        [ViewModelToModel("ProblemObject")]
        public string Filename
        {
            get { return GetValue<string>(FilenameProperty); }
            set { SetValue(FilenameProperty, value); }
        }
        public static readonly PropertyData FilenameProperty = RegisterProperty("Filename", typeof(string));


        [ViewModelToModel("ProblemObject","Magnets")]
        public ObservableCollection<Magnet> Magnets
        {
            get { return GetValue<ObservableCollection<Magnet>>(MagnetsProperty); }
            set { SetValue(MagnetsProperty, value); }
        }
        public static readonly PropertyData MagnetsProperty = RegisterProperty("Magnets", typeof(ObservableCollection<Magnet>), () => new ObservableCollection<Magnet>());

        /// <summary>
        /// Validates the field values of this object. Override this method to enable
        /// validation of field values.
        /// </summary>
        /// <param name="validationResults">The validation results, add additional results to this list.</param>
        protected override void ValidateFields(List<IFieldValidationResult> validationResults)
        {
            if (Magnets.Count > 1)
            {
                validationResults.Add(FieldValidationResult.CreateError(MagnetsProperty,"Too many magnets"));
            }
        }

        // TODO: Register commands with the vmcommand or vmcommandwithcanexecute codesnippets


        public Command AddMagnet { get; private set; }

        private void OnAddMagnetExecuteAsync()
        {
            _openFileService.Filter = "FEMM solution|*.ans";
            _openFileService.Title = "Open FEMM solution file";
            if (_openFileService.DetermineFile())
            {
                // User selected a file
                var magnet = new Magnet();
                string errorMessage = string.Empty;
                if (AnsParser.ParseFile(_openFileService.FileName, out magnet, out errorMessage))
                Magnets.Add(magnet);
            }
        }


        public Command EditMagnet { get; private set; }

        /// <summary>
        /// Method to check whether the EditMagnet command can be executed.
        /// </summary>
        /// <returns><c>true</c> if the command can be executed; otherwise <c>false</c></returns>
        private bool OnEditMagnetCanExecute()
        {
            return true;
        }

        private void OnEditMagnetExecuteAsync()
        {
            // TODO: Handle command logic here
        }


        public Command RemoveMagnet { get; private set; }

        /// <summary>
        /// Method to check whether the RemoveMagnet command can be executed.
        /// </summary>
        /// <returns><c>true</c> if the command can be executed; otherwise <c>false</c></returns>
        private bool OnRemoveMagnetCanExecute()
        {
            return true;
        }

        private void OnRemoveMagnetExecuteAsync()
        {
            // TODO: Handle command logic here
        }

        protected override async Task InitializeAsync()
        {
            await base.InitializeAsync();

            // TODO: subscribe to events here
        }

        protected override async Task CloseAsync()
        {
            // TODO: unsubscribe from events here

            await base.CloseAsync();
        }
    }
}
