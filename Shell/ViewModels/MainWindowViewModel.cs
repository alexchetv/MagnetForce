namespace Shell.ViewModels
{
    using Catel.MVVM;
    using System.Threading.Tasks;
    using Catel.Data;
    using Models;
    using System.Collections.ObjectModel;

    public class MainWindowViewModel : ViewModelBase
    {
        public MainWindowViewModel()
        {
        }

        public override string Title { get { return "Shell"; } }

        // TODO: Register models with the vmpropmodel codesnippet
        // TODO: Register view model properties with the vmprop or vmpropviewmodeltomodel codesnippets
        // TODO: Register commands with the vmcommand or vmcommandwithcanexecute codesnippets
      
        [Model]
        public MFProblem ProblemObject
        {
            get { return GetValue<MFProblem>(ProblemObjectProperty); }
            private set { SetValue(ProblemObjectProperty, value); }
        }
        public static readonly PropertyData ProblemObjectProperty = RegisterProperty("ProblemObject", typeof(MFProblem));


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

        /// <summary>
            /// Gets or sets the property value.
            /// </summary>
        [ViewModelToModel("ProblemObject")]
        public ObservableCollection<Magnet> Magnets
        {
            get { return GetValue<ObservableCollection<Magnet>>(MagnetsProperty); }
            set { SetValue(MagnetsProperty, value); }
        }

        /// <summary>
        /// Register the Magnets property so it is known in the class.
        /// </summary>
        public static readonly PropertyData MagnetsProperty = RegisterProperty("Magnets", typeof(ObservableCollection<Magnet>));

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
