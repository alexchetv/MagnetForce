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

    [InterestedIn(typeof(MagnetViewModel))]
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
            Magnets = ProblemObject.Magnets;
            
        }

        public override string Title { get { return "Shell"; } }

        // TODO: Register models with the vmpropmodel codesnippet
        
        [Model]
        public MainWindowModel ProblemObject
        {
            get { return GetValue<MainWindowModel>(ProblemObjectProperty); }
            private set { SetValue(ProblemObjectProperty, value); }
        }
        public static readonly PropertyData ProblemObjectProperty = RegisterProperty("ProblemObject", typeof(MainWindowModel), new MainWindowModel());
        
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
        public static readonly PropertyData MagnetsProperty = RegisterProperty("Magnets", typeof(ObservableCollection<Magnet>));

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

        /// <summary>
        /// Called when a command for a view model type that the current view model is interested in has been executed. This can
        /// be accomplished by decorating the view model with the <see cref="InterestedInAttribute"/>.
        /// </summary>
        /// <param name="viewModel">The view model.</param>
        /// <param name="command">The command that has been executed.</param>
        /// <param name="commandParameter">The command parameter used during the execution.</param>
        protected override async void OnViewModelCommandExecuted(IViewModel viewModel, ICatelCommand command, object commandParameter)
        {
            // TODO: Check what command has been executed
            var magnet = (viewModel as MagnetViewModel).MagnetObject;

            if (await _messageService.ShowAsync(string.Format("Вы действительно хотите удалить объект {0}?", magnet.Name), "Внимание!",
                        MessageButton.YesNo, MessageImage.Warning)
                        != MessageResult.Yes)
            {
                return;
            }


            Magnets.Remove(magnet);


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
